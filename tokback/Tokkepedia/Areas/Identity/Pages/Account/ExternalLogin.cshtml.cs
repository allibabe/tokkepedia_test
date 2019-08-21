using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Firebase.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Tokkepedia.Models;
using Tokkepedia.Services;

namespace Tokkepedia.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ExternalLoginModel : PageModel
    {
        private readonly SignInManager<TokketUser> _signInManager;
        private readonly UserManager<TokketUser> _userManager;
        private readonly ILogger<ExternalLoginModel> _logger;

        public ExternalLoginModel(
            SignInManager<TokketUser> signInManager,
            UserManager<TokketUser> userManager,
            ILogger<ExternalLoginModel> logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string LoginProvider { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            public string FirebaseToken { get; set; }

            [Required]
            public string Id { get; set; }

            [Required]
            public string UserPhoto { get; set; }

            [Required]
            public string UserName { get; set; }

            [Required]
            [Display(Name = "Display Name")]
            public string DisplayName { get; set; }

            [Required]
            [Display(Name = "Birthday")]
            public string Birthday { get; set; }

            [Required]
            [Display(Name = "Country")]
            public string Country { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required(ErrorMessage = "Please read our terms of service.")]
            [Range(typeof(bool), "true", "true", ErrorMessage = "Please read our terms of service.")]
            [Display(Name = "Accept Terms")]
            public bool TermAccepted { get; set; }
        }

        public IActionResult OnGetAsync()
        {
            return RedirectToPage("./Login");
        }

        public IActionResult OnPost(string provider, string returnUrl = null)
        {
            // Request a redirect to the external login provider.
            var redirectUrl = Url.Page("./ExternalLogin", pageHandler: "Callback", values: new { returnUrl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return new ChallengeResult(provider, properties);
        }

        public async Task<IActionResult> OnGetCallbackAsync(string returnUrl = null, string remoteError = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (remoteError != null)
            {
                ErrorMessage = $"Error from external provider: {remoteError}";
                return RedirectToPage("./Login", new { ReturnUrl = returnUrl });
            }
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                ErrorMessage = "Error loading external login information.";
                return RedirectToPage("./Login", new { ReturnUrl = returnUrl });
            }

            // profile claims

            // Sign in the user with this external login provider if the user already has a login.
            FirebaseAuthType authType;
            string email = "", photoUrl="";
            if (info.ProviderDisplayName == "Facebook")
            {
                authType = FirebaseAuthType.Facebook;
                var claims = info.Principal.Identities.First().Claims;
                email = claims.ElementAt(1).Value;
            }
            else if (info.ProviderDisplayName == "Google")
            {
                authType = FirebaseAuthType.Google;
                var claims = info.Principal.Identities.First().Claims;
                email = claims.ElementAt(4).Value;
                photoUrl = claims.ElementAt(5).Value;
            }
            else { authType = new FirebaseAuthType(); }
            

            var token = info.AuthenticationTokens.First().Value;

            TokkepediaApiClient apiClient = new TokkepediaApiClient();
            FirebaseAuthLink link = null;
            try
            {
                link = await apiClient.LoginOAuthAsync(info.ProviderDisplayName, token);
            }
            catch
            {

            }

            TokketUser user = await apiClient.GetUserAsync(link.User.LocalId);

            // If the user does not have an account, then ask the user to create an account.
            if (user == null)
            {
                ReturnUrl = returnUrl;
                LoginProvider = info.LoginProvider;
                if (info.Principal.HasClaim(c => c.Type == ClaimTypes.Email))
                {
                    Input = new InputModel
                    {
                        FirebaseToken = link.FirebaseToken,
                        Id = link.User.LocalId,
                        UserName = link.User.LocalId,
                        DisplayName = info.Principal.Identity.Name,
                        Email = info.Principal.FindFirstValue(ClaimTypes.Email)
                    };
                }
                return Page();
            }
            //Sign user in
            else
            {
                if (user.IsLockedOut)
                {
                    return RedirectToPage("./Lockout");
                }

                await _signInManager.SignInAsync(user, true);
                _logger.LogInformation("{Name} logged in with {LoginProvider} provider.", info.Principal.Identity.Name, info.LoginProvider);
                return LocalRedirect(returnUrl);
            }

            //var result = new Microsoft.AspNetCore.Identity.SignInResult();// await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: false, bypassTwoFactor : true);
            //if (result.Succeeded)
            //{
            //    _logger.LogInformation("{Name} logged in with {LoginProvider} provider.", info.Principal.Identity.Name, info.LoginProvider);
            //    return LocalRedirect(returnUrl);
            //}
            //if (result.IsLockedOut)
            //{
            //    return RedirectToPage("./Lockout");
            //}
            //else
            //{
            //    // If the user does not have an account, then ask the user to create an account.
            //    ReturnUrl = returnUrl;
            //    LoginProvider = info.LoginProvider;
            //    if (info.Principal.HasClaim(c => c.Type == ClaimTypes.Email))
            //    {
            //        Input = new InputModel
            //        {
            //            Email = info.Principal.FindFirstValue(ClaimTypes.Email)
            //        };
            //    }
            //    return Page();
            //}
        }

        public async Task<IActionResult> OnPostConfirmationAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            // Get the information about the user from the external login provider
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                ErrorMessage = "Error loading external login information during confirmation.";
                return RedirectToPage("./Login", new { ReturnUrl = returnUrl });
            }

            if (ModelState.IsValid)
            {
                TokkepediaApiClient apiClient = new TokkepediaApiClient();
                var link = await apiClient.LinkAccountsAsync(Input.FirebaseToken, Input.Email, Input.Password);

                DateTime date = DateTime.Parse(Input.Birthday);
                var user = new TokketUser
                {
                    Id = Input.Id,
                    UserName = Input.UserName,
                    DisplayName = Input.DisplayName,
                    Birthday = date,
                    Country = Input.Country,
                    Email = Input.Email,
                    PasswordHash = Input.Password,
                    IdToken = Input.FirebaseToken
                };

                //---Error to fix-----------------------------
                //--------------------------------------------
                var result = await _userManager.CreateAsync(user, Input.Password);
                //--------------------------------------------
                //--------------------------------------------

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            LoginProvider = info.LoginProvider;
            ReturnUrl = returnUrl;
            return Page();
        }
    }
}
