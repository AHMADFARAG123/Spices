#pragma checksum "F:\MVC Core\projects\Spices\Spices\Areas\Admin\Views\MenuItems\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8d5671617a5065939936fe5e2aa5fd0cc5a715f1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_MenuItems_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/MenuItems/Index.cshtml")]
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
#nullable restore
#line 1 "F:\MVC Core\projects\Spices\Spices\Areas\Admin\Views\_ViewImports.cshtml"
using Spices;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\MVC Core\projects\Spices\Spices\Areas\Admin\Views\_ViewImports.cshtml"
using Spices.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "F:\MVC Core\projects\Spices\Spices\Areas\Admin\Views\_ViewImports.cshtml"
using Spices.Models.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8d5671617a5065939936fe5e2aa5fd0cc5a715f1", @"/Areas/Admin/Views/MenuItems/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8b4197b9bd7e1ebb74cba867abd8727b93025b6e", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_MenuItems_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<MenItem>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_CreateButtonPartail", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_OperationsButtonPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
#nullable restore
#line 2 "F:\MVC Core\projects\Spices\Spices\Areas\Admin\Views\MenuItems\Index.cshtml"
  
    ViewData["Title"] = "Index";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n<div class=\"whiteBackGround\">\r\n    <!-- lecture4 19:30 -->\r\n    <div class=\"row\">\r\n        <div class=\"col-6\">\r\n            <h2 class=\"text-info\">Menu Items List</h2>\r\n        </div>\r\n\r\n        <div class=\"col-6 text-right\">\r\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "8d5671617a5065939936fe5e2aa5fd0cc5a715f14453", async() => {
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
            WriteLiteral("\r\n\r\n\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 22 "F:\MVC Core\projects\Spices\Spices\Areas\Admin\Views\MenuItems\Index.cshtml"
     if (Model.Count() == 0)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p class=\"text-danger\">No Menu Items....</p>\r\n");
#nullable restore
#line 25 "F:\MVC Core\projects\Spices\Spices\Areas\Admin\Views\MenuItems\Index.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <table class=\"table table-striped border\">\r\n            <tr class=\"table-secondary\">\r\n                <th>\r\n                    ");
#nullable restore
#line 31 "F:\MVC Core\projects\Spices\Spices\Areas\Admin\Views\MenuItems\Index.cshtml"
               Write(Html.DisplayNameFor(m => m.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("  <!-- lecture4 19:30 -->\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 34 "F:\MVC Core\projects\Spices\Spices\Areas\Admin\Views\MenuItems\Index.cshtml"
               Write(Html.DisplayNameFor(m => m.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 37 "F:\MVC Core\projects\Spices\Spices\Areas\Admin\Views\MenuItems\Index.cshtml"
               Write(Html.DisplayNameFor(m => m.CATEGOry.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("      <!--  فى المحاضره عاملها كاتيجورى اى دى  lecture4 20:00 -->\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 40 "F:\MVC Core\projects\Spices\Spices\Areas\Admin\Views\MenuItems\Index.cshtml"
               Write(Html.DisplayNameFor(m => m.SUBcategory.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("   <!--  فى المحاضره عاملها صب كاتيجورى فقط-->\r\n\r\n                <th>\r\n                    ");
#nullable restore
#line 43 "F:\MVC Core\projects\Spices\Spices\Areas\Admin\Views\MenuItems\Index.cshtml"
               Write(Html.DisplayNameFor(m => m.image));

#line default
#line hidden
#nullable disable
            WriteLiteral("   <!--من عندى هو كان سايبها فاضيه-->\r\n                </th>\r\n                <th>\r\n\r\n\r\n\r\n                </th>\r\n\r\n            </tr>\r\n");
#nullable restore
#line 52 "F:\MVC Core\projects\Spices\Spices\Areas\Admin\Views\MenuItems\Index.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n\r\n                        ");
#nullable restore
#line 57 "F:\MVC Core\projects\Spices\Spices\Areas\Admin\Views\MenuItems\Index.cshtml"
                   Write(Html.DisplayFor(m => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n\r\n                        ");
#nullable restore
#line 61 "F:\MVC Core\projects\Spices\Spices\Areas\Admin\Views\MenuItems\Index.cshtml"
                   Write(Html.DisplayFor(m => item.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n\r\n                        ");
#nullable restore
#line 65 "F:\MVC Core\projects\Spices\Spices\Areas\Admin\Views\MenuItems\Index.cshtml"
                   Write(Html.DisplayFor(m => item.CATEGOry.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n\r\n                        ");
#nullable restore
#line 69 "F:\MVC Core\projects\Spices\Spices\Areas\Admin\Views\MenuItems\Index.cshtml"
                   Write(Html.DisplayFor(m => item.SUBcategory.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n\r\n                        <img");
            BeginWriteAttribute("src", " src=\"", 1999, "\"", 2016, 1);
#nullable restore
#line 73 "F:\MVC Core\projects\Spices\Spices\Areas\Admin\Views\MenuItems\Index.cshtml"
WriteAttributeValue("", 2005, item.image, 2005, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("  width=\"50\" />  <!--lecture4    1:05:00 -->\r\n\r\n\r\n                    </td>\r\n\r\n                    <td style=\"width:150px\">\r\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "8d5671617a5065939936fe5e2aa5fd0cc5a715f110277", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#nullable restore
#line 79 "F:\MVC Core\projects\Spices\Spices\Areas\Admin\Views\MenuItems\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = item.ID;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 83 "F:\MVC Core\projects\Spices\Spices\Areas\Admin\Views\MenuItems\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </table>\r\n");
#nullable restore
#line 86 "F:\MVC Core\projects\Spices\Spices\Areas\Admin\Views\MenuItems\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n        </div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<MenItem>> Html { get; private set; }
    }
}
#pragma warning restore 1591