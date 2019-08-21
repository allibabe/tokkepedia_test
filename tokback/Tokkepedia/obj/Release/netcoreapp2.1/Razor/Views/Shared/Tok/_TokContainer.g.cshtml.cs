#pragma checksum "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokContainer.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3dcebf5edd3da896209b30a50c13f7a7f91cf599"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Tok__TokContainer), @"mvc.1.0.view", @"/Views/Shared/Tok/_TokContainer.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Tok/_TokContainer.cshtml", typeof(AspNetCore.Views_Shared_Tok__TokContainer))]
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
#line 2 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokContainer.cshtml"
using Tokkepedia.Tools.Extensions;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3dcebf5edd3da896209b30a50c13f7a7f91cf599", @"/Views/Shared/Tok/_TokContainer.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ba46829bbb239bf192093e3fc0bf62e1c59ba7bf", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Tok__TokContainer : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ResultData<Tok>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(60, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokContainer.cshtml"
 if (Model != null)
{
    

#line default
#line hidden
#line 6 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokContainer.cshtml"
     if (Model.Results.Count > 0)
    {
        List<string> Colors = new List<string>() {
            "#d32f2f", "#C2185B", "#7B1FA2", "#512DA8",
            "#303F9F", "#1976D2", "#0288D1", "#0097A7",
            "#00796B", "#388E3C", "#689F38", "#AFB42B",
            "#FBC02D", "#FFA000", "#F57C00", "#E64A19"
            };
        var rndmColors = Colors.Shuffle();
        int idx = 0;


#line default
#line hidden
            BeginContext(491, 86, true);
            WriteLiteral("        <div class=\"container\">\r\n            <div id=\"tokTileContainer\" class=\"row\">\r\n");
            EndContext();
#line 19 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokContainer.cshtml"
                 if (Model != null)
                {
                    if (Model.Results.Count > 0)
                    {
                        foreach (var tok in Model.Results)
                        {
                            if (idx >= Colors.Count) { rndmColors = Colors.Shuffle(); idx = 0; } // Shuffle Again
                            tok.ColorHex = rndmColors[idx];
                            idx += 1;

                            

#line default
#line hidden
            BeginContext(1039, 48, false);
#line 29 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokContainer.cshtml"
                       Write(await Html.PartialAsync("Tok/_TokTileView", tok));

#line default
#line hidden
            EndContext();
#line 29 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokContainer.cshtml"
                                                                             
                        }
                    }
                    else
                    {

#line default
#line hidden
            BeginContext(1188, 194, true);
            WriteLiteral("                        <div class=\"col-md-12 text-center\">\r\n                            <h2 style=\"text-align: center; margin-top: 12px\">No results found!</h2>\r\n                        </div>\r\n");
            EndContext();
#line 37 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokContainer.cshtml"
                    }
                }
                else
                {

#line default
#line hidden
            BeginContext(1465, 182, true);
            WriteLiteral("                    <div class=\"col-md-12 text-center\">\r\n                        <h2 style=\"text-align: center; margin-top: 12px\">No results found!</h2>\r\n                    </div>\r\n");
            EndContext();
#line 44 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokContainer.cshtml"
                }

#line default
#line hidden
            BeginContext(1666, 407, true);
            WriteLiteral(@"            </div>
            <div class=""row"">
                <div class=""col-md-12"">
                    <div class=""justify-content-center"" style=""align-content:center!important;"">
                        <div class=""justify-content-center tokProgress"" style=""display:none; height:200px; width:200px;""></div>
                    </div>
                </div>
            </div>
        </div>
");
            EndContext();
#line 54 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokContainer.cshtml"
    }

#line default
#line hidden
            BeginContext(2082, 1131, true);
            WriteLiteral(@"    <script>
        // This is required to load the loading animation script
        var animation = bodymovin.loadAnimation({
            container: $("".tokProgress"")[0], // Required
            path: window.location.origin + '/images/anim/trail_loading.json', //baseUrl + 'images/anim/trail_loading.json', // Required
            renderer: 'svg', // Required
            loop: true, // Optional
            autoplay: true, // Optional
            name: """" // Name for future reference. Optional.
        });

        //Image popup
        $('.image-popup-no-margins').magnificPopup({ //.image-popup-no-margins
            type: 'image',
            closeOnContentClick: true,
            closeBtnInside: false,
            fixedContentPos: true,
            mainClass: 'mfp-no-margins mfp-with-zoom', // class to remove default margin from left and right side
            image: {
                verticalFit: true
            },
            zoom: {
                enabled: true,
                d");
            WriteLiteral("uration: 300 // don\'t foget to change the duration also in CSS\r\n            }\r\n        });\r\n    </script>\r\n");
            EndContext();
#line 83 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokContainer.cshtml"
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
