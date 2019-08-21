#pragma checksum "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokTypesNewContent.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c527e2fc3e7b0a8338e4c733001841ab58eb52d9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Tok__TokTypesNewContent), @"mvc.1.0.view", @"/Views/Shared/Tok/_TokTypesNewContent.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Tok/_TokTypesNewContent.cshtml", typeof(AspNetCore.Views_Shared_Tok__TokTypesNewContent))]
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
#line 2 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokTypesNewContent.cshtml"
using System.Drawing;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c527e2fc3e7b0a8338e4c733001841ab58eb52d9", @"/Views/Shared/Tok/_TokTypesNewContent.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ba46829bbb239bf192093e3fc0bf62e1c59ba7bf", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Tok__TokTypesNewContent : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BrowseViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Tok", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "toktype", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokTypesNewContent.cshtml"
  
    var tokgroups_basic = new List<TokTypeList>();
    var tokgroups_detailed = new List<TokTypeList>();
    var groups_basic = new List<TokTypeListCounter>();
    var groups_detailed = new List<TokTypeListCounter>();

    var colorIndex = 0;
    var materialColors = new List<string> { "f44336", "E91E63", "9C27B0", "673AB7", "3F51B5", "2196F3", "03A9F4", "00BCD4", "009688", "4CAF50", "8BC34A", "CDDC39", "efdc3c", "FFC107", "FF9800", "FF5722" };
    var materialLightColors = new List<string> { "ef9a9a", "F48FB1", "CE93D8", "B39DDB", "9FA8DA", "90CAF9", "81D4FA", "80DEEA", "80CBC4", "A5D6A7", "C5E1A5", "E6EE9C", "FFF59D", "FFE082", "FFCC80", "FFAB91" };

