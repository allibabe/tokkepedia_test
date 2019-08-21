#pragma checksum "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Set\TokCards.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e23988ad10eb7d9fdf7548a8b4a797e405e655d8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Set_TokCards), @"mvc.1.0.view", @"/Views/Set/TokCards.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Set/TokCards.cshtml", typeof(AspNetCore.Views_Set_TokCards))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e23988ad10eb7d9fdf7548a8b4a797e405e655d8", @"/Views/Set/TokCards.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ba46829bbb239bf192093e3fc0bf62e1c59ba7bf", @"/Views/_ViewImports.cshtml")]
    public class Views_Set_TokCards : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SetViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/tokkepedia.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/jquery.flip.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Set\TokCards.cshtml"
  
    ViewData["Title"] = "Tok Cards";
    Layout = "~/Views/Shared/_LayoutPublic.cshtml";

    int tokCounter = 1;
    string detailCards = "";               
    int typeSelected = ViewBag.DataType ?? 0;

#line default
#line hidden
            BeginContext(238, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
            DefineSection("Styles", async() => {
                BeginContext(259, 4, true);
                WriteLiteral("\r\n\r\n");
                EndContext();
            }
            );
            BeginContext(266, 2279, true);
            WriteLiteral(@"
<!-- **** BACKGROUND !Important **** -->
<section class=""tokkepedia-main clearfix"">
    <div class=""tokkepdia-sub"">
    </div>
</section>
<!-- **** /BACKGROUND **** -->

<section class=""special-area bg-white"">
    <div class=""container h-100"">
        <div class=""row h-100"">
            <div class=""col-12 col-md"">
                <div class=""col-12 col-md header-spacing"" id=""pageContainer"" style=""padding-left: 0px; padding-right: 0px;"">

                    <div class=""row"">
                        <div class=""col-md-3 p-3"" style=""background: #fff; border-radius: 8px;"">
                            <div class=""row"">
                                <div class=""col-md-12"">
                                    <progress max=""1"" value=""1"" style=""width: 100%;"" id=""cardProgress""></progress>
                                    <h6 class=""text-center""><span id=""progCounter"">1</span>/<span id=""progMax"">1</span></h6>
                                </div>
                            </div>
        ");
            WriteLiteral(@"                    <div class=""row"">
                                <div class=""col-6"">
                                    <button class=""btn btn-primary"" id=""btnPlay"" onclick=""Play(2.0)"" style=""width: 100%""><i class=""fas fa-play""></i> Play</button>
                                </div>
                                <div class=""col-6"">
                                    <button class=""btn btn-primary"" style=""width: 100%"" onclick=""ShuffleCards($('.card-container'))""><i class=""fas fa-random""></i> Shuffle</button>
                                </div>
                            </div>
                            <div class=""row"">
                                <div class=""col-md-12"">
                                    <button type=""button"" class=""btn btn-primary"" style=""width: 100%; margin: 4px 0px;"" data-toggle=""modal"" data-target=""#optionsModal""><i class=""fas fa-cog""></i> Options</button>
                                </div>
                            </div>
                        <");
            WriteLiteral("/div>\r\n\r\n                        <div class=\"col-md-9 p-3\">\r\n                            <div class=\"row\">\r\n                                <div class=\"col-md-12\">\r\n                                    <div class=\"card-container\">\r\n");
            EndContext();
#line 56 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Set\TokCards.cshtml"
                                         if (Model.Toks.Count > 0)
                                        {
                                            foreach (var tok in Model.Toks)
                                            {

#line default
#line hidden
            BeginContext(2780, 77, true);
            WriteLiteral("                                                <div class=\"card custom-card\"");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 2857, "\"", 2882, 2);
            WriteAttributeValue("", 2862, "playCard_", 2862, 9, true);
#line 60 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Set\TokCards.cshtml"
WriteAttributeValue("", 2871, tokCounter, 2871, 11, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2883, 281, true);
            WriteLiteral(@">
                                                    <div class=""front center-content rounded-corner"" style=""background-color: #fff; width: 512px; height: 512px;"">
                                                        <div style=""position: absolute; width: 100%; height: 100%""");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 3164, "\"", 3210, 3);
            WriteAttributeValue("", 3174, "FlipCard($(\'#playCard_", 3174, 22, true);
#line 62 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Set\TokCards.cshtml"
WriteAttributeValue("", 3196, tokCounter, 3196, 11, false);

#line default
#line hidden
            WriteAttributeValue("", 3207, "\'))", 3207, 3, true);
            EndWriteAttribute();
            BeginContext(3211, 244, true);
            WriteLiteral("></div>\r\n                                                        <div class=\"float-right p-2\" style=\"position: absolute; top: 0; right: 0;\">\r\n                                                            <i class=\"fas fa-star tokkepedia-favorite\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 3455, "\"", 3507, 3);
            WriteAttributeValue("", 3465, "AddToFavorites($(\'#playCard_", 3465, 28, true);
#line 64 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Set\TokCards.cshtml"
WriteAttributeValue("", 3493, tokCounter, 3493, 11, false);

#line default
#line hidden
            WriteAttributeValue("", 3504, "\'))", 3504, 3, true);
            EndWriteAttribute();
            BeginContext(3508, 220, true);
            WriteLiteral("></i>\r\n                                                        </div>\r\n\r\n                                                        <div class=\"text-center\">\r\n                                                            <h2>");
            EndContext();
            BeginContext(3729, 20, false);
#line 68 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Set\TokCards.cshtml"
                                                           Write(tok.PrimaryFieldText);

#line default
#line hidden
            EndContext();
            BeginContext(3749, 499, true);
            WriteLiteral(@"</h2>
                                                        </div>

                                                        <h6 class=""card-hint"">Click to flip</h6>
                                                    </div>
                                                    <div class=""back rounded-corner center-content"" style=""width: 512px; height: 512px; overflow:auto;"">
                                                        <div style=""position: absolute; width: 100%; height: 100%""");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 4248, "\"", 4294, 3);
            WriteAttributeValue("", 4258, "FlipCard($(\'#playCard_", 4258, 22, true);
#line 74 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Set\TokCards.cshtml"
WriteAttributeValue("", 4280, tokCounter, 4280, 11, false);

#line default
#line hidden
            WriteAttributeValue("", 4291, "\'))", 4291, 3, true);
            EndWriteAttribute();
            BeginContext(4295, 244, true);
            WriteLiteral("></div>\r\n                                                        <div class=\"float-right p-2\" style=\"position: absolute; top: 0; right: 0;\">\r\n                                                            <i class=\"fas fa-star tokkepedia-favorite\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 4539, "\"", 4591, 3);
            WriteAttributeValue("", 4549, "AddToFavorites($(\'#playCard_", 4549, 28, true);
#line 76 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Set\TokCards.cshtml"
WriteAttributeValue("", 4577, tokCounter, 4577, 11, false);

#line default
#line hidden
            WriteAttributeValue("", 4588, "\'))", 4588, 3, true);
            EndWriteAttribute();
            BeginContext(4592, 267, true);
            WriteLiteral(@"></i>
                                                        </div>

                                                        <div class=""p-4 col-md-12"">
                                                            <div class=""col-md-12 text-center center-content""");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 4859, "\"", 4905, 3);
            WriteAttributeValue("", 4869, "FlipCard($(\'#playCard_", 4869, 22, true);
#line 80 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Set\TokCards.cshtml"
WriteAttributeValue("", 4891, tokCounter, 4891, 11, false);

#line default
#line hidden
            WriteAttributeValue("", 4902, "\'))", 4902, 3, true);
            EndWriteAttribute();
            BeginContext(4906, 3, true);
            WriteLiteral(">\r\n");
            EndContext();
#line 81 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Set\TokCards.cshtml"
                                                                 if (tok.IsDetailBased == false && !String.IsNullOrEmpty(tok.SecondaryFieldText))
                                                                {

#line default
#line hidden
            BeginContext(5123, 72, true);
            WriteLiteral("                                                                    <h2>");
            EndContext();
            BeginContext(5196, 52, false);
#line 83 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Set\TokCards.cshtml"
                                                                   Write(Html.DisplayFor(modelItem => tok.SecondaryFieldText));

#line default
#line hidden
            EndContext();
            BeginContext(5248, 7, true);
            WriteLiteral("</h2>\r\n");
            EndContext();
#line 84 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Set\TokCards.cshtml"
                                                                }
                                                                else if (tok.IsDetailBased == true)
                                                                {
                                                                    

#line default
#line hidden
#line 87 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Set\TokCards.cshtml"
                                                                     for (int i = 0; i < 5; ++i)
                                                                    {
                                                                        string iNum = (i + 1).ToString(), baseName = "EnglishDetail" + iNum, inputName = "txt" + baseName, counterName = "lbl" + baseName + "Num";

                                                                        if (!String.IsNullOrEmpty(tok.Details[i]))
                                                                        {

#line default
#line hidden
            BeginContext(6064, 96, true);
            WriteLiteral("                                                                            <input type=\"hidden\"");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 6160, "\"", 6189, 4);
            WriteAttributeValue("", 6165, "detailtext", 6165, 10, true);
#line 93 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Set\TokCards.cshtml"
WriteAttributeValue("", 6175, i+1, 6175, 6, false);

#line default
#line hidden
            WriteAttributeValue("", 6181, "-", 6181, 1, true);
#line 93 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Set\TokCards.cshtml"
WriteAttributeValue("", 6182, tok.Id, 6182, 7, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 6190, "\"", 6213, 1);
#line 93 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Set\TokCards.cshtml"
WriteAttributeValue("", 6198, tok.Details[i], 6198, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(6214, 5, true);
            WriteLiteral(" />\r\n");
            EndContext();
            BeginContext(6296, 14, false);
#line 94 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Set\TokCards.cshtml"
                                                                       Write(Html.Raw("• "));

#line default
#line hidden
            EndContext();
            BeginContext(6312, 44, false);
#line 94 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Set\TokCards.cshtml"
                                                                                       Write(Html.DisplayFor(modelItem => tok.Details[i]));

#line default
#line hidden
            EndContext();
            BeginContext(6358, 84, true);
            WriteLiteral("                                                                            <br />\r\n");
            EndContext();
#line 96 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Set\TokCards.cshtml"
                                                                        }
                                                                    }

#line default
#line hidden
#line 97 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Set\TokCards.cshtml"
                                                                     

                                                                }
                                                                else
                                                                {
                                                                    

#line default
#line hidden
            BeginContext(6863, 42, false);
#line 102 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Set\TokCards.cshtml"
                                                               Write(Html.DisplayFor(modelItem => tok.Category));

#line default
#line hidden
            EndContext();
#line 102 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Set\TokCards.cshtml"
                                                                                                               
                                                                }

#line default
#line hidden
            BeginContext(6974, 70, true);
            WriteLiteral("\r\n                                                            </div>\r\n");
            EndContext();
#line 106 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Set\TokCards.cshtml"
                                                             if (tok.Image != null)
                                                            {
                                                                if (!String.IsNullOrEmpty(tok.Image))
                                                                {

#line default
#line hidden
            BeginContext(7362, 227, true);
            WriteLiteral("                                                                    <div class=\"img-container\">\r\n                                                                        <div style=\"position: absolute; width: 100%; height: 100%\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 7589, "\"", 7635, 3);
            WriteAttributeValue("", 7599, "FlipCard($(\'#playCard_", 7599, 22, true);
#line 111 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Set\TokCards.cshtml"
WriteAttributeValue("", 7621, tokCounter, 7621, 11, false);

#line default
#line hidden
            WriteAttributeValue("", 7632, "\'))", 7632, 3, true);
            EndWriteAttribute();
            BeginContext(7636, 83, true);
            WriteLiteral("></div>\r\n                                                                        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 7719, "\"", 7736, 1);
#line 112 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Set\TokCards.cshtml"
WriteAttributeValue("", 7726, tok.Image, 7726, 10, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(7737, 31, true);
            WriteLiteral(" class=\"image-popup-no-margins\"");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 7768, "\"", 7784, 2);
            WriteAttributeValue("", 7773, "img-", 7773, 4, true);
#line 112 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Set\TokCards.cshtml"
WriteAttributeValue("", 7777, tok.Id, 7777, 7, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(7785, 99, true);
            WriteLiteral(">\r\n                                                                            <img class=\"cropped\"");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 7884, "\"", 7900, 1);
#line 113 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Set\TokCards.cshtml"
WriteAttributeValue("", 7890, tok.Image, 7890, 10, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(7901, 159, true);
            WriteLiteral(" />\r\n                                                                        </a>\r\n                                                                    </div>\r\n");
            EndContext();
#line 116 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Set\TokCards.cshtml"
                                                                }
                                                            }

#line default
#line hidden
            BeginContext(8190, 278, true);
            WriteLiteral(@"                                                        </div>
                                                        <h6 class=""card-hint"">Click to flip</h6>
                                                    </div>
                                                </div>
");
            EndContext();
#line 123 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Set\TokCards.cshtml"
                                                 if (tok.IsDetailBased)
                                                {
                                                    detailCards += tokCounter + ",";
                                                }

#line default
#line hidden
#line 126 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Set\TokCards.cshtml"
                                                 
                                                tokCounter += 1;
                                            }
                                        }

#line default
#line hidden
            BeginContext(8887, 5148, true);
            WriteLiteral(@"                                    </div>
                                </div>

                                <div class=""modal fade"" id=""optionsModal"" tabindex=""-1"" role=""dialog"" aria-hidden=""true"">
                                    <div class=""modal-dialog modal-dialog-centered accuratedialog"" role=""document"">
                                        <div class=""modal-content accuratecontent"">
                                            <div class=""modal-header"">
                                                <h5 class=""modal-title"">Options</h5>
                                                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                                                    <span aria-hidden=""true"">&times;</span>
                                                </button>
                                            </div>
                                            <div class=""modal-body"">
                                                <div cl");
            WriteLiteral(@"ass=""row"">
                                                    <div class=""col-4"">
                                                        <!-- Rounded switch -->
                                                        <label class=""toke-switch"">
                                                            <input type=""checkbox"" id=""chkFavoritesOnlyOption"" onchange=""FavoritesOnly(this, $('.card-container'))"">
                                                            <span class=""toke-slider round""></span>
                                                        </label>
                                                        <h6>Play Starred Only</h6>
                                                    </div>
                                                    <div class=""col-4"">
                                                        <!-- Rounded switch -->
                                                        <label class=""toke-switch"">
                                                         ");
            WriteLiteral(@"   <input type=""checkbox"" checked=""checked"" onchange=""ShowImages(this, $('.card-container'))"">
                                                            <span class=""toke-slider round""></span>
                                                        </label>
                                                        <h6>Show Images</h6>
                                                    </div>
                                                    <div class=""col-4"">
                                                        <i class=""fas fa-exchange-alt"" style=""font-size: 32px; color: #007bff; margin-bottom: .5rem;"" data-toggle=""tooltip"" title=""Flip All Cards"" onclick=""FlipAllCards()""></i>
                                                        <h6>Flip All Cards</h6>
                                                    </div>
                                                </div>
                                                <div class=""row"">
                                                    <div cla");
            WriteLiteral(@"ss=""col-md-6"">
                                                        <button class=""btn btn-primary"" onclick=""RemoveFavorites($('.card-container'))"" style=""width: 100%""><i class=""fas fa-sync-alt""></i> Refresh Cards</button>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class=""modal-footer"">
                                                <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Close</button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class=""row"">
                                <div class=""col-md-12"">
                                    <div class=""text-center p-2 playcard-buttons"">
               ");
            WriteLiteral(@"                         <i class=""fas fa-arrow-alt-circle-left tokkepedia-navicon"" onclick=""NavigateCards()""></i>
                                        <i class=""fas fa-arrow-alt-circle-right tokkepedia-navicon"" onclick=""NavigateCards(true)""></i>
                                        <i class=""fas fa-exchange-alt tokkepedia-navicon navicon-float-right"" data-toggle=""tooltip"" title=""Flip All Cards"" onclick=""FlipAllCards()""></i>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class=""modal fade"" id=""introModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""introModalLabel"" aria-hidden=""true"">
        <div class=""modal-dialog modal-lg"" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h4 class=""modal-title"" id=""introModalL");
            WriteLiteral("abel\">Match the toks!</h4>\r\n");
            EndContext();
            BeginContext(14241, 946, true);
            WriteLiteral(@"                </div>
                <div class=""modal-body"">
                    <div class=""row"">
                        <div class=""col-md-12"">
                            <h4>Get Toks from:</h4>
                        </div>
                        <div class=""col-md-6"" style=""text-align: center; margin: 4px auto"">
                            <input class=""styled-checkbox"" id=""chkDatabase"" type=""checkbox"" value=""1"" checked>
                            <label for=""chkDatabase"">Database (Default)</label>
                        </div>
                        <div class=""col-md-6"" style=""text-align: center; margin: 4px auto"">
                            <input class=""styled-checkbox"" id=""chkScreen"" type=""checkbox"" value=""2"">
                            <label for=""chkScreen"">Screen (Fast)</label>
                            <span style=""font-size: 12px;color:#9C27B0;position:absolute; right: 40%;margin-top: 24px;"">");
            EndContext();
            BeginContext(15188, 16, false);
#line 215 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Set\TokCards.cshtml"
                                                                                                                   Write(Model.Toks.Count);

#line default
#line hidden
            EndContext();
            BeginContext(15204, 864, true);
            WriteLiteral(@" Toks Loaded</span>
                        </div>
                        <div class=""col-md-12"">
                            <span style=""font-size: 12px; font-style: italic;"">Drag the purple rectangles up and match them with the correct detail.</span>
                        </div>
                    </div>
                </div>
                <div class=""modal-footer"">
                    <div class=""col-md-12"" style=""text-align: center;"">
                        <button type=""button"" class=""btn btn-primary"" id=""btnStartGame"" style=""font-size: 24px"">Start Game!</button>
                        <button type=""button"" class=""btn btn-secondary btn-danger"" id=""btnQuit"" style=""font-size: 24px"" data-dismiss=""modal"">Quit</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>

");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(16086, 100, true);
                WriteLiteral("\r\n    <script src=\"https://cdnjs.cloudflare.com/ajax/libs/bodymovin/4.13.0/bodymovin.js\"></script>\r\n");
                EndContext();
                BeginContext(16235, 4, true);
                WriteLiteral("    ");
                EndContext();
                BeginContext(16239, 42, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9e66e3719d284f7a8f3011c27e3263fd", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(16281, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(16287, 43, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c6e7820480074d2e8aab138e110823b6", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(16330, 34, true);
                WriteLiteral("\r\n    <script>\r\n        var id = \"");
                EndContext();
                BeginContext(16365, 10, false);
#line 239 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Set\TokCards.cshtml"
             Write(ViewBag.Id);

#line default
#line hidden
                EndContext();
                BeginContext(16375, 27, true);
                WriteLiteral("\";\r\n        var dataType = ");
                EndContext();
                BeginContext(16403, 16, false);
#line 240 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Set\TokCards.cshtml"
                  Write(ViewBag.DataType);

#line default
#line hidden
                EndContext();
                BeginContext(16419, 1118, true);
                WriteLiteral(@", loadtype = 1;
        if (dataType != 7 || dataType != 8 || dataType != 0) $("".card-container"").hide();
        $(window).resize(function () {
            if ($(window).width() <= 512) {
                var wh = $(window).width() - (15 * 2);
                //console.log(wh);

                // Set Card Proportional in Size
                $("".card-container"").css(""width"", wh);
                $("".card-container"").css(""height"", wh);

                $("".card-container > .custom-card"").css(""width"", wh);
                $("".card-container > .custom-card"").css(""height"", wh);

                $("".card-container > .custom-card > .front"").css(""width"", wh);
                $("".card-container > .custom-card > .front"").css(""height"", wh);

                $("".card-container > .custom-card > .back"").css(""width"", wh);
                $("".card-container > .custom-card > .back"").css(""height"", wh);

                // Play Cards Buttons Container
                $("".playcard-buttons"").css(""width"", wh");
                WriteLiteral(");\r\n            }\r\n        });\r\n\r\n        function StartGame() {\r\n            var dtlCards = \"");
                EndContext();
                BeginContext(17538, 11, false);
#line 266 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Set\TokCards.cshtml"
                       Write(detailCards);

#line default
#line hidden
                EndContext();
                BeginContext(17549, 443, true);
                WriteLiteral(@""";

            $("".card-container"").show();
            ApplyFlipCard_Manual();
            InitCards($("".card-container""));
            ApplyMagnificPopup();

            var splitCards = dtlCards.split("","");
            for (var i = 0; i < splitCards.length - 1; i++) {
                $(""#playCard_"" + splitCards[i]).flip('toggle');
            }
        }

        $(document).ready(function () {
            maxPlayCards = ");
                EndContext();
                BeginContext(17993, 10, false);
#line 280 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Set\TokCards.cshtml"
                      Write(tokCounter);

#line default
#line hidden
                EndContext();
                BeginContext(18003, 1475, true);
                WriteLiteral(@";
            $(""#progMax"").text(maxPlayCards - 1);
            $(""#cardProgress"").attr(""max"", maxPlayCards - 1);
            $(window).keydown(function (e) {
                switch (e.keyCode) {
                    case 39: // Right Arrow
                        NavigateCards(true);
                        break;
                    case 37: // Left Arrow
                        NavigateCards();
                        break;
                }
            });

            $(""#chkDatabase, #chkScreen"").change(function () {
                if ($(this).is("":checked"")) {
                    loadtype = $(this).val();
                }
                
                switch ($(this).attr(""id"")) {
                    case ""chkDatabase"":
                        $(""#chkScreen"").attr(""checked"", !$(this).is("":checked""));
                        break;
                    case ""chkScreen"":
                        $(""#chkDatabase"").attr(""checked"", !$(this).is("":checked""));
                      ");
                WriteLiteral(@"  break;
                }
            });
            
            if (dataType == 7 || dataType == 8 || dataType == 0) {
                StartGame();
            }
            else {
                $('#introModal').modal('show');
                $(""#btnStartGame"").click(function () {
                    StartGame();

                    $('#introModal').modal('hide');
                });
            }
        });
    </script>
");
                EndContext();
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SetViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
