#pragma checksum "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Home\_AllCategoryViews.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "425e3f4ee9dd86385595c0da3db93ce8edd432ca"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Home__AllCategoryViews), @"mvc.1.0.view", @"/Views/Shared/Home/_AllCategoryViews.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Home/_AllCategoryViews.cshtml", typeof(AspNetCore.Views_Shared_Home__AllCategoryViews))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\_ViewImports.cshtml"
using Tokkepedia;

#line default
#line hidden
#line 2 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\_ViewImports.cshtml"
using Tokkepedia.Models;

#line default
#line hidden
#line 3 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\_ViewImports.cshtml"
using Tokkepedia.Models.ViewModels;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"425e3f4ee9dd86385595c0da3db93ce8edd432ca", @"/Views/Shared/Home/_AllCategoryViews.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ba46829bbb239bf192093e3fc0bf62e1c59ba7bf", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Home__AllCategoryViews : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ResultData<Category>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(29, 50, true);
            WriteLiteral("\r\n<div class=\"container\">\r\n    <div class=\"row\">\r\n");
            EndContext();
#line 5 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Home\_AllCategoryViews.cshtml"
         if (Model != null)
        {
            if (Model.Results.Count > 0)
            {
                foreach (var cat in Model.Results)
                {
                    

#line default
#line hidden
            BeginContext(268, 44, false);
#line 11 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Home\_AllCategoryViews.cshtml"
               Write(await Html.PartialAsync("CategoryView", cat));

#line default
#line hidden
            EndContext();
#line 11 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Home\_AllCategoryViews.cshtml"
                                                                 
                }
            }
            else
            {

#line default
#line hidden
            BeginContext(381, 170, true);
            WriteLiteral("                <div class=\"col-md-12 text-center\">\r\n                    <h2 style=\"text-align: center; margin-top: 12px\">No results found!</h2>\r\n                </div>\r\n");
            EndContext();
#line 19 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Home\_AllCategoryViews.cshtml"
            }
        }
        else
        {

#line default
#line hidden
            BeginContext(602, 158, true);
            WriteLiteral("            <div class=\"col-md-12 text-center\">\r\n                <h2 style=\"text-align: center; margin-top: 12px\">No results found!</h2>\r\n            </div>\r\n");
            EndContext();
#line 26 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Home\_AllCategoryViews.cshtml"
        }

#line default
#line hidden
            BeginContext(771, 20, true);
            WriteLiteral("    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ResultData<Category>> Html { get; private set; }
    }
}
#pragma warning restore 1591
