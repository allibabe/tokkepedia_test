using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tokkepedia.Models;
using Tokkepedia.Models.ViewModels;
using Tokkepedia.Services.Interfaces;
using Tokkepedia.Tools.Extensions;

namespace Tokkepedia.Controllers
{
    public class UserController : Controller
    {
        const string SessionTokGroupsKey = "TokGroups";
        private readonly UserManager<TokketUser> _userManager;
        private readonly SignInManager<TokketUser> _signInManager;
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        private readonly ITokService _tokService;
        private readonly IReactionService _reactionService;
        private readonly INotificationService _notificationService;

        public UserController(UserManager<TokketUser> userManager, SignInManager<TokketUser> signInManager,
            ILogger<UserController> logger, IUserService userService, ITokService tokService, IReactionService reactionService, INotificationService notificationService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _userService = userService;
            _tokService = tokService;
            _reactionService = reactionService;
            _notificationService = notificationService;
        }

        [Route("logout")]
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [Route("account")]
        public async Task<IActionResult> ManageAccount()
        {
            AccountViewModel my = new AccountViewModel();
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var userName = user.UserName;
            var email = user.Email;
            var phoneNumber = "";

            my.Username = userName;
            my.Email = email;
            my.PhoneNumber = phoneNumber;
            my.IsEmailConfirmed = user.EmailConfirmed;
            my.ChangePasswordModel = new ChangePasswordViewModel();
            my.DeleteModel = new DeleteViewModel();

            return View("MyAccount", my);
        }

        
        [HttpPost]
        public async Task<IActionResult> UpdateAccount(AccountViewModel model)
        {
            ViewBag.ActiveTab = 1;
            if (!ModelState.IsValid)
            {
                return View("MyAccount");
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var email = await _userManager.GetEmailAsync(user);
            if (model.Email != email)
            {
                var setEmailResult = await _userManager.SetEmailAsync(user, model.Email);
                if (!setEmailResult.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(user);
                    throw new InvalidOperationException($"Unexpected error occurred setting email for user with ID '{userId}'.");
                }
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (model.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, model.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    var userId = await _userManager.GetUserIdAsync(user);
                    throw new InvalidOperationException($"Unexpected error occurred setting phone number for user with ID '{userId}'.");
                }
            }

            await _signInManager.RefreshSignInAsync(user);
            model.StatusMessage = "Your profile has been updated";
            return View("MyAccount", model);
        }

        [HttpPost]
        public async Task<IActionResult> SendVerificationEmail(AccountViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View("ManageAccount");
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }


            //var userId = await _userManager.GetUserIdAsync(user);
            //var email = await _userManager.GetEmailAsync(user);
            //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            //var callbackUrl = Url.Page(
            //    "/Account/ConfirmEmail",
            //    pageHandler: null,
            //    values: new { userId = userId, code = code },
            //    protocol: Request.Scheme);
            //await _emailSender.SendEmailAsync(
            //    email,
            //    "Confirm your email",
            //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

            model.StatusMessage = "Verification email sent. Please check your email.";
            return View("ManageAccount", model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            ViewBag.ActiveTab = 2;
            if (!ModelState.IsValid)
            {
                return View("MyAccount", new AccountViewModel() { ChangePasswordModel = model });
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            var changePasswordResult = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
            if (!changePasswordResult.Succeeded)
            {
                foreach (var error in changePasswordResult.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View("MyAccount", new AccountViewModel() { ChangePasswordModel = model });
            }

            await _signInManager.RefreshSignInAsync(user);
            _logger.LogInformation("User changed their password successfully.");
            model.StatusMessage = "Your password has been changed.";

            return View("MyAccount", new AccountViewModel() { ChangePasswordModel = model });
        }

        [HttpPost]
        public async Task<IActionResult> DownloadPersonalDataAsJson()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            _logger.LogInformation("User with ID '{UserId}' asked for their personal data.", _userManager.GetUserId(User));

            // Only include personal data for download
            var personalData = new Dictionary<string, string>();
            var personalDataProps = typeof(IdentityUser).GetProperties().Where(
                            prop => Attribute.IsDefined(prop, typeof(PersonalDataAttribute)));
            foreach (var p in personalDataProps)
            {
                personalData.Add(p.Name, p.GetValue(user)?.ToString() ?? "null");
            }

            Response.Headers.Add("Content-Disposition", "attachment; filename=PersonalData.json");
            return new FileContentResult(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(personalData)), "text/json");
        }

        [HttpPost]
        public async Task<IActionResult> DeletePersonalData(DeleteViewModel model)
        {
            ViewBag.ActiveTab = 3;
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!await _userManager.CheckPasswordAsync(user, model.Password))
            {
                ModelState.AddModelError(string.Empty, "Password not correct.");
                return View("MyAccount", new AccountViewModel());
            }

            var result = await _userManager.DeleteAsync(user);
            var userId = await _userManager.GetUserIdAsync(user);
            if (!result.Succeeded)
            {
                throw new InvalidOperationException($"Unexpected error occurred deleteing user with ID '{userId}'.");
            }

            await _signInManager.SignOutAsync();

            _logger.LogInformation("User with ID '{UserId}' deleted themselves.", userId);

            return Redirect("~/");
        }

