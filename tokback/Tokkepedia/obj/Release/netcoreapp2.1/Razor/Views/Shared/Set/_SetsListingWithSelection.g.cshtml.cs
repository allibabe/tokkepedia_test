#pragma checksum "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Set\_SetsListingWithSelection.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5e7925f4a4002e27939cb1cb797f3efa39397bb3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Set__SetsListingWithSelection), @"mvc.1.0.view", @"/Views/Shared/Set/_SetsListingWithSelection.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Set/_SetsListingWithSelection.cshtml", typeof(AspNetCore.Views_Shared_Set__SetsListingWithSelection))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5e7925f4a4002e27939cb1cb797f3efa39397bb3", @"/Views/Shared/Set/_SetsListingWithSelection.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ba46829bbb239bf192093e3fc0bf62e1c59ba7bf", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Set__SetsListingWithSelection : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<MySetsViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(24, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Set\_SetsListingWithSelection.cshtml"
 if (Model.Sets != null)
{
    foreach (var set in Model.Sets)
    {
        

#line default
#line hidden
            BeginContext(108, 53, false);
#line 7 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Set\_SetsListingWithSelection.cshtml"
   Write(await Html.PartialAsync("Set/_SetSelectionView", set));

#line default
#line hidden
            EndContext();
#line 7 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Set\_SetsListingWithSelection.cshtml"
                                                              
    }
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MySetsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
