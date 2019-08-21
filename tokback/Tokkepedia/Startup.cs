using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity.UI.Services;
using Tokkepedia.Services;
using Tokkepedia.Models.ViewModels;
using Tokkepedia.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Razor;
using Tokkepedia.Tools;

namespace Tokkepedia
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false; // Default is true, make it false
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromHours(24);
                options.Cookie.HttpOnly = true;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddRazorPagesOptions(options =>
                {
                    options.AllowAreas = true;
                    options.Conventions.AuthorizeAreaFolder("Identity", "/Account/Manage");
                    options.Conventions.AuthorizeAreaPage("Identity", "/Account/Logout");
                    options.Conventions.AddAreaPageRoute("Identity", "/Account/Login", "/login");
                    //options.Conventions.AddAreaPageRoute("Identity", "/Account/Manage/Index", "/account");
                    options.Conventions.AddAreaPageRoute("Identity", "/Account/Register", "/signup");
                    options.Conventions.AddAreaPageRoute("Identity", "/Account/ForgotPassword", "/forgotpassword");
                });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/Identity/Account/Login";
                options.LogoutPath = $"/Identity/Account/Logout";
                options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
                options.ExpireTimeSpan = TimeSpan.FromHours(24);
            });

            // Configure Settings
            services.Configure<GoogleAnalyticsViewModel>(Configuration.GetSection("GoogleAnalytics"));
            services.Configure<ApiSettingsViewModel>(Configuration.GetSection("ApiSettings"));
            services.Configure<PaypalSettingsViewModel>(Configuration.GetSection("PaypalSettings"));
            services.AddHttpContextAccessor();
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.ViewLocationExpanders.Add(new AmpViewLocationExpander());
            });

            // Configure Tokkepedia Services
            services.AddHttpClient<IUserService, UserService>();
            services.AddHttpClient<ITokService, TokService>();
            services.AddHttpClient<ISetService, SetService>();
            services.AddHttpClient<IReactionService, ReactionService>();
            services.AddHttpClient<ICommonService, CommonService>();
            services.AddHttpClient<INotificationService, NotificationService>();
            services.AddHttpClient<IPaymentService, PaymentService>();
            services.AddHttpClient<IStickerService, StickerService>();

            // Transient Services
            services.AddTransient<IPaypalService, PaypalService>();
            services.AddTransient<ISearchService, SearchService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }

    
}
