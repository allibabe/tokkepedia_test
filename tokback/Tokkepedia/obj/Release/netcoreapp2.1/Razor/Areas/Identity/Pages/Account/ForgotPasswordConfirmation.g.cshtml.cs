#pragma checksum "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Areas\Identity\Pages\Account\ForgotPasswordConfirmation.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2c69057bc47e07352f1398547ddce59c25e39a81"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Tokkepedia.Areas.Identity.Pages.Account.Areas_Identity_Pages_Account_ForgotPasswordConfirmation), @"mvc.1.0.razor-page", @"/Areas/Identity/Pages/Account/ForgotPasswordConfirmation.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Areas/Identity/Pages/Account/ForgotPasswordConfirmation.cshtml", typeof(Tokkepedia.Areas.Identity.Pages.Account.Areas_Identity_Pages_Account_ForgotPasswordConfirmation), null)]
namespace Tokkepedia.Areas.Identity.Pages.Account
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 3 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Areas\Identity\Pages\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#line 2 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Areas\Identity\Pages\_ViewImports.cshtml"
using Tokkepedia.Areas.Identity;

#line default
#line hidden
#line 1 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Areas\Identity\Pages\Account\_ViewImports.cshtml"
using Tokkepedia.Areas.Identity.Pages.Account;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2c69057bc47e07352f1398547ddce59c25e39a81", @"/Areas/Identity/Pages/Account/ForgotPasswordConfirmation.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"338fc828ba2a2a62382d94502c2ea8a00a1f80e7", @"/Areas/Identity/Pages/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"795eda6d9e2ca1ee7e4f6d6d9909c5ec1cbf6d81", @"/Areas/Identity/Pages/Account/_ViewImports.cshtml")]
    public class Areas_Identity_Pages_Account_ForgotPasswordConfirmation : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Areas\Identity\Pages\Account\ForgotPasswordConfirmation.cshtml"
  
    ViewData["Title"] = "Forgot password confirmation";
    Layout = "~/Views/Shared/_LayoutPublic.cshtml";

#line default
#line hidden
            BeginContext(159, 407, true);
            WriteLiteral(@"
<!-- **** BACKGROUND !Important **** -->
<section class=""tokkepedia-main clearfix"">
    <div class=""tokkepdia-sub"">
    </div>
</section>
<!-- **** /BACKGROUND **** -->

<section class=""special-area clearfix"">
    <div class=""container h-100"">
        <div class=""row h-100"">
            <div class=""col-12 col-md header-spacing"">
                <br />
                <h2 class=""text-white"">");
            EndContext();
            BeginContext(567, 17, false);
#line 20 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Areas\Identity\Pages\Account\ForgotPasswordConfirmation.cshtml"
                                  Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(584, 198, true);
            WriteLiteral("</h2>\r\n                <p class=\"text-white\">\r\n                    Please check your email to reset your password.\r\n                </p>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ForgotPasswordConfirmation> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ForgotPasswordConfirmation> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<ForgotPasswordConfirmation>)PageContext?.ViewData;
        public ForgotPasswordConfirmation Model => ViewData.Model;
    }
}
#pragma warning restore 1591