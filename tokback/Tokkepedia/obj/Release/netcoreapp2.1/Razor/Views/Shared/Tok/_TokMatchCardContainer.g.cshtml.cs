#pragma checksum "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokMatchCardContainer.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "49fbd8929a292f77f2c70d1668607fd498e42abc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Tok__TokMatchCardContainer), @"mvc.1.0.view", @"/Views/Shared/Tok/_TokMatchCardContainer.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Tok/_TokMatchCardContainer.cshtml", typeof(AspNetCore.Views_Shared_Tok__TokMatchCardContainer))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"49fbd8929a292f77f2c70d1668607fd498e42abc", @"/Views/Shared/Tok/_TokMatchCardContainer.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ba46829bbb239bf192093e3fc0bf62e1c59ba7bf", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Tok__TokMatchCardContainer : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Tok>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("answerBack"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/images/tokmatch/x.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("margin: 12px; width: 50%; height: 50%;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(18, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokMatchCardContainer.cshtml"
  
    var cnt = 0;
    var myClass = "";

    switch (Model.Count)
    {
        case 3:
            myClass = "col-12 col-md-4";
            break;
        case 4:
            myClass = "col-12 col-md-3";
            break;
        case 2:
        default:
            myClass = "col-12 col-md-6";
            break;
    }

#line default
#line hidden
            BeginContext(365, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 22 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokMatchCardContainer.cshtml"
 foreach (var tok in Model)
{

#line default
#line hidden
            BeginContext(399, 8, true);
            WriteLiteral("    <div");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 407, "\"", 434, 2);
#line 24 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokMatchCardContainer.cshtml"
WriteAttributeValue("", 415, myClass, 415, 8, false);

#line default
#line hidden
            WriteAttributeValue(" ", 423, "cardColumn", 424, 11, true);
            EndWriteAttribute();
            BeginContext(435, 13, true);
            WriteLiteral(" data-round=\"");
            EndContext();
            BeginContext(449, 20, false);
#line 24 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokMatchCardContainer.cshtml"
                                            Write(ViewBag.CurrentRound);

#line default
#line hidden
            EndContext();
            BeginContext(469, 140, true);
            WriteLiteral("\">\r\n        <div class=\"row\">\r\n            <div class=\"col-md-12\">\r\n                <div class=\"card custom-card\">\r\n                    <div");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 609, "\"", 625, 2);
            WriteAttributeValue("", 614, "tmCard_", 614, 7, true);
