#pragma checksum "C:\Users\Paul\Desktop\Файли по предметам\3 курс\1 семестр\SocialNetwork\SocialNetwork.PL\Views\Autorization\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1e0e1a108126a681c546f4344f07781049dedb69"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Autorization_Index), @"mvc.1.0.view", @"/Views/Autorization/Index.cshtml")]
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
#line 1 "C:\Users\Paul\Desktop\Файли по предметам\3 курс\1 семестр\SocialNetwork\SocialNetwork.PL\Views\_ViewImports.cshtml"
using SocialNetwork.PL;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Paul\Desktop\Файли по предметам\3 курс\1 семестр\SocialNetwork\SocialNetwork.PL\Views\_ViewImports.cshtml"
using SocialNetwork.PL.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1e0e1a108126a681c546f4344f07781049dedb69", @"/Views/Autorization/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1b844bd54315a1d068268e12f22c3c0518b9434f", @"/Views/_ViewImports.cshtml")]
    public class Views_Autorization_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<SocialNetwork.PL.Models.UsersViewModel>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Users\Paul\Desktop\Файли по предметам\3 курс\1 семестр\SocialNetwork\SocialNetwork.PL\Views\Autorization\Index.cshtml"
  
    ViewBag.Title = "Autorization";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!DOCTYPE html>\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1e0e1a108126a681c546f4344f07781049dedb693738", async() => {
                WriteLiteral("\r\n    <title>Autorisation</title>\r\n    <meta charset=\"utf-8\"/>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1e0e1a108126a681c546f4344f07781049dedb694772", async() => {
                WriteLiteral("\r\n    <table align=\"center\">\r\n        <tr>\r\n            <th>LOGIN</th>\r\n        </tr>\r\n\r\n        <tr>\r\n            <td>\r\n");
#nullable restore
#line 25 "C:\Users\Paul\Desktop\Файли по предметам\3 курс\1 семестр\SocialNetwork\SocialNetwork.PL\Views\Autorization\Index.cshtml"
                 using (Html.BeginForm("LoginUser", "Autorization"))
                {
                    

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "C:\Users\Paul\Desktop\Файли по предметам\3 курс\1 семестр\SocialNetwork\SocialNetwork.PL\Views\Autorization\Index.cshtml"
               Write(Html.TextBoxFor(model => model.Email, new { placeholder = "E-mail", @type = "name" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("<br>\r\n");
#nullable restore
#line 28 "C:\Users\Paul\Desktop\Файли по предметам\3 курс\1 семестр\SocialNetwork\SocialNetwork.PL\Views\Autorization\Index.cshtml"
               Write(Html.TextBoxFor(model => model.Password, new { placeholder = "Password", @type = "password" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("<br>\r\n                    <input type=\"submit\" name=\"login\" value=\"Login\" />\r\n");
#nullable restore
#line 30 "C:\Users\Paul\Desktop\Файли по предметам\3 курс\1 семестр\SocialNetwork\SocialNetwork.PL\Views\Autorization\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("            </td>           \r\n        </tr>\r\n    </table>\r\n\r\n");
#nullable restore
#line 35 "C:\Users\Paul\Desktop\Файли по предметам\3 курс\1 семестр\SocialNetwork\SocialNetwork.PL\Views\Autorization\Index.cshtml"
     if (!string.IsNullOrWhiteSpace(ViewBag.Result))
    {

#line default
#line hidden
#nullable disable
                WriteLiteral("        <h3 align=\"center\">");
#nullable restore
#line 37 "C:\Users\Paul\Desktop\Файли по предметам\3 курс\1 семестр\SocialNetwork\SocialNetwork.PL\Views\Autorization\Index.cshtml"
                      Write(ViewBag.Result);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h3>\r\n");
#nullable restore
#line 38 "C:\Users\Paul\Desktop\Файли по предметам\3 курс\1 семестр\SocialNetwork\SocialNetwork.PL\Views\Autorization\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<SocialNetwork.PL.Models.UsersViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
