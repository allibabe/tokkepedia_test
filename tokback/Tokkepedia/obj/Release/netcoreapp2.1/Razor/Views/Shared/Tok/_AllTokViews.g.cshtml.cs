#pragma checksum "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_AllTokViews.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d564e21ee6720c320277181ba97c78cbc80e7e37"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Tok__AllTokViews), @"mvc.1.0.view", @"/Views/Shared/Tok/_AllTokViews.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Tok/_AllTokViews.cshtml", typeof(AspNetCore.Views_Shared_Tok__AllTokViews))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d564e21ee6720c320277181ba97c78cbc80e7e37", @"/Views/Shared/Tok/_AllTokViews.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ba46829bbb239bf192093e3fc0bf62e1c59ba7bf", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Tok__AllTokViews : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ResultData<Tok>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(24, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_AllTokViews.cshtml"
 if (Model.Results.Count > 0)
{
    

#line default
#line hidden
#line 5 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_AllTokViews.cshtml"
     foreach (Tok tok in Model.Results)
    {
        

#line default
#line hidden
            BeginContext(117, 39, false);
#line 7 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_AllTokViews.cshtml"
   Write(await Html.PartialAsync("TokView", tok));

#line default
#line hidden
            EndContext();
            BeginContext(158, 16, true);
            WriteLiteral("        <hr />\r\n");
            EndContext();
#line 9 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_AllTokViews.cshtml"
    }

#line default
#line hidden
#line 9 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_AllTokViews.cshtml"
     
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