        [Authorize]
        [Route("changeprofilepicture")]
        [ActionName("ChangeProfilePicture")]
        public async Task<IActionResult> ChangeProfilePicture()
        {
            ChangeProfilePictureViewModel vm = new ChangeProfilePictureViewModel();
            var user = await _userManager.GetUserAsync(User);
            if (user != null)
            {
                vm.User = new ApplicationUser() { DisplayName = user.DisplayName };
                return View(vm);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [Authorize]
        [Route("changeprofilepicture")]
        [ActionName("ChangeProfilePicture")]
        public async Task<IActionResult> ChangeProfilePicture([Bind("User, Base64Image")] ChangeProfilePictureViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //Image Upload
                    if (!string.IsNullOrEmpty(viewModel.Base64Image)) await _userService.UploadProfilePictureAsync(viewModel.Base64Image);
                }
                catch (Exception ex)
                {
                    // An error occurred
                }
            }

            return RedirectToAction("UserProfile", new { id = User.GetUserId() });
        }

        [HttpPost]
        [Authorize]
        [Route("ChangeProfileCoverPhoto")]
        [ActionName("ChangeProfileCoverPhoto")]
        public async Task<IActionResult> ChangeProfileCoverPhoto([Bind("User, Base64Image_Cover")] ChangeProfilePictureViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //Image Upload
                    if (!string.IsNullOrEmpty(viewModel.Base64Image_Cover)) await _userService.UploadProfileCoverAsync(viewModel.Base64Image_Cover);
                }
                catch (Exception ex)
                {
                    // An error occurred
                }
            }