#line 28 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokMatchCardContainer.cshtml"
WriteAttributeValue("", 621, cnt, 621, 4, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(626, 15, true);
            WriteLiteral(" data-matchid=\"");
            EndContext();
            BeginContext(642, 6, false);
#line 28 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokMatchCardContainer.cshtml"
                                                   Write(tok.Id);

#line default
#line hidden
            EndContext();
            BeginContext(648, 261, true);
            WriteLiteral(@""" data-iscard=""1"" class=""front center-content rounded-corner col-md-12 empty"" style=""background-color: #fff; padding: 0px; overflow:auto; height: 350px;"">
                        <div class=""p-4 col-md-12 text-center center-content description"" id=""content"">
");
            EndContext();
#line 30 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokMatchCardContainer.cshtml"
                             if (!tok.IsDetailBased && !string.IsNullOrEmpty(tok.SecondaryFieldText))
                            {
                                var ln1 = tok.SecondaryFieldText.Length;
                                if (ln1 >= 100)
                                {

#line default
#line hidden
            BeginContext(1201, 40, true);
            WriteLiteral("                                    <h4>");
            EndContext();
            BeginContext(1242, 22, false);
#line 35 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokMatchCardContainer.cshtml"
                                   Write(tok.SecondaryFieldText);

#line default
#line hidden
            EndContext();
            BeginContext(1264, 7, true);
            WriteLiteral("</h4>\r\n");
            EndContext();
#line 36 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokMatchCardContainer.cshtml"
                                }
                                else
                                {

#line default
#line hidden
            BeginContext(1379, 40, true);
            WriteLiteral("                                    <h3>");
            EndContext();
            BeginContext(1420, 22, false);
#line 39 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokMatchCardContainer.cshtml"
                                   Write(tok.SecondaryFieldText);

#line default
#line hidden
            EndContext();
            BeginContext(1442, 7, true);
            WriteLiteral("</h3>\r\n");
            EndContext();
#line 40 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokMatchCardContainer.cshtml"
                                }
                            }
                            else if (tok.IsDetailBased)
                            {
                                

#line default
#line hidden
#line 44 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokMatchCardContainer.cshtml"
                                 for (int i = 0; i < 5; ++i)
                                {
                                    if (!string.IsNullOrEmpty(tok.Details[i]))
                                    {

#line default
#line hidden
            BeginContext(1819, 60, true);
            WriteLiteral("                                        <input type=\"hidden\"");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 1879, "\"", 1908, 4);
            WriteAttributeValue("", 1884, "detailtext", 1884, 10, true);
#line 48 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokMatchCardContainer.cshtml"
WriteAttributeValue("", 1894, i+1, 1894, 6, false);

#line default
#line hidden
            WriteAttributeValue("", 1900, "-", 1900, 1, true);
#line 48 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokMatchCardContainer.cshtml"
WriteAttributeValue("", 1901, tok.Id, 1901, 7, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 1909, "\"", 1932, 1);
#line 48 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokMatchCardContainer.cshtml"
WriteAttributeValue("", 1917, tok.Details[i], 1917, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1933, 50, true);
            WriteLiteral(" />\r\n                                        <span");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 1983, "\"", 2012, 1);
#line 49 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokMatchCardContainer.cshtml"
WriteAttributeValue("", 1991, i!=0 ? "hide" : "", 1991, 21, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2013, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(2015, 14, false);
#line 49 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokMatchCardContainer.cshtml"
                                                                       Write(Html.Raw("• "));

#line default
#line hidden
            EndContext();
            BeginContext(2029, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(2031, 40, false);
#line 49 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokMatchCardContainer.cshtml"
                                                                                       Write(Html.DisplayFor(model => tok.Details[i]));

#line default
#line hidden
            EndContext();
            BeginContext(2071, 57, true);
            WriteLiteral("</span>\r\n                                        <br />\r\n");
            EndContext();
#line 51 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokMatchCardContainer.cshtml"
                                    }
                                }

#line default
#line hidden
#line 52 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokMatchCardContainer.cshtml"
                                 

                                if (tok.Details.Count() > 0)
                                {

#line default
#line hidden
            BeginContext(2301, 275, true);
            WriteLiteral(@"                                    <div class=""col-md-12 text-center btnShowMore"" style=""cursor: pointer; background-color: #DBCCFF; position: absolute; bottom: 0;"" onclick=""showMore(this)""><i class=""fas fa-angle-double-down showMoreIcon"" style=""color: #9572e8""></i></div>
");
            EndContext();
#line 57 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokMatchCardContainer.cshtml"
                                }
                            }
                            else
                            {
                                

#line default
#line hidden
            BeginContext(2740, 42, false);
#line 61 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokMatchCardContainer.cshtml"
                           Write(Html.DisplayFor(modelItem => tok.Category));

#line default
#line hidden
            EndContext();
#line 61 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokMatchCardContainer.cshtml"
                                                                           
                            }

#line default
#line hidden
            BeginContext(2815, 357, true);
            WriteLiteral(@"                        </div>
                    </div>
                    <div class=""back rounded-corner center-content"" style=""height: 350px;"">
                        <div class=""p-4 col-md-12"">
                            <div class=""col-md-12 text-center center-content containerImage"" style=""display: block;"">
                                ");
            EndContext();
            BeginContext(3172, 98, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "3dfa8c4f8ef84af1b8b093235f68f825", async() => {
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
            BeginContext(3270, 342, true);
            WriteLiteral(@"
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class=""row"">
            <div class=""col-md-12 shuffleContainer"">
                <div class=""answerContainer"" style=""height: 196px;"" data-iscontainer=""1"" data-tokid=""");
            EndContext();
            BeginContext(3613, 6, false);
#line 78 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokMatchCardContainer.cshtml"
                                                                                                Write(tok.Id);

#line default
#line hidden
            EndContext();
            BeginContext(3619, 4, true);
            WriteLiteral("\">\r\n");
            EndContext();
#line 79 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokMatchCardContainer.cshtml"
                     if (tok.Image != null)
                    {
                        if (!String.IsNullOrEmpty(tok.Image))
                        {

#line default
#line hidden
            BeginContext(3781, 180, true);
            WriteLiteral("                            <div class=\"img-container backImage hide\" style=\"position: relative; height: 100%; padding: 5px;\">\r\n                                <img class=\"cropped\"");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 3961, "\"", 3977, 1);
#line 84 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokMatchCardContainer.cshtml"
WriteAttributeValue("", 3967, tok.Image, 3967, 10, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3978, 41, true);
            WriteLiteral(" />\r\n                            </div>\r\n");
            EndContext();
#line 86 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokMatchCardContainer.cshtml"
                        }
                    }
                    else
                    {
                        

#line default
#line hidden
            BeginContext(4177, 60, true);
            WriteLiteral("                        <div class=\"backImage hide\"></div>\r\n");
            EndContext();
#line 92 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokMatchCardContainer.cshtml"
                    }