#line default
#line hidden
            BeginContext(722, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 14 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokTypesNewContent.cshtml"
 for (var s = 0; s < Model.TokGroups.Count; ++s)
{
    var tokgroup = Model.TokGroups[s];
    var group = Model.Counters[s];

    if (tokgroup.IsDetailBased)
    {
        tokgroups_detailed.Add(tokgroup);
        groups_detailed.Add(group);
    }
    else
    {
        tokgroups_basic.Add(tokgroup);
        groups_basic.Add(group);
    }
}

#line default
#line hidden
            BeginContext(1083, 80, true);
            WriteLiteral("\r\n<div class=\"col-md-12\" style=\"background-color: white; border-radius: 8px;\">\r\n");
            EndContext();
            BeginContext(1187, 702, true);
            WriteLiteral(@"    <div class=""row"">
        <div class=""col-md-6"" style=""background-color: white; padding-top: 82px; border-radius: 8px;"">
            <div style=""border: 1px solid #5B83CC; position: absolute; top: 12px;  right: 0px; height: 100%""></div>
            <h1 class=""toktype-header"" style=""background-color: #2196F3; text-align: center;"">BASIC</h1>
            <div class=""divDetailed"" style=""padding-top: 12px; padding-right: 32px; position: absolute; top: 0px; width: 100%;height: 100%;"">
                <h1 class=""tokkepedia-title"" style=""background-color: #2196F3; text-align: center;"">BASIC</h1>
            </div>
            <hr style=""border-top: 4px solid #5B83CC;margin-right:-14px"" />
");
            EndContext();
#line 41 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokTypesNewContent.cshtml"
             for (int i = 0; i < tokgroups_basic.Count; ++i)
            {
                var item = tokgroups_basic[i];
                var g = groups_basic[i];
                if (colorIndex >= materialColors.Count) { colorIndex = 0; }


#line default
#line hidden
            BeginContext(2135, 119, true);
            WriteLiteral("                <div style=\"left: 31.5%; position: relative; width: 296px;text-align: center;\">\r\n                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2254, "\"", 2287, 2);
            WriteAttributeValue("", 2261, "/tokgroup?name=", 2261, 15, true);
#line 48 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokTypesNewContent.cshtml"
WriteAttributeValue("", 2276, g.TokGroup, 2276, 11, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2288, 86, true);
            WriteLiteral("><h3 class=\"toktype-link\" data-toggle=\"popover\" data-container=\"body\" data-title=\"<h5>");
            EndContext();
            BeginContext(2375, 10, false);
#line 48 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokTypesNewContent.cshtml"
                                                                                                                                         Write(g.TokGroup);

#line default
#line hidden
            EndContext();
            BeginContext(2385, 46, true);
            WriteLiteral("</h5>\" data-content=\"<p style=\'color: black;\'>");
            EndContext();
            BeginContext(2432, 16, false);
#line 48 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokTypesNewContent.cshtml"
                                                                                                                                                                                                  Write(item.Description);

#line default
#line hidden
            EndContext();
            BeginContext(2448, 49, true);
            WriteLiteral("</p>\" data-placement=\"right\" data-trigger=\"hover\"");
            EndContext();
            BeginWriteAttribute("style", " style=\"", 2497, "\"", 2622, 13);
            WriteAttributeValue("", 2505, "padding:", 2505, 8, true);
            WriteAttributeValue(" ", 2513, "12px", 2514, 5, true);
            WriteAttributeValue(" ", 2518, "8px;", 2519, 5, true);
            WriteAttributeValue(" ", 2523, "background-color:", 2524, 18, true);
            WriteAttributeValue(" ", 2541, "#", 2542, 2, true);
#line 48 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokTypesNewContent.cshtml"
WriteAttributeValue("", 2543, materialColors[colorIndex], 2543, 27, false);

#line default
#line hidden
            WriteAttributeValue("", 2570, ";", 2570, 1, true);
            WriteAttributeValue(" ", 2571, "border:", 2572, 8, true);
            WriteAttributeValue(" ", 2579, "1px", 2580, 4, true);
            WriteAttributeValue(" ", 2583, "solid", 2584, 6, true);
            WriteAttributeValue(" ", 2589, "#2F528F;color:", 2590, 15, true);
            WriteAttributeValue(" ", 2604, "white", 2605, 6, true);
            WriteAttributeValue(" ", 2610, "!important;", 2611, 12, true);
            EndWriteAttribute();
            BeginContext(2623, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(2625, 13, false);
#line 48 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokTypesNewContent.cshtml"
                                                                                                                                                                                                                                                                                                                                                                                                   Write(item.TokGroup);

#line default
#line hidden
            EndContext();
            BeginContext(2638, 68, true);
            WriteLiteral("</h3></a>\r\n                    <div>\r\n                        <ol>\r\n");
            EndContext();
#line 51 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokTypesNewContent.cshtml"
                             for (int x = 0; x < g.TokTypes.Length; ++x)
                            {
                                var typeId = item.TokTypeIds[x].ToString();

#line default
#line hidden
            BeginContext(2888, 72, true);
            WriteLiteral("                                <li style=\"padding: 6px 24px 2px 24px;\">");
            EndContext();
            BeginContext(2960, 439, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "236b59f3a9954b688aeed06770528744", async() => {
                BeginContext(3028, 86, true);
                WriteLiteral("<h4  class=\"toktype-link\" data-toggle=\"popover\" data-container=\"body\" data-title=\"<h5>");
                EndContext();
                BeginContext(3115, 13, false);
#line 54 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokTypesNewContent.cshtml"
                                                                                                                                                                                                                             Write(g.TokTypes[x]);

#line default
#line hidden
                EndContext();
                BeginContext(3128, 46, true);
                WriteLiteral("</h5>\" data-content=\"<p style=\'color: black;\'>");
                EndContext();
                BeginContext(3175, 20, false);
#line 54 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokTypesNewContent.cshtml"
                                                                                                                                                                                                                                                                                         Write(item.Descriptions[x]);

#line default
#line hidden
                EndContext();
                BeginContext(3195, 49, true);
                WriteLiteral("</p>\" data-placement=\"right\" data-trigger=\"hover\"");
                EndContext();
                BeginWriteAttribute("style", " style=\"", 3244, "\"", 3374, 13);
                WriteAttributeValue("", 3252, "padding:", 3252, 8, true);
                WriteAttributeValue(" ", 3260, "12px", 3261, 5, true);
                WriteAttributeValue(" ", 3265, "8px;", 3266, 5, true);
                WriteAttributeValue(" ", 3270, "border:", 3271, 8, true);
                WriteAttributeValue(" ", 3278, "1px", 3279, 4, true);
                WriteAttributeValue(" ", 3282, "solid", 3283, 6, true);
                WriteAttributeValue(" ", 3288, "#2F528F;", 3289, 9, true);
                WriteAttributeValue(" ", 3297, "background-color:", 3298, 18, true);
                WriteAttributeValue(" ", 3315, "#", 3316, 2, true);
#line 54 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokTypesNewContent.cshtml"
WriteAttributeValue("", 3317, materialLightColors[colorIndex], 3317, 32, false);

#line default
#line hidden
                WriteAttributeValue("", 3349, ";color:", 3349, 7, true);
                WriteAttributeValue(" ", 3356, "white", 3357, 6, true);
                WriteAttributeValue(" ", 3362, "!important;", 3363, 12, true);
                EndWriteAttribute();
                BeginContext(3375, 1, true);
                WriteLiteral(">");
                EndContext();
                BeginContext(3377, 13, false);
#line 54 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokTypesNewContent.cshtml"
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   Write(g.TokTypes[x]);

#line default
#line hidden
                EndContext();
                BeginContext(3390, 5, true);
                WriteLiteral("</h4>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 54 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokTypesNewContent.cshtml"
                                                                                                                       WriteLiteral(typeId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3399, 7, true);
            WriteLiteral("</li>\r\n");
            EndContext();
#line 55 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokTypesNewContent.cshtml"
                            }

#line default
#line hidden
            BeginContext(3437, 107, true);
            WriteLiteral("                        </ol>\r\n                    </div>\r\n                </div>\r\n                <br />\r\n");
            EndContext();
#line 60 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokTypesNewContent.cshtml"
                colorIndex += 1;
            }

#line default
#line hidden
            BeginContext(3593, 699, true);
            WriteLiteral(@"        </div>
        <div class=""col-md-6"" style=""padding-top: 82px; background-color: white; border-radius: 8px;"">
            <div style=""border: 1px solid #5B83CC; position: absolute; top: 12px; left: 0px; height: 100%""></div>
            <h1 class=""toktype-header"" style=""background-color: #283593; text-align: center;"">DETAILED</h1>
            <div class=""divDetailed"" style=""padding-top: 12px; padding-right: 32px; position: absolute; top: 0px; width: 100%;height: 100%;"">
                <h1 class=""tokkepedia-title"" style=""background-color: #283593; text-align: center;"">DETAILED</h1>
            </div>
            <hr style=""border-top: 4px solid #5B83CC;margin-left:-14px;"" />
");
            EndContext();
#line 70 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokTypesNewContent.cshtml"
             for (int i = 0; i < tokgroups_detailed.Count; ++i)
            {
                var item = tokgroups_detailed[i];
                var g = groups_detailed[i];
                if (colorIndex >= materialColors.Count) { colorIndex = 0; }


#line default
#line hidden
            BeginContext(4547, 128, true);
            WriteLiteral("                <div style=\"left: 31.5%; position: relative;width: 296px; text-align: center;\">\r\n                    <a style=\"\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 4675, "\"", 4708, 2);
            WriteAttributeValue("", 4682, "/tokgroup?name=", 4682, 15, true);
#line 77 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokTypesNewContent.cshtml"
WriteAttributeValue("", 4697, g.TokGroup, 4697, 11, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4709, 86, true);
            WriteLiteral("><h3 class=\"toktype-link\" data-toggle=\"popover\" data-container=\"body\" data-title=\"<h5>");
            EndContext();
            BeginContext(4796, 10, false);
#line 77 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokTypesNewContent.cshtml"
                                                                                                                                                  Write(g.TokGroup);

#line default
#line hidden
            EndContext();
            BeginContext(4806, 46, true);
            WriteLiteral("</h5>\" data-content=\"<p style=\'color: black;\'>");
            EndContext();
            BeginContext(4853, 16, false);
#line 77 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokTypesNewContent.cshtml"
                                                                                                                                                                                                           Write(item.Description);

#line default
#line hidden
            EndContext();
            BeginContext(4869, 49, true);
            WriteLiteral("</p>\" data-placement=\"right\" data-trigger=\"hover\"");
            EndContext();
            BeginWriteAttribute("style", " style=\"", 4918, "\"", 5043, 13);
            WriteAttributeValue("", 4926, "padding:", 4926, 8, true);
            WriteAttributeValue(" ", 4934, "12px", 4935, 5, true);
            WriteAttributeValue(" ", 4939, "8px;", 4940, 5, true);
            WriteAttributeValue(" ", 4944, "background-color:", 4945, 18, true);
            WriteAttributeValue(" ", 4962, "#", 4963, 2, true);
#line 77 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokTypesNewContent.cshtml"
WriteAttributeValue("", 4964, materialColors[colorIndex], 4964, 27, false);

#line default
#line hidden
            WriteAttributeValue("", 4991, ";", 4991, 1, true);
            WriteAttributeValue(" ", 4992, "border:", 4993, 8, true);
            WriteAttributeValue(" ", 5000, "1px", 5001, 4, true);
            WriteAttributeValue(" ", 5004, "solid", 5005, 6, true);
            WriteAttributeValue(" ", 5010, "#2F528F;color:", 5011, 15, true);
            WriteAttributeValue(" ", 5025, "white", 5026, 6, true);
            WriteAttributeValue(" ", 5031, "!important;", 5032, 12, true);
            EndWriteAttribute();
            BeginContext(5044, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(5046, 13, false);
#line 77 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokTypesNewContent.cshtml"
                                                                                                                                                                                                                                                                                                                                                                                                            Write(item.TokGroup);

#line default
#line hidden
            EndContext();
            BeginContext(5059, 68, true);
            WriteLiteral("</h3></a>\r\n                    <div>\r\n                        <ol>\r\n");
            EndContext();
#line 80 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokTypesNewContent.cshtml"
                             for (int x = 0; x < g.TokTypes.Length; ++x)
                            {
                                var typeId = item.TokTypeIds[x].ToString();

#line default
#line hidden
            BeginContext(5309, 72, true);
            WriteLiteral("                                <li style=\"padding: 6px 24px 2px 24px;\">");
            EndContext();
            BeginContext(5381, 504, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bd95e9cdbae940cf96da083f9f039bbb", async() => {
                BeginContext(5449, 85, true);
                WriteLiteral("<h4 class=\"toktype-link\" data-toggle=\"popover\" data-container=\"body\" data-title=\"<h5>");
                EndContext();
                BeginContext(5535, 13, false);
#line 83 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokTypesNewContent.cshtml"
                                                                                                                                                                                                                            Write(g.TokTypes[x]);

#line default
#line hidden
                EndContext();
                BeginContext(5548, 46, true);
                WriteLiteral("</h5>\" data-content=\"<p style=\'color: black;\'>");
                EndContext();
                BeginContext(5595, 20, false);
#line 83 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokTypesNewContent.cshtml"
                                                                                                                                                                                                                                                                                        Write(item.Descriptions[x]);

#line default
#line hidden
                EndContext();
                BeginContext(5615, 50, true);
                WriteLiteral("</p><p style=\'font-style: italic;\'>Example: <br />");
                EndContext();
                BeginContext(5666, 16, false);
#line 83 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokTypesNewContent.cshtml"
                                                                                                                                                                                                                                                                                                                                                               Write(item.Examples[x]);

#line default
#line hidden
                EndContext();
                BeginContext(5682, 49, true);
                WriteLiteral("</p>\" data-placement=\"right\" data-trigger=\"hover\"");
                EndContext();
                BeginWriteAttribute("style", " style=\"", 5731, "\"", 5860, 12);
                WriteAttributeValue("", 5739, "padding:", 5739, 8, true);
                WriteAttributeValue(" ", 5747, "12px", 5748, 5, true);
                WriteAttributeValue(" ", 5752, "8px;background-color:", 5753, 22, true);
                WriteAttributeValue(" ", 5774, "#", 5775, 2, true);
#line 83 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokTypesNewContent.cshtml"
WriteAttributeValue("", 5776, materialLightColors[colorIndex], 5776, 32, false);

#line default
#line hidden
                WriteAttributeValue("", 5808, ";", 5808, 1, true);
                WriteAttributeValue(" ", 5809, "border:", 5810, 8, true);
                WriteAttributeValue(" ", 5817, "1px", 5818, 4, true);
                WriteAttributeValue(" ", 5821, "solid", 5822, 6, true);
                WriteAttributeValue(" ", 5827, "#2F528F;color:", 5828, 15, true);
                WriteAttributeValue(" ", 5842, "white", 5843, 6, true);
                WriteAttributeValue(" ", 5848, "!important;", 5849, 12, true);
                EndWriteAttribute();
                BeginContext(5861, 1, true);
                WriteLiteral(">");
                EndContext();
                BeginContext(5863, 13, false);
#line 83 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokTypesNewContent.cshtml"
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    Write(g.TokTypes[x]);

#line default
#line hidden
                EndContext();
                BeginContext(5876, 5, true);
                WriteLiteral("</h4>");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 83 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokTypesNewContent.cshtml"
                                                                                                                       WriteLiteral(typeId);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5885, 7, true);
            WriteLiteral("</li>\r\n");
            EndContext();
#line 84 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokTypesNewContent.cshtml"
                            }

#line default
#line hidden
            BeginContext(5923, 107, true);
            WriteLiteral("                        </ol>\r\n                    </div>\r\n                </div>\r\n                <br />\r\n");
            EndContext();
#line 89 "C:\Users\bonqu\source\github\TokkepediaWeb\Tokkepedia\Views\Shared\Tok\_TokTypesNewContent.cshtml"
                colorIndex += 1;
            }

#line default
#line hidden
            BeginContext(6079, 1411, true);
            WriteLiteral(@"        </div>
    </div>
</div>

<script>
    $(document).ready(function () {
        var titleWidth = $('.tokkepedia-title').outerWidth() + 0;
        $('.toktype-header').css('width', titleWidth + 'px');

        // Popover
        $("".toktype-link"").popover({
            html: true,
            delay: { show: 300, hide: 100 }
        });

        // For Header
        $(window).scroll(function () {

            var target = $(window).scrollTop();
            var alturaA = $('.divDetailed').offset().top;
            var alturaB = alturaA + $('.divDetailed').height() - 32 - $('.tokkepedia-title').height();

            //console.log(target + ' ' + alturaA + ' ' + alturaB);
            if (target > alturaB) {
                //$('.tokkepedia-title').css('margin-top', (alturaB - alturaA) + 64 + 'px');
                $('.tokkepedia-title').hide();
                $('.toktype-header').show();
            } else if (target > alturaA && target < alturaB) {
                //$('.tokkep");
            WriteLiteral(@"edia-title').css('margin-top', (target - alturaA) + 64 + 'px');
                $('.tokkepedia-title').hide();
                $('.toktype-header').show();
            } else {
                //$('.tokkepedia-title').css('margin-top', '0');
                $('.tokkepedia-title').show();
                $('.toktype-header').hide();
            }
        });
    });
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BrowseViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591