using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Tokkepedia.Models;
using Firebase.Auth;
using Tokkepedia.Services;
using Tokkepedia.Tools.Extensions;
using System.Security.Claims;

namespace Tokkepedia.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class LoginModel : PageModel
    {
        private readonly SignInManager<TokketUser> _signInManager;
        private readonly UserManager<TokketUser> _userManager;
        private readonly ILogger<LoginModel> _logger;

        public LoginModel(SignInManager<TokketUser> signInManager, UserManager<TokketUser> userManager, ILogger<LoginModel> logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public string ReturnUrl { get; set; }

        [TempData]
        public string ErrorMessage { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "Remember me?")]
            public bool RememberMe { get; set; }
        }
        
        public async Task OnGetAsync(string returnUrl = null)
        {
            if (!string.IsNullOrEmpty(ErrorMessage))
            {
                ModelState.AddModelError(string.Empty, ErrorMessage);
            }

            returnUrl = returnUrl ?? Url.Content("~/");

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true

                FirebaseAuthLink link = null; string t = "";
                TokkepediaApiClient apiClient = new TokkepediaApiClient();
                try
                {
                    link = await apiClient.LoginEmailPasswordAsync(Input.Email.Trim(), Input.Password.Trim());
                    var user = new TokketUser()
                    {
                        Id = link.User.LocalId,
                        UserName = link.User.LocalId,
                        NormalizedUserName = link.User.LocalId.ToUpper(),
                        Email = Input.Email.Trim(),
                        NormalizedEmail = Input.Email.Trim().ToUpper(),
                        IdToken = link.FirebaseToken,
                        PasswordHash = Input.Password,
                        UserPhoto = link.User.PhotoUrl,
                        DisplayName = link.User.DisplayName
                    };
                    user.IdToken = link.FirebaseToken;
                    user.RefreshToken = link.RefreshToken;
                    await _signInManager.SignInAsync(user, new AuthenticationProperties() { AllowRefresh = true, IsPersistent = Input.RememberMe, ExpiresUtc = DateTime.UtcNow.AddMinutes(30) });
                    // Add Claims and Principals including Token
                    var claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
                    claims.Add(new Claim(ClaimTypes.Name, user.Id));
                    claims.Add(new Claim("IdToken", user.IdToken));
                    claims.Add(new Claim("StreamToken", user.RefreshToken)); //Refresh token is Stream token, may be changed in the future

                    var identity = new ClaimsIdentity(claims, "Identity.Application");
                    var p = new ClaimsPrincipal(identity);

                    // Authentication
                    await HttpContext.SignInAsync("Identity.Application", p, new AuthenticationProperties() { AllowRefresh = true, IsPersistent = Input.RememberMe, ExpiresUtc = DateTime.UtcNow.AddMinutes(30) });
                    HttpContext.User = p;

                    _logger.LogInformation("User logged in.");
                    return LocalRedirect(returnUrl);//returnUrl
                }
                catch (Exception ex)
                {
                    t = ex.Message;
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }

                //var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password.Trim(), Input.RememberMe, lockoutOnFailure: true);
                //if (result.Succeeded) // && link != null
                //{
                //    _logger.LogInformation("User logged in.");
                //    return LocalRedirect(returnUrl);
                //}
                //if (result.RequiresTwoFactor)
                //{
                //    return RedirectToPage("./LoginWith2fa", new { ReturnUrl = returnUrl, RememberMe = Input.RememberMe });
                //}
                //if (result.IsLockedOut)
                //{
                //    _logger.LogWarning("User account locked out.");
                //    return RedirectToPage("./Lockout");
                //}
                //else
                //{
                //    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                //    return Page();
                //}


            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

    }
}
