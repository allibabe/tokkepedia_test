#pragma checksum "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_AllTokCardViews.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c9d7b23b7a69111839460dd824c91b1e8bebc459"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Tok__AllTokCardViews), @"mvc.1.0.view", @"/Views/Shared/Tok/_AllTokCardViews.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Tok/_AllTokCardViews.cshtml", typeof(AspNetCore.Views_Shared_Tok__AllTokCardViews))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c9d7b23b7a69111839460dd824c91b1e8bebc459", @"/Views/Shared/Tok/_AllTokCardViews.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ba46829bbb239bf192093e3fc0bf62e1c59ba7bf", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Tok__AllTokCardViews : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ResultData<Tok>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(24, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_AllTokCardViews.cshtml"
 if (Model.Results.Count > 0)
{
    

#line default
#line hidden
#line 5 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_AllTokCardViews.cshtml"
     foreach (Tok tok in Model.Results)
    {
        

#line default
#line hidden
            BeginContext(117, 48, false);
#line 7 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_AllTokCardViews.cshtml"
   Write(await Html.PartialAsync("Tok/_TokCardView", tok));

#line default
#line hidden
            EndContext();
            BeginContext(167, 16, true);
            WriteLiteral("        <hr />\r\n");
            EndContext();
#line 9 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_AllTokCardViews.cshtml"
    }

#line default
#line hidden
#line 9 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_AllTokCardViews.cshtml"
     
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ResultData<Tok>> Html { get; private set; }
    }
}
#pragma warning restore 1591