#line default
#line hidden
            BeginContext(4260, 24, true);
            WriteLiteral("                    <div");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 4284, "\"", 4306, 2);
            WriteAttributeValue("", 4289, "answerHolder_", 4289, 13, true);
#line 93 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokMatchCardContainer.cshtml"
WriteAttributeValue("", 4302, cnt, 4302, 4, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4307, 15, true);
            WriteLiteral(" data-matchid=\"");
            EndContext();
            BeginContext(4323, 6, false);
#line 93 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokMatchCardContainer.cshtml"
                                                         Write(tok.Id);

#line default
#line hidden
            EndContext();
            BeginContext(4329, 165, true);
            WriteLiteral("\" class=\"empty2 answerHolder bg-white\" draggable=\"true\" ondrag=\"dragStart(this)\" style=\"position: relative; width: 100%; height: 100%\">\r\n                        <div");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 4494, "\"", 4517, 2);
            WriteAttributeValue("", 4499, "answerContent_", 4499, 14, true);
#line 94 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokMatchCardContainer.cshtml"
WriteAttributeValue("", 4513, cnt, 4513, 4, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4518, 18, true);
            WriteLiteral(" class=\"answer\">\r\n");
            EndContext();
#line 95 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokMatchCardContainer.cshtml"
                             if (tok.Image != null)
                            {
                                if (!String.IsNullOrEmpty(tok.Image))
                                {

#line default
#line hidden
            BeginContext(4726, 175, true);
            WriteLiteral("                                    <div class=\"img-container\" style=\"position: unset !important; height: auto;\">\r\n                                        <img class=\"cropped\"");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 4901, "\"", 4917, 1);
#line 100 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokMatchCardContainer.cshtml"
WriteAttributeValue("", 4907, tok.Image, 4907, 10, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4918, 49, true);
            WriteLiteral(" />\r\n                                    </div>\r\n");
            EndContext();
#line 102 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokMatchCardContainer.cshtml"
                                }
                            }

#line default
#line hidden
            BeginContext(5033, 73, true);
            WriteLiteral("                            <div id=\"answertext\" class=\"answertextBox\">\r\n");
            EndContext();
#line 105 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokMatchCardContainer.cshtml"
                                  
                                    var ln = tok.PrimaryFieldText?.Length ?? 0;
                                    if (ln >= 50)
                                    {

#line default
#line hidden
            BeginContext(5313, 44, true);
            WriteLiteral("                                        <h4>");
            EndContext();
            BeginContext(5358, 20, false);
#line 109 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokMatchCardContainer.cshtml"
                                       Write(tok.PrimaryFieldText);

#line default
#line hidden
            EndContext();
            BeginContext(5378, 7, true);
            WriteLiteral("</h4>\r\n");
            EndContext();
#line 110 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokMatchCardContainer.cshtml"
                                    }
                                    else if (ln >= 200)
                                    {

#line default
#line hidden
            BeginContext(5520, 44, true);
            WriteLiteral("                                        <h3>");
            EndContext();
            BeginContext(5565, 37, false);
#line 113 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokMatchCardContainer.cshtml"
                                       Write(tok.PrimaryFieldText.Substring(0,200));

#line default
#line hidden
            EndContext();
            BeginContext(5602, 7, true);
            WriteLiteral("</h3>\r\n");
            EndContext();
#line 114 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokMatchCardContainer.cshtml"
                                    }
                                    else
                                    {

#line default
#line hidden
            BeginContext(5729, 44, true);
            WriteLiteral("                                        <h3>");
            EndContext();
            BeginContext(5774, 20, false);
#line 117 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokMatchCardContainer.cshtml"
                                       Write(tok.PrimaryFieldText);

#line default
#line hidden
            EndContext();
            BeginContext(5794, 7, true);
            WriteLiteral("</h3>\r\n");
            EndContext();
#line 118 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokMatchCardContainer.cshtml"
                                    }
                                

#line default
#line hidden
            BeginContext(5875, 168, true);
            WriteLiteral("                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
            EndContext();
#line 127 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokMatchCardContainer.cshtml"
    cnt++;
}

#line default
#line hidden
            BeginContext(6058, 2, true);
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Tok>> Html { get; private set; }
    }
}
#pragma warning restore 1591
