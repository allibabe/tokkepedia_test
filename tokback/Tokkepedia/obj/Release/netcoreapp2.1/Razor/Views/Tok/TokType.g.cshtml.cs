#pragma checksum "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Tok\TokType.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "90e7416df93c0a3ce3aa7cc95e85cc2b8ac3ca5e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Tok_TokType), @"mvc.1.0.view", @"/Views/Tok/TokType.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Tok/TokType.cshtml", typeof(AspNetCore.Views_Tok_TokType))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"90e7416df93c0a3ce3aa7cc95e85cc2b8ac3ca5e", @"/Views/Tok/TokType.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ba46829bbb239bf192093e3fc0bf62e1c59ba7bf", @"/Views/_ViewImports.cshtml")]
    public class Views_Tok_TokType : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TokTypeViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/tokcards.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("btnPlayCards"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "PlayToks", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Set", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-route-type", "1", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width: 100%;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/tokmatch.jpg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("btnTokMatch"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "TokMatch", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_9 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Tok", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_10 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/TokFeed.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_11 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/common.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_12 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/jquery.flip.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(25, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Tok\TokType.cshtml"
  
    ViewData["Title"] = "Tok Type";
    Layout = "~/Views/Shared/_LayoutPublic.cshtml";

#line default
#line hidden
            BeginContext(124, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("Styles", async() => {
                BeginContext(143, 4, true);
                WriteLiteral("\r\n\r\n");
                EndContext();
            }
            );
            BeginContext(150, 635, true);
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
                    <br />
                    <div class=""row overview"">
                        <div class=""col-sm-12 text-center text-white"">
                            <h1>");
            EndContext();
            BeginContext(786, 18, false);
#line 27 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Tok\TokType.cshtml"
                           Write(Model.TokType.Name);

#line default
#line hidden
            EndContext();
            BeginContext(804, 51, true);
            WriteLiteral("</h1>\r\n                            <p class=\"lead\">");
            EndContext();
            BeginContext(856, 25, false);
#line 28 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Tok\TokType.cshtml"
                                       Write(Model.TokType.Description);

#line default
#line hidden
            EndContext();
            BeginContext(881, 50, true);
            WriteLiteral("</p>\r\n                            <small>Example: ");
            EndContext();
            BeginContext(932, 21, false);
#line 29 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Tok\TokType.cshtml"
                                       Write(Model.TokType.Example);

#line default
#line hidden
            EndContext();
            BeginContext(953, 265, true);
            WriteLiteral(@"</small>
                        </div>
                    </div>

                    <div class=""row overview"">
                        <div class=""col-md-12 user-pad text-center"">
                            <h3>TOKS</h3>
                            <h4>");
            EndContext();
            BeginContext(1219, 18, false);
#line 36 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Tok\TokType.cshtml"
                           Write(Model.TokType.Toks);

#line default
#line hidden
            EndContext();
            BeginContext(1237, 446, true);
            WriteLiteral(@"</h4>
                        </div>
                    </div>

                    <div class=""row"">
                        <div class=""col-md-12 text-center"" style=""padding-top: 12px;padding-bottom: 12px;"">
                            <div class=""col-md-6"" style=""margin: 0px auto;"">
                                <div class=""row"">
                                    <div class=""col-md-6"">
                                        ");
            EndContext();
            BeginContext(1683, 177, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "42bee7b5775d466d82dcaa728a2dc4e5", async() => {
                BeginContext(1821, 35, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "a50074183477430e823b9bdbd451c641", async() => {
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
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 45 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Tok\TokType.cshtml"
                                                                                                           WriteLiteral(Model.TokType.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-type", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["type"] = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1860, 146, true);
            WriteLiteral("\r\n                                    </div>\r\n                                    <div class=\"col-md-6\">\r\n                                        ");
            EndContext();
            BeginContext(2006, 175, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "768b730703334069a12bc93e9c99e833", async() => {
                BeginContext(2142, 35, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "1466f965d8b54029b2858692a1cf260b", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_8.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_8);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_9.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_9);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 48 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Tok\TokType.cshtml"
                                                                                                         WriteLiteral(Model.TokType.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-type", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["type"] = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2181, 1459, true);
            WriteLiteral(@"
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class=""row"">

                        <!--/col-3-->
                        <div class=""col-sm-12"">

                            <ul class=""nav nav-tabs"" id=""myTab"">
                                <li class=""nav-item nav-link""><a href=""#home"" data-toggle=""tab"">Toks</a></li>
                                <li class=""nav-item nav-link""><a href=""#cards"" data-toggle=""tab"" id=""tabTokCards"">Tok Cards</a></li>
                                <li class=""nav-item nav-link""><a href=""#toklist"" data-toggle=""tab"" id=""tabTokList"">Tok List</a></li>
                            </ul>

                            <div class=""tab-content"">
                                <div class=""tab-pane active"" id=""home"">
                                    <input id=""IsLoadMore"" type=""hidden"" value=""yes"" />
          ");
            WriteLiteral(@"                          <input id=""LoadMoreFunction"" type=""hidden"" value=""GetSearchData"" />
                                    <input id=""ValSearchText"" type=""hidden"" value="""" />
                                    <input id=""TxtCategory"" type=""hidden"" value="""" />
                                    <input id=""CountryFilter"" type=""hidden"" value="""" />
                                    <input id=""TokTypeFilter"" type=""hidden""");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 3640, "\"", 3667, 1);
#line 73 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Tok\TokType.cshtml"
WriteAttributeValue("", 3648, Model.TokType.Name, 3648, 19, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3668, 82, true);
            WriteLiteral(" />\r\n                                    <input id=\"TokTypeIdFilter\" type=\"hidden\"");
            EndContext();
            BeginWriteAttribute("value", " value=\"", 3750, "\"", 3775, 1);
#line 74 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Tok\TokType.cshtml"
WriteAttributeValue("", 3758, Model.TokType.Id, 3758, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3776, 4591, true);
            WriteLiteral(@" />
                                    <input id=""UserIdFilter"" type=""hidden"" value="""" />
                                    <input id=""searchorder"" type=""hidden"" value=""newest"" />
                                    <input id=""Token"" type=""hidden"" />

                                    <div class=""center"" id=""containerProgress"" style=""margin: 24px auto"">
                                        <div class=""colorlib-load""></div>
                                    </div>
                                    <div id=""tokContainer"" style=""margin-top: 1em !important;"">
                                        <div class=""container"">
                                            <div id=""tokTileContainer"" class=""row"">

                                            </div>
                                            <div class=""row"">
                                                <div class=""col-md-12"">
                                                    <div class=""justify-content-center"" style=""align-");
            WriteLiteral(@"content:center!important;"">
                                                        <div class=""justify-content-center tokProgress"" style=""display:none; height:200px; width:200px;""></div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!--/tab-pane-->
                                <div class=""tab-pane active"" id=""cards"" style=""visibility: hidden;"">
                                    <div class=""center cardContainerProgress"" style=""margin: 24px auto"">
                                        <div class=""colorlib-load""></div>
                                    </div>
                                    <div id=""tokCardContainer"" style=""margin-top: 1em !important;"">
                                        <div class=""cont");
            WriteLiteral(@"ainer"">
                                            <div id=""cardContainer"" class=""row"">

                                            </div>
                                            <div class=""row"">
                                                <div class=""col-md-12"">
                                                    <div class=""justify-content-center"" style=""align-content:center!important;"">
                                                        <div class=""justify-content-center cardMoreProgress"" style=""display:none; height:200px; width:200px;""></div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!--/tab-pane-->
                                <div class=""tab-pane"" id=""toklist"">
                            ");
            WriteLiteral(@"        <div class=""center cardContainerProgress"" style=""margin: 24px auto"">
                                        <div class=""colorlib-load""></div>
                                    </div>
                                    <div id=""tokListContainer"" class=""container"" style=""margin-top: 1em !important;"">
                                        <div class=""container"">
                                            <div id=""listContainer"" class=""row"">

                                            </div>
                                            <div class=""row"">
                                                <div class=""col-md-12"">
                                                    <div class=""justify-content-center"" style=""align-content:center!important;"">
                                                        <div class=""justify-content-center tokProgress"" style=""display:none; height:200px; width:200px;""></div>
                                                    </div>
                    ");
            WriteLiteral(@"                            </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!--/tab-pane-->
                        </div>
                        <!--/tab-content-->

                    </div>
                </div>
            </div>
        </div>
    </div>
</section>

");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(8385, 104, true);
                WriteLiteral("\r\n    <script src=\"https://cdnjs.cloudflare.com/ajax/libs/bodymovin/4.13.0/bodymovin.js\"></script>\r\n    ");
                EndContext();
                BeginContext(8489, 39, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "13aa2b00bb154fae9a165f13971805a2", async() => {
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
                BeginContext(8528, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(8534, 38, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "192e22f65c3d4f52af0d1f2159c2353a", async() => {
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
                BeginContext(8572, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(8578, 43, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "004c37eb1f0e4f81a0efb25d8827caac", async() => {
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
                BeginContext(8621, 184, true);
                WriteLiteral("\r\n\r\n    <script>\r\n        renderCount = 4;\r\n        $(document).ready(function () {\r\n            GetInitData($(\"#TokTypeIdFilter\").val(), 1, false, true);\r\n        });\r\n    </script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TokTypeViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591