#pragma checksum "D:\works\DotNetTest\SampleShop\SampleShop\Views\Items\cart.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fa15fadd55856a27eb69b683c9bc99b416a6e07e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Items_cart), @"mvc.1.0.view", @"/Views/Items/cart.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Items/cart.cshtml", typeof(AspNetCore.Views_Items_cart))]
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
#line 1 "D:\works\DotNetTest\SampleShop\SampleShop\Views\_ViewImports.cshtml"
using SampleShop;

#line default
#line hidden
#line 2 "D:\works\DotNetTest\SampleShop\SampleShop\Views\_ViewImports.cshtml"
using SampleShop.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fa15fadd55856a27eb69b683c9bc99b416a6e07e", @"/Views/Items/cart.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b6576b42986e32e330afafd25f0ecc49e3bb6f9c", @"/Views/_ViewImports.cshtml")]
    public class Views_Items_cart : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SampleShop.Models.Item>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "RemoveFromCartInCart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(44, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "D:\works\DotNetTest\SampleShop\SampleShop\Views\Items\cart.cshtml"
  
    ViewData["Title"] = "cart";

#line default
#line hidden
            BeginContext(86, 103, true);
            WriteLiteral("\r\n<h2>cart</h2>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(190, 47, false);
#line 13 "D:\works\DotNetTest\SampleShop\SampleShop\Views\Items\cart.cshtml"
           Write(Html.DisplayNameFor(model => model.description));

#line default
#line hidden
            EndContext();
            BeginContext(237, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(293, 40, false);
#line 16 "D:\works\DotNetTest\SampleShop\SampleShop\Views\Items\cart.cshtml"
           Write(Html.DisplayNameFor(model => model.name));

#line default
#line hidden
            EndContext();
            BeginContext(333, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(389, 41, false);
#line 19 "D:\works\DotNetTest\SampleShop\SampleShop\Views\Items\cart.cshtml"
           Write(Html.DisplayNameFor(model => model.price));

#line default
#line hidden
            EndContext();
            BeginContext(430, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(486, 48, false);
#line 22 "D:\works\DotNetTest\SampleShop\SampleShop\Views\Items\cart.cshtml"
           Write(Html.DisplayNameFor(model => model.NumAvailable));

#line default
#line hidden
            EndContext();
            BeginContext(534, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(590, 46, false);
#line 25 "D:\works\DotNetTest\SampleShop\SampleShop\Views\Items\cart.cshtml"
           Write(Html.DisplayNameFor(model => model.picAddress));

#line default
#line hidden
            EndContext();
            BeginContext(636, 86, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 31 "D:\works\DotNetTest\SampleShop\SampleShop\Views\Items\cart.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
            BeginContext(754, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(803, 46, false);
#line 34 "D:\works\DotNetTest\SampleShop\SampleShop\Views\Items\cart.cshtml"
           Write(Html.DisplayFor(modelItem => item.description));

#line default
#line hidden
            EndContext();
            BeginContext(849, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(905, 39, false);
#line 37 "D:\works\DotNetTest\SampleShop\SampleShop\Views\Items\cart.cshtml"
           Write(Html.DisplayFor(modelItem => item.name));

#line default
#line hidden
            EndContext();
            BeginContext(944, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1000, 40, false);
#line 40 "D:\works\DotNetTest\SampleShop\SampleShop\Views\Items\cart.cshtml"
           Write(Html.DisplayFor(modelItem => item.price));

#line default
#line hidden
            EndContext();
            BeginContext(1040, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1096, 47, false);
#line 43 "D:\works\DotNetTest\SampleShop\SampleShop\Views\Items\cart.cshtml"
           Write(Html.DisplayFor(modelItem => item.NumAvailable));

#line default
#line hidden
            EndContext();
            BeginContext(1143, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1199, 45, false);
#line 46 "D:\works\DotNetTest\SampleShop\SampleShop\Views\Items\cart.cshtml"
           Write(Html.DisplayFor(modelItem => item.picAddress));

#line default
#line hidden
            EndContext();
            BeginContext(1244, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1299, 79, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a921de2995014bb3bf9749b528c97596", async() => {
                BeginContext(1360, 14, true);
                WriteLiteral("RemoveFromCart");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 49 "D:\works\DotNetTest\SampleShop\SampleShop\Views\Items\cart.cshtml"
                                                       WriteLiteral(item.Id);

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
            BeginContext(1378, 36, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 52 "D:\works\DotNetTest\SampleShop\SampleShop\Views\Items\cart.cshtml"
}

#line default
#line hidden
            BeginContext(1417, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SampleShop.Models.Item>> Html { get; private set; }
    }
}
#pragma warning restore 1591
