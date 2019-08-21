using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Claims;
using System.Threading.Tasks;
using Tokkepedia.Models;
using Tokkepedia.Services;
using Tokkepedia.Tools;

[assembly: HostingStartup(typeof(Tokkepedia.Areas.Identity.IdentityHostingStartup))]
namespace Tokkepedia.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddIdentity<TokketUser, FirebaseIdentityRole>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 4;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                })
                    .AddDefaultTokenProviders();

                // Identity Services
                services.AddTransient<IUserStore<TokketUser>, FirebaseUserStore<TokketUser>>();
                services.AddTransient<IRoleStore<FirebaseIdentityRole>, FirebaseRoleStore<FirebaseIdentityRole>>();
                services.AddScoped<IPasswordHasher<TokketUser>, CustomPasswordHasher>();

                var fbsecret = KeyVaultService.GetSecretAsync("FacebookSecretKey", context.Configuration["FacebookSettings:SecretKey"]).GetAwaiter().GetResult();
                var googlesecret = KeyVaultService.GetSecretAsync("GoogleSecretKey", context.Configuration["GoogleSettings:SecretKey"]).GetAwaiter().GetResult();

                services.AddAuthentication()
                    .AddFacebook(facebookOptions =>
                    {
                        facebookOptions.AppId = context.Configuration["FacebookSettings:AppId"];
                        facebookOptions.AppSecret = fbsecret;
                        facebookOptions.SaveTokens = true;
                        facebookOptions.Scope.Add("public_profile");
                    })
                    .AddGoogle(googleOptions =>
                    {
                        googleOptions.ClientId = context.Configuration["GoogleSettings:ClientId"];
                        googleOptions.ClientSecret = googlesecret;
                        googleOptions.SaveTokens = true;
                        googleOptions.Events = new OAuthEvents
                        {
                            OnCreatingTicket = gContext =>
                            {
                                var identity = (ClaimsIdentity)gContext.Principal.Identity;
                                var profileImg = gContext.User["image"].Value<string>("url");
                                identity.AddClaim(new Claim("profileImg", profileImg));
                                return Task.FromResult(0);
                            }
                        };
                    });
            });
        }
    }
}