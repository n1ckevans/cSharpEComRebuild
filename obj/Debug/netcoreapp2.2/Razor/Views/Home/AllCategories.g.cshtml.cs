#pragma checksum "C:\Users\nicho\Documents\Coding\C#\ECom\Views\Home\AllCategories.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "aacc69d539eaaed5013a369ba5726668464dce65"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_AllCategories), @"mvc.1.0.view", @"/Views/Home/AllCategories.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/AllCategories.cshtml", typeof(AspNetCore.Views_Home_AllCategories))]
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
#line 1 "C:\Users\nicho\Documents\Coding\C#\ECom\Views\_ViewImports.cshtml"
using ECom;

#line default
#line hidden
#line 2 "C:\Users\nicho\Documents\Coding\C#\ECom\Views\_ViewImports.cshtml"
using ECom.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aacc69d539eaaed5013a369ba5726668464dce65", @"/Views/Home/AllCategories.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"59f42c956edbfeffa07a46f4daee388a2f956f35", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_AllCategories : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Category>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_Header", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(16, 1, true);
            WriteLiteral("\n");
            EndContext();
#line 3 "C:\Users\nicho\Documents\Coding\C#\ECom\Views\Home\AllCategories.cshtml"
  
    ViewData["Title"] = "All Products";

#line default
#line hidden
            BeginContext(62, 1, true);
            WriteLiteral("\n");
            EndContext();
            BeginContext(63, 24, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "aacc69d539eaaed5013a369ba5726668464dce653722", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(87, 78, true);
            WriteLiteral("</partial>\n\n<h3 class=\"text-center\">All Categories</h3>\n\n<div class=\"row\">\n\n\n\n");
            EndContext();
#line 15 "C:\Users\nicho\Documents\Coding\C#\ECom\Views\Home\AllCategories.cshtml"
   foreach (Category cat in ViewBag.AllCats)
{


#line default
#line hidden
            BeginContext(213, 190, true);
            WriteLiteral("     <div class=\"col-lg-4 col-md-6 mb-4\">\n            <div class=\"card h-100\">\n            \n              <div class=\"card-body\">\n                <h4 class=\"card-title\">\n                  <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 403, "\"", 435, 2);
            WriteAttributeValue("", 410, "/category/", 410, 10, true);
#line 23 "C:\Users\nicho\Documents\Coding\C#\ECom\Views\Home\AllCategories.cshtml"
WriteAttributeValue("", 420, cat.CategoryId, 420, 15, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(436, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(438, 8, false);
#line 23 "C:\Users\nicho\Documents\Coding\C#\ECom\Views\Home\AllCategories.cshtml"
                                                 Write(cat.Name);

#line default
#line hidden
            EndContext();
            BeginContext(446, 115, true);
            WriteLiteral("</a>\n                </h4>\n                \n              </div>\n             \n            </div>\n          </div>\n");
            EndContext();
#line 30 "C:\Users\nicho\Documents\Coding\C#\ECom\Views\Home\AllCategories.cshtml"

  
}

#line default
#line hidden
            BeginContext(567, 9, true);
            WriteLiteral("\n\n</div>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Category> Html { get; private set; }
    }
}
#pragma warning restore 1591