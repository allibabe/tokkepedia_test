#pragma checksum "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Home\Search.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3b97cf2079f358a48333ca19b80f38b7b25ef604"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Search), @"mvc.1.0.view", @"/Views/Home/Search.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Search.cshtml", typeof(AspNetCore.Views_Home_Search))]
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
#line 2 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Home\Search.cshtml"
using System.Globalization;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3b97cf2079f358a48333ca19b80f38b7b25ef604", @"/Views/Home/Search.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ba46829bbb239bf192093e3fc0bf62e1c59ba7bf", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Search : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IndexViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("text/css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/jquery-ui.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("ValSearchText"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", "hidden", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/tokkepedia.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/TokFeed.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/common.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Home\Search.cshtml"
  
    ViewData["Title"] = "Search";
    Layout = "~/Views/Shared/_LayoutPublic.cshtml";

    var keyword = string.Empty;
    keyword = Context.Request.Query["text"];

#line default
#line hidden
            BeginContext(229, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("Styles", async() => {
                BeginContext(249, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(255, 68, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "05e75c28ad7045b18927f6af327e4978", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(323, 2, true);
                WriteLiteral("\r\n");
                EndContext();
            }
            );
            BeginContext(328, 471, true);
            WriteLiteral(@"<!-- **** BACKGROUND !Important **** -->
<section class=""tokkepedia-main clearfix"">
    <div class=""tokkepdia-sub"">
    </div>
</section>
<!-- **** /BACKGROUND **** -->

<section class=""special-area bg-white"" id=""extraSection"">
    <div class=""container h-100"">
        <div class=""row h-100"">
            <div class=""col-12 col-md"">
                <div class=""col-12 col-md header-spacing"" id=""pageContainer"" style=""padding-left: 0px; padding-right: 0px;"">
");
            EndContext();
            BeginContext(7526, 360, true);
            WriteLiteral(@"                    <!--/row-->
                    <!-- New Content -->
                    <div class=""row"" style=""margin-bottom: 24px"">
                        <div class=""col-md-12"">
                            <div class=""row no-gutters"">
                                <div class=""col"">
                                    <h2>Search results for: ");
            EndContext();
            BeginContext(7887, 7, false);
#line 131 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Home\Search.cshtml"
                                                       Write(keyword);

#line default
#line hidden
            EndContext();
            BeginContext(7894, 7, true);
            WriteLiteral("</h2>\r\n");
            EndContext();
            BeginContext(8118, 40, true);
            WriteLiteral("                                </div>\r\n");
            EndContext();
            BeginContext(8581, 2610, true);
            WriteLiteral(@"                            </div>
                        </div>
                    </div>
                    <div class=""row"">
                        <div class=""col-md-12"">

                            <ul class=""nav nav-tabs"" id=""myTab"">
                                <li class=""nav-item nav-link active""><a href=""#home"" data-toggle=""tab"">Toks</a></li>
                                <li class=""nav-item nav-link""><a href=""#people"" data-toggle=""tab"">People</a></li>
                                <li class=""nav-item nav-link""><a href=""#categories"" data-toggle=""tab"">Categories</a></li>
                            </ul>

                            <div class=""tab-content"">
                                <div class=""tab-pane active"" id=""home"">
                                    <!--Sort Dropdown-->
                                    <input id=""searchorder"" type=""hidden"" value=""newest"" />
                                    <div class=""bg-light"" style=""padding: 4px 8px; height: 48px; mar");
            WriteLiteral(@"gin-bottom: 1em !important"">
                                        <div class=""btn-group float-right"" style=""padding-bottom:0.1em!important;"">
                                            <button type=""button"" class=""btn btn-secondary dropdown-toggle"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                                                Sorted by <b id=""SearchOrderDisplay"">Newest</b>
                                            </button>
                                            <div class=""dropdown-menu dropdown-menu-right"">
                                                <a id=""oldest"" class=""dropdown-item"" href=""javascript:void(0)"">Oldest</a>
                                                <a id=""newest"" class=""dropdown-item"" href=""javascript:void(0)"">Newest</a>
                                                <a id=""mostliked"" class=""dropdown-item"" href=""javascript:void(0)"">Most Liked</a>
                                            </div>
                            ");
            WriteLiteral(@"            </div>
                                    </div>
                                    <input id=""TokTypeFilter"" type=""hidden"" value="""" />
                                    <input id=""TokTypeIdFilter"" type=""hidden"" value="""" />
                                    <input id=""UserIdFilter"" type=""hidden"" value="""" />
                                    <input id=""IsLoadMore"" type=""hidden"" value=""yes"" />
                                    <input id=""LoadMoreFunction"" type=""hidden"" value=""GetSearchData"" />
                                    ");
            EndContext();
            BeginContext(11192, 58, false);
#line 172 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Home\Search.cshtml"
                               Write(Html.HiddenFor(model => model.Token, new { id = "Token" }));

#line default
#line hidden
            EndContext();
            BeginContext(11250, 38, true);
            WriteLiteral("\r\n                                    ");
            EndContext();
            BeginContext(11288, 89, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "01af2c15ccc24188ad8d13d6225bd636", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#line 173 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Home\Search.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.SearchText);

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.InputTypeName = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            BeginWriteTagHelperAttribute();
#line 173 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Home\Search.cshtml"
                                                                                            WriteLiteral(Model.SearchText);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(11377, 4, true);
            WriteLiteral("\r\n\r\n");
            EndContext();
#line 175 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Home\Search.cshtml"
                                     if (Model.Tok.Count() > 0)
                                    {

#line default
#line hidden
            BeginContext(11485, 389, true);
            WriteLiteral(@"                                        <div class=""center"" id=""containerProgress"" style=""margin: 24px auto"">
                                            <div class=""colorlib-load""></div>
                                        </div>
                                        <div id=""tokContainer"" style=""margin-top: 1em !important;"">

                                        </div>
");
            EndContext();
#line 183 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Home\Search.cshtml"
                                    }
                                    else
                                    {

#line default
#line hidden
            BeginContext(11994, 63, true);
            WriteLiteral("                                        <p>No toks found.</p>\r\n");
            EndContext();
#line 187 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Home\Search.cshtml"
                                    }

#line default
#line hidden
            BeginContext(12096, 596, true);
            WriteLiteral(@"
                                </div>
                                <!--/tab-pane-->
                                <div class=""tab-pane"" id=""people"">

                                </div>
                                <!--/tab-pane-->
                                <div class=""tab-pane"" id=""categories"">

                                </div>

                            </div>
                            <!--/tab-pane-->
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>

");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(12710, 106, true);
                WriteLiteral("\r\n\r\n    <script src=\"https://cdnjs.cloudflare.com/ajax/libs/bodymovin/4.13.0/bodymovin.js\"></script>\r\n    ");
                EndContext();
                BeginContext(12816, 42, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1f01924ae8e34e15a3418979721e0c0e", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(12858, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(12864, 39, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8f9181ff0a664afd9ddd251514d308bc", async() => {
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
                BeginContext(12903, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(12909, 38, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "19d10ce95a0643a796d26e040aeecf8f", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(12947, 4260, true);
                WriteLiteral(@"

    <script>
        function InitializeToks(filter = '') {
            var opt = {};
            opt.url = ""Home/SearchToks?keyword="" + filter;
            opt.type = ""GET"";
            opt.async = true;
            opt.success = function (htmlData) {
                $(""#tokContainer"").html(htmlData);
            };
            opt.error = function () {
                $(""#containerProgress"").hide();
            };
            opt.beforeSend = function () {
                $(""#containerProgress"").show();
            };
            opt.complete = function () {
                $(""#containerProgress"").hide();
                // Facebook Renderer
                $('.social-buttons').each(function () {
                    var btnShare = $(this).find("".btnShare"");
                    FB.XFBML.parse(this);
                    var obj = {
                        method: 'feed',
                        link: btnShare.attr(""data-href""),
                        picture: btnShare.attr(""data-p");
                WriteLiteral(@"ic""),
                        name: btnShare.attr(""data-title""),
                        description: btnShare.attr(""data-desc"")
                    };
                    $("".btnShare"").click(function () {
                        FB.ui(obj, function (response) { console.log(response); });
                    });
                });

                $(""#twitter-button"").click(function (e) {
                    e.preventDefault();
                    var win = window.open(shareUrl, 'ShareOnTwitter', getWindowOptions());
                    win.opener = null; // 2
                });
                // Twitter Renderer
                $.ajax({ url: 'https://platform.twitter.com/widgets.js', dataType: 'script', cache: true });

                $("".tok-tile"").click(function (e) {
                    OpenDialog(this);
                });

                $("".tok-tile a"").on('click', function (ev) {
                    ev.stopImmediatePropagation();
                });

                // B");
                WriteLiteral(@"ootstrap Tooltip
                $(function () {
                    $('[data-toggle=""tooltip""]').tooltip();
                    $('[data-toggle=""modal""][title]').tooltip();
                })

                setTimeout(function () {
                    $("".dropdown-menu > .social-buttons > .fb-share-button > span"", "".dropdown-menu > .social-buttons > .fb-share-button > span > iframe"").css(""width"", ""73px"");
                    $("".dropdown-menu > .social-buttons > .fb-share-button > span"", "".dropdown-menu > .social-buttons > .fb-share-button > span > iframe"").css(""height"", ""28px"");
                }, 1500);
            };
            $.ajax(opt);
        }

        function InitializeUsers(filter = '') {
            var opt = {};
            opt.url = ""Home/GetAllUsers?keyword="" + filter;
            opt.type = ""GET"";
            opt.async = true;
            opt.success = function (htmlData) {
                $(""#people"").html(htmlData);
            };
            opt.error = function ");
                WriteLiteral(@"() {
                $(""#containerProgress"").hide();
            };
            opt.beforeSend = function () {
                $(""#containerProgress"").show();
            };
            opt.complete = function () {
                $(""#containerProgress"").hide();
            };
            $.ajax(opt);
        }

        function InitializeCategories(filter = '') {
            var categoryOptions = {};
            categoryOptions.url = ""Home/GetAllCategories?keyword="" + filter;
            categoryOptions.type = ""GET"";
            categoryOptions.async = true;
            categoryOptions.success = function (htmlData) {
                $(""#categories"").html(htmlData);
            };
            categoryOptions.error = function () {
                $(""#containerProgress"").hide();
            };
            categoryOptions.beforeSend = function () {
                $(""#containerProgress"").show();
            };
            categoryOptions.complete = function () {
                $(""#con");
                WriteLiteral("tainerProgress\").hide();\r\n            };\r\n            $.ajax(categoryOptions);\r\n        }\r\n\r\n        $(document).ready(function () {\r\n\r\n            InitializeToks(\'");
                EndContext();
                BeginContext(17208, 16, false);
#line 321 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Home\Search.cshtml"
                       Write(Model.SearchText);

#line default
#line hidden
                EndContext();
                BeginContext(17224, 41, true);
                WriteLiteral("\',2);\r\n            InitializeCategories(\'");
                EndContext();
                BeginContext(17266, 16, false);
#line 322 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Home\Search.cshtml"
                             Write(Model.SearchText);

#line default
#line hidden
                EndContext();
                BeginContext(17282, 34, true);
                WriteLiteral("\');\r\n            InitializeUsers(\'");
                EndContext();
                BeginContext(17317, 16, false);
#line 323 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Home\Search.cshtml"
                        Write(Model.SearchText);

#line default
#line hidden
                EndContext();
                BeginContext(17333, 494, true);
                WriteLiteral(@"');

            //$(""#btnSearch"").click(function () {
            //    InitializeToks($(""#txtSearchKeyword"").val(),2);
            //    InitializeCategories($(""#txtSearchKeyword"").val());
            //    InitializeUsers($(""#txtSearchKeyword"").val());
            //});

            $("".nav-item.nav-link"").click(function () {
                $("".nav-item.nav-link"").removeClass(""active"");
                $(this).addClass(""active"");
            });
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IndexViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