            return RedirectToAction("UserProfile", new { id = User.GetUserId() });
        }

        [Route("user")]
        [ActionName("UserProfile")]
        public async Task<IActionResult> UserProfile(string id)
        {
            UserProfileViewModel viewModel = new UserProfileViewModel();
            viewModel.User = await _userService.GetUserAsync(id);
            var data = await _tokService.GetToksAsync(new TokQueryValues() { userid = id });
            viewModel.Tok = data?.Results ?? new List<Tok>();
            viewModel.Token = data?.Token ?? string.Empty;

            if (viewModel.User != null)
            {
                //Load Reactions
                var user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    var followId = $"follow-{user.Id}-{id}";
                    viewModel.UserFollow = await _userService.GetFollowAsync(followId);

                    if (viewModel.UserFollow != null)
                        viewModel.UserFollowString = JsonConvert.SerializeObject(viewModel.UserFollow);
                }
            }
            return View(viewModel);
        }

        [Route("usercoins")]
        [ActionName("UserCoins")]
        public async Task<IActionResult> UserCoins(string id)
        {
            UserCoinsViewModel viewModel = new UserCoinsViewModel();
            var user = await _userService.GetUserAsync(id);
            viewModel.User = new ApplicationUser()
            {
                Id = user.Id,
                DisplayName = user.DisplayName
            };

            viewModel.Coins = (long)user.Coins;

            return View(viewModel);
        }

        [Route("userplatformpoints")]
        [ActionName("UserPlatformPoints")]
        public async Task<IActionResult> UserPlatformPoints(string id)
        {
            UserPlatformPointsViewModel viewModel = new UserPlatformPointsViewModel();
            var user = await _userService.GetUserAsync(id);
            viewModel.User = new ApplicationUser()
            {
                Id = user.Id,
                DisplayName = user.DisplayName
            };

            viewModel.TokkepediaPoints = (long)user.Points;
            viewModel.TotalPoints = (long)user.Points;

            return RedirectToAction("Index", "Home");
            //return View(viewModel);
        }

        [Route("userreactions")]
        [ActionName("UserReactions")]
        public async Task<IActionResult> UserReactions(string id, string name)
        {
            UserReactionsViewModel viewModel = new UserReactionsViewModel();
            viewModel.User = new ApplicationUser() { Id = id, DisplayName = name };
            
            var res = await _reactionService.GetReactionsAsync(new ReactionQueryValues() { user_id = id });
            if (res != null) viewModel.Reactions = res.Results;
            else viewModel.Reactions = new List<TokkepediaReaction>();

            return View(viewModel);
        }

        [Route("userpoints")]
        public async Task<IActionResult> UserPoints(string id)
        {
            UserPointsViewModel vm = new UserPointsViewModel();
            var user = await _userService.GetUserAsync(id);

            vm.User = new ApplicationUser()
            {
                DisplayName = user.DisplayName,
                Id = user.Id
            };

            if (vm.User != null)
            {
                if (HttpContext.Session.Get<List<TokTypeList>>(SessionTokGroupsKey) == null)
                {
                    var g = await _tokService.GetTokGroupsAsync();
                    HttpContext.Session.Set<List<TokTypeList>>(SessionTokGroupsKey, g);
                    vm.TokGroups = g;
                }
                else
                {
                    vm.TokGroups = HttpContext.Session.Get<List<TokTypeList>>(SessionTokGroupsKey);
                }

                #region Groups
                //
                List<TokTypeList> groups = new List<TokTypeList>();
                foreach (var group in vm.TokGroups)
                {
                    groups.Add(group);
                }
                groups = groups.OrderBy(x => x.TokTypes.Count()).ToList();

                vm.TokGroups = groups;
                #endregion

                //Counters
                vm.Counters = (await _tokService.GetTokGroupUserCountersAsync(id)).ToArray();

                if (vm.Counters.Length == 0)
                {
                    vm.Counters = null;
                }
                else
                {
                    //Put all counters to type order
                    var c = vm.Counters.ToList();
                    var userCounters = new TokTypeListUserCounter[vm.TokGroups.Count];
                    for (int i = 0; i < vm.TokGroups.Count; ++i)
                    {
                        if (c.Select(x => x.TokGroup).ToArray().Contains(vm.TokGroups[i].TokGroup))
                        {
                            var index = Array.IndexOf(c.Select(x => x.TokGroup).ToArray(), vm.TokGroups[i].TokGroup);
                            userCounters[i] = c.FirstOrDefault(x => x.TokGroup == vm.TokGroups[i].TokGroup);
                            c.Remove(userCounters[i]);
                        }
                        else { userCounters[i] = null; }

                        if (c.Count <= 0)
                            break;
                    }
                    vm.Counters = userCounters; //.OrderBy(x => x.TokTypes.Count()).ToList().ToArray()

                    //Each type must be Alphabetical order and have attached points
                    List<(List<(string, int)>, TokTypeList)> listOfLists = new List<(List<(string, int)>, TokTypeList)>();


                    for (int i = 0; i < vm.Counters.Length; ++i)
                    {
                        List<(string, int)> listTuple = new List<(string, int)>();
                        if (vm.Counters[i] != null)
                        {
                            for (int j = 0; j < vm.Counters[i].TokTypes.Length; ++j)
                            {
                                listTuple.Add((vm.Counters[i].TokTypes[j], vm.Counters[i].TokTypeCounts[j]));
                            }
                        }

                        listTuple = listTuple.OrderBy(x => x.Item1).ToList(); //Alpha
                        listOfLists.Add((listTuple, vm.TokGroups[i]));
                    }

                    //Put ordered items back in
                    for (int i = 0; i < vm.Counters.Length; ++i)
                    {
                        if (vm.Counters[i] != null)
                        {
                            vm.Counters[i].TokTypes = listOfLists[i].Item2.TokTypes;
                            vm.Counters[i].TokTypeCounts = listOfLists[i].Item1.Select(x => x.Item2).ToArray();
                        }
                    }


                }

            }

            return View(vm);
        }

        [Route("notifications")]
        public async Task<IActionResult> Notifications()
        {
            var notifs = await _notificationService.GetNotificationsAsync(User.GetUserId());
            return View(notifs);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeWebsite(string url)
        {
            var isSuccess = await _userService.UpdateUserWebsiteAsync(url);
            return Json(new { isSuccess, url });
        }

        [HttpPost]
        public async Task<IActionResult> ChangeBiodata(string biodata)
        {
            var isSuccess = await _userService.UpdateUserBioAsync(biodata);
            return Json(new { isSuccess, biodata });
        }

        [HttpPost]
        public async Task<IActionResult> UseAvatar(string avatarId)
        {
            await _userService.UseAvatarAsProfilePictureAsync(true);
            return Json(await _userService.UserSelectAvatarAsync(avatarId));
        }
    }
}