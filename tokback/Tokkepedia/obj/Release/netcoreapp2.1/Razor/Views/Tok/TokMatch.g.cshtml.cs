#pragma checksum "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Tok\TokMatch.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b8c05896f72f3146a6549cbd9b7dda1cdbe4a8a5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Tok_TokMatch), @"mvc.1.0.view", @"/Views/Tok/TokMatch.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Tok/TokMatch.cshtml", typeof(AspNetCore.Views_Tok_TokMatch))]
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
#line 1 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Tok\TokMatch.cshtml"
using Tokkepedia.Tools.Helpers;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b8c05896f72f3146a6549cbd9b7dda1cdbe4a8a5", @"/Views/Tok/TokMatch.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ba46829bbb239bf192093e3fc0bf62e1c59ba7bf", @"/Views/_ViewImports.cshtml")]
    public class Views_Tok_TokMatch : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/allicss.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/boxes.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("flycoin"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/tokmatch/coin.gif"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("position:relative;float:left;width:10%;height:10%;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/tokmatch/check.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("w3-left "), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("max-height:20px;max-width:20px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/tokmatch/refresh.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/jquery.flip.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/tokkepedia.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/tokmatchgame.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Tok\TokMatch.cshtml"
  
    ViewData["Title"] = "Tok Match";
    Layout = "~/Views/Shared/_LayoutPublic.cshtml";
    int typeSelected = ViewBag.DataType ?? 0;
    var toks = ViewBag.OfflineToks;
    FilterType type = (FilterType)Enum.Parse(typeof(FilterType), typeSelected.ToString());

#line default
#line hidden
            BeginContext(307, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("Styles", async() => {
                BeginContext(326, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(332, 50, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ecc0146e43394b4ab95c332a86ba9de3", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(382, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(388, 48, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ae7473d24d094a438387a508d9b1ae54", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(436, 174, true);
                WriteLiteral("\r\n    <link href=\"https://fonts.googleapis.com/css?family=Lobster\" rel=\"stylesheet\">\r\n    <link href=\"https://fonts.googleapis.com/css?family=Concert+One\" rel=\"stylesheet\">\r\n");
                EndContext();
            }
            );
            BeginContext(613, 1532, true);
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

                    <!-- Page Content -->
                    <!-- Header -->
                    <div class=""row"">
                        <div class=""col-md-12"">
                            <label style=""font-size:24px; font-family: 'Lobster', cursive; color: white; margin-top: .5rem;"">Tok Match</label>

                            <div class=""float-right"" style=""color:white; margin-right: 64px; display: block; margin-top: 10px;"" id=""txtScoreSection"">
                                SCORE : <span id=""score"" style=""font-family: 'Lobster', cursive;color:");
            WriteLiteral(@"red;font-size:24px"">0</span>
                            </div>
                        </div>
                    </div>

                    <div id=""sidePopup"" class=""w3-modalAlli"">
                        <div class=""w3-modal-contentAlli w3-card-4  w3-animate-leftAlli"" style=""border-radius:20px;background-color:inherit;"">
                            <div class=""w3-container default-color-bg"" style="" border-radius:20px;border:solid 5px white; padding: 4px;"">

                                ");
            EndContext();
            BeginContext(2145, 110, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "55b52164352e4272b0af820f2f4e21d3", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2255, 1634, true);
            WriteLiteral(@"
                                <span id=""remarks"" class=""remarkClass""></span>

                                <button id=""btnnext"" class="" btn btn-success  "" onClick=""next()"" style=""border-radius:20px;float:right;margin-right:5px;"">NEXT</button>
                                <button id=""btnreset"" class="" btn btn-danger "" onClick=""window.location.reload()"" style=""border-radius:20px;float:right;"">  QUIT</button>

                            </div>
                        </div>
                    </div>

                    <div class=""row"">
                        <div class=""col-md-12"">
                            <div class=""center containerProgress"" style=""margin: 24px auto; display: none;"">
                                <div class=""colorlib-load""></div>
                            </div>

                            <div class=""row"" id=""cardContainer"">
                            </div>
                        </div>
                    </div>

                    <div class=""r");
            WriteLiteral(@"ow m-4"">
                        <div class=""col-md-12 "">
                            <div class=""btnsendreset col-md-6"" style=""margin: 0px auto; display: none;"">
                                <div class=""row"">
                                    <div class=""col-md-6"">
                                        <button id=""btnCheck"" onclick=""flip(this)""
                                                class=""btn-danger""
                                                style=""border-radius:100px;padding:10px;font-family:'Concert One',cursive;width:100%;"">
                                            ");
            EndContext();
            BeginContext(3889, 148, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "0ca7beb6f89c4b9a8a4260fd909900fb", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4037, 399, true);
            WriteLiteral(@"CHECK
                                        </button>
                                    </div>

                                    <div class=""col-md-6"">
                                        <button id=""btnReset"" onclick=""reset()"" class=""btn-primary "" style=""border-radius:100px;padding:10px;font-family:'Concert One', cursive;width:100%;"">
                                            ");
            EndContext();
            BeginContext(4436, 100, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "9b373583e9594afe9a0a93e610b04f76", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_9);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(4536, 1069, true);
            WriteLiteral(@"RESET
                                        </button>
                                    </div>
                                </div>
                            </div>


                            <i id=""btnPrevious"" class=""fas fa-arrow-alt-circle-left hide"" style=""position: absolute; top: 12.5%; left: 0; font-size: 36px; cursor: pointer;"" onclick=""navigate(-1)""></i>
                            <i id=""btnNext"" class=""fas fa-arrow-alt-circle-right hide"" style=""position: absolute; top: 12.5%; right: 0; font-size: 36px; cursor: pointer;"" onclick=""navigate(1)""></i>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>

<div class=""modal fade"" id=""introModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""introModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog modal-lg"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h4 class=""modal-title");
            WriteLiteral("\" id=\"introModalLabel\">Match the toks!</h4>\r\n");
            EndContext();
            BeginContext(5799, 58, true);
            WriteLiteral("            </div>\r\n            <div class=\"modal-body\">\r\n");
            EndContext();
#line 109 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Tok\TokMatch.cshtml"
                 switch (type)
                {
                    case FilterType.TokType:
                    case FilterType.Category:

#line default
#line hidden
            BeginContext(6001, 337, true);
            WriteLiteral(@"                        <div class=""row"">
                            <div class=""col-md-12"">
                                <h4>Toks:</h4>
                            </div>
                            <div class=""col-md-6"">
                                <input class=""styled-checkbox"" id=""chkDefault"" type=""checkbox"" value=""7"" ");
            EndContext();
            BeginContext(6340, 55, false);
#line 118 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Tok\TokMatch.cshtml"
                                                                                                     Write(typeSelected == 7 || typeSelected == 0 ? "checked" : "");

#line default
#line hidden
            EndContext();
            BeginContext(6396, 283, true);
            WriteLiteral(@" />
                                <label for=""chkDefault"">Featured (Default)</label>
                            </div>
                            <div class=""col-md-6"">
                                <input class=""styled-checkbox"" id=""chkCategory"" type=""checkbox"" value=""3"" ");
            EndContext();
            BeginContext(6681, 34, false);
#line 122 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Tok\TokMatch.cshtml"
                                                                                                      Write(typeSelected == 3 ? "checked" : "");

#line default
#line hidden
            EndContext();
            BeginContext(6716, 273, true);
            WriteLiteral(@" />
                                <label for=""chkCategory"">Category</label>
                            </div>
                            <div class=""col-md-6"">
                                <input class=""styled-checkbox"" id=""chkTokType"" type=""checkbox"" value=""1"" ");
            EndContext();
            BeginContext(6991, 34, false);
#line 126 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Tok\TokMatch.cshtml"
                                                                                                     Write(typeSelected == 1 ? "checked" : "");

#line default
#line hidden
            EndContext();
            BeginContext(7026, 268, true);
            WriteLiteral(@" />
                                <label for=""chkTokType"">Tok Type</label>
                            </div>
                            <div class=""col-md-6"">
                                <input class=""styled-checkbox"" id=""chkSet"" type=""checkbox"" value=""8"" ");
            EndContext();
            BeginContext(7296, 34, false);
#line 130 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Tok\TokMatch.cshtml"
                                                                                                 Write(typeSelected == 8 ? "checked" : "");

#line default
#line hidden
            EndContext();
            BeginContext(7331, 1228, true);
            WriteLiteral(@" />
                                <label for=""chkSet"">Set</label>
                            </div>
                            <div class=""col-md-12"">
                                <div style=""margin-bottom: 8px;""></div>
                            </div>
                        </div>
                        <div class=""row"">
                            <div class=""col-md-12"">
                                <h4>Get Toks from:</h4>
                            </div>
                            <div class=""col-md-6"" style=""text-align: center; margin: 4px auto"">
                                <input class=""styled-checkbox"" id=""chkDatabase"" type=""checkbox"" value=""1"" checked>
                                <label for=""chkDatabase"">Database (Default)</label>
                            </div>
                            <div class=""col-md-6"" style=""text-align: center; margin: 4px auto"">
                                <input class=""styled-checkbox"" id=""chkScreen"" type=""checkbox"" value=""2"">");
            WriteLiteral("\r\n                                <label for=\"chkScreen\">Screen (Fast)</label>\r\n                                <span style=\"font-size: 12px;color:#9C27B0;position:absolute; right: 40%;margin-top: 24px;\">");
            EndContext();
            BeginContext(8560, 18, false);
#line 148 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Tok\TokMatch.cshtml"
                                                                                                                       Write(ViewBag.TotalCards);

#line default
#line hidden
            EndContext();
            BeginContext(8578, 339, true);
            WriteLiteral(@" Toks Loaded</span>
                            </div>
                            <div class=""col-md-12"">
                                <span style=""font-size: 12px; font-style: italic;"">Drag the purple rectangles up and match them with the correct detail.</span>
                            </div>
                        </div>
");
            EndContext();
#line 154 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Tok\TokMatch.cshtml"
                        break;
                }

#line default
#line hidden
            BeginContext(8968, 1816, true);
            WriteLiteral(@"                <div class=""row"">
                    <div class=""col-md-12"">
                        <h4>Mode:</h4>
                    </div>
                    <div class=""col-md-6"" style=""text-align: center; margin: 4px auto"">
                        <input class=""styled-checkbox"" id=""chkNormal"" type=""checkbox"" value=""1"" checked>
                        <label for=""chkNormal"">Normal Mode</label>
                    </div>
                    <div class=""col-md-6"" style=""text-align: center; margin: 4px auto"">
                        <input class=""styled-checkbox"" id=""chkEducation"" type=""checkbox"" value=""2"">
                        <label for=""chkEducation"">Education Mode</label>
                    </div>
                    <div class=""col-md-12"">
                        <span style=""font-size: 12px; font-style: italic;"">Drag the purple rectangles up and match them with the correct detail.</span>
                    </div>
                </div>
            </div>
            <div class=");
            WriteLiteral(@"""modal-footer"">
                <div class=""col-md-12"" style=""text-align: center;"">
                    <button type=""button"" class=""btn btn-primary"" id=""btnStartGame"" style=""font-size: 24px"">Start Game!</button>
                    <button type=""button"" class=""btn btn-secondary btn-danger"" id=""btnQuit"" style=""font-size: 24px"" data-dismiss=""modal"">Quit</button>
                </div>
            </div>
        </div>
    </div>
</div>


<div class=""modal fade"" id=""gameOverModal"" tabindex=""-1"" role=""dialog"" aria-labelledby=""gameoverModalLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h4 class=""modal-title"" id=""gameoverModalLabel"">End of the game</h4>
");
            EndContext();
            BeginContext(10978, 630, true);
            WriteLiteral(@"            </div>
            <div class=""modal-body"">
                <div class=""row"">
                    <div class=""col-md-12"" style=""text-align: center;"">
                        <span style=""font-size: 28px;"">GAME OVER!</span>
                    </div>
                    <div class=""col-md-12"">
                        <span style=""font-size: 14px;"">You final score is <b id=""txtFinalScore"" style=""font-size: 20px;"">0.</b></span>
                    </div>
                </div>
            </div>
            <div class=""modal-footer"">
                <div class=""col-md-12"" style=""text-align: center;"">
");
            EndContext();
            BeginContext(11716, 265, true);
            WriteLiteral(@"                    <button type=""button"" class=""btn btn-secondary btn-danger"" id=""btnEndGame"" style=""font-size: 21px"" data-dismiss=""modal"" onclick=""location.reload()"">Quit</button>
                </div>
            </div>
        </div>
    </div>
</div>

");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(11999, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(12005, 43, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "04808afe6d724a9a8a25395d66f0ff49", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_10);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(12048, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(12054, 42, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6ea2f8a0d8194412ab1b9b7d69e95376", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_11);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(12096, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(12102, 44, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aae1f25085ad4c478bcf0b7f2c9c0f73", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_12);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(12146, 30, true);
                WriteLiteral("\r\n    <script>\r\n        id = \"");
                EndContext();
                BeginContext(12177, 10, false);
#line 218 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Tok\TokMatch.cshtml"
         Write(ViewBag.Id);

#line default
#line hidden
                EndContext();
                BeginContext(12187, 24, true);
                WriteLiteral("\";\r\n        cardCount = ");
                EndContext();
                BeginContext(12212, 18, false);
#line 219 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Tok\TokMatch.cshtml"
               Write(ViewBag.TotalCards);

#line default
#line hidden
                EndContext();
                BeginContext(12230, 22, true);
                WriteLiteral(";\r\n        maxRound = ");
                EndContext();
                BeginContext(12253, 16, false);
#line 220 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Tok\TokMatch.cshtml"
              Write(ViewBag.MaxRound);

#line default
#line hidden
                EndContext();
                BeginContext(12269, 22, true);
                WriteLiteral(";\r\n        dataType = ");
                EndContext();
                BeginContext(12292, 16, false);
#line 221 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Tok\TokMatch.cshtml"
              Write(ViewBag.DataType);

#line default
#line hidden
                EndContext();
                BeginContext(12308, 25, true);
                WriteLiteral(";\r\n        offlineToks = ");
                EndContext();
                BeginContext(12334, 30, false);
#line 222 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Tok\TokMatch.cshtml"
                 Write(Html.Raw(Json.Serialize(toks)));

#line default
#line hidden
                EndContext();
                BeginContext(12364, 3101, true);
                WriteLiteral(@";
        $(document).ready(function () {
            var modeSelected = 1, loadtype = 1;
            $('#introModal').modal('show');

            $(""#btnStartGame"").click(function () {
                $('#introModal').modal('hide');
                Init(modeSelected, loadtype);
            });

            $(""#chkNormal, #chkEducation"").change(function () {
                if ($(this).is("":checked"")) {
                    modeSelected = $(this).val();
                }

                switch ($(this).attr(""id"")) {
                    case ""chkNormal"":
                        $(""#chkEducation"").attr(""checked"", !$(this).is("":checked""));
                        break;
                    case ""chkEducation"":
                        $(""#chkNormal"").attr(""checked"", !$(this).is("":checked""));
                        break;
                }
            });

            $(""#chkDatabase, #chkScreen"").change(function () {
                if ($(this).is("":checked"")) {
                    loa");
                WriteLiteral(@"dtype = $(this).val();
                }
                console.log(loadtype);
                switch ($(this).attr(""id"")) {
                    case ""chkDatabase"":
                        $(""#chkScreen"").attr(""checked"", !$(this).is("":checked""));
                        break;
                    case ""chkScreen"":
                        $(""#chkDatabase"").attr(""checked"", !$(this).is("":checked""));
                        break;
                }
            });

            $(""#chkDefault, #chkCategory, #chkSet, #chkTokType"").change(function () {
                if ($(this).is("":checked"")) {
                    dataType = $(this).val();
                }

                switch ($(this).attr(""id"")) {
                    case ""chkDefault"":
                        $(""#chkCategory"").attr(""checked"", !$(this).is("":checked""));
                        $(""#chkSet"").attr(""checked"", !$(this).is("":checked""));
                        $(""#chkTokType"").attr(""checked"", !$(this).is("":checked""));
      ");
                WriteLiteral(@"                  break;
                    case ""chkCategory"":
                        $(""#chkDefault"").attr(""checked"", !$(this).is("":checked""));
                        $(""#chkSet"").attr(""checked"", !$(this).is("":checked""));
                        $(""#chkTokType"").attr(""checked"", !$(this).is("":checked""));
                        break;
                    case ""chkSet"":
                        $(""#chkDefault"").attr(""checked"", !$(this).is("":checked""));
                        $(""#chkCategory"").attr(""checked"", !$(this).is("":checked""));
                        $(""#chkTokType"").attr(""checked"", !$(this).is("":checked""));
                        break;
                    case ""chkTokType"":
                        $(""#chkDefault"").attr(""checked"", !$(this).is("":checked""));
                        $(""#chkCategory"").attr(""checked"", !$(this).is("":checked""));
                        $(""#chkSet"").attr(""checked"", !$(this).is("":checked""));
                        break;
                }
            });
                WriteLiteral("\n        });\r\n    </script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591