#pragma checksum "C:\Users\marec\Documents\ProjekatWebPortal_Core\ProjekatWebPortal_Core\ProjekatWebPortal_Core\Views\Shared\_LoginPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d94e9d870e7f50b5c71d158e98408612149102db"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__LoginPartial), @"mvc.1.0.view", @"/Views/Shared/_LoginPartial.cshtml")]
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
#line 1 "C:\Users\marec\Documents\ProjekatWebPortal_Core\ProjekatWebPortal_Core\ProjekatWebPortal_Core\Views\_ViewImports.cshtml"
using ProjekatWebPortal_Core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\marec\Documents\ProjekatWebPortal_Core\ProjekatWebPortal_Core\ProjekatWebPortal_Core\Views\_ViewImports.cshtml"
using ProjekatWebPortal_Core.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\marec\Documents\ProjekatWebPortal_Core\ProjekatWebPortal_Core\ProjekatWebPortal_Core\Views\Shared\_LoginPartial.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d94e9d870e7f50b5c71d158e98408612149102db", @"/Views/Shared/_LoginPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"64b24cbe118ff7de8355f02e77249fb49fad54ee", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__LoginPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 5 "C:\Users\marec\Documents\ProjekatWebPortal_Core\ProjekatWebPortal_Core\ProjekatWebPortal_Core\Views\Shared\_LoginPartial.cshtml"
 if (SignInManager.IsSignedIn(User))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h1>MAAAAAAAAAAANG</h1>\n");
#nullable restore
#line 8 "C:\Users\marec\Documents\ProjekatWebPortal_Core\ProjekatWebPortal_Core\ProjekatWebPortal_Core\Views\Shared\_LoginPartial.cshtml"


    using (Html.BeginForm("LogOff", "Account", FormMethod.Post, new { id = "logoutForm", @class = "navbar-right" }))
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\marec\Documents\ProjekatWebPortal_Core\ProjekatWebPortal_Core\ProjekatWebPortal_Core\Views\Shared\_LoginPartial.cshtml"
   Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("        <ul class=\"nav navbar-nav navbar-right\">\n            <li>\n");
            WriteLiteral("            </li>\n            <li><a href=\"javascript:document.getElementById(\'logoutForm\').submit()\">Log off</a></li>\n        </ul>\n");
#nullable restore
#line 21 "C:\Users\marec\Documents\ProjekatWebPortal_Core\ProjekatWebPortal_Core\ProjekatWebPortal_Core\Views\Shared\_LoginPartial.cshtml"
    }
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h1>HUAAAAAAAAAAAAAAAAA</h1>\n    <ul class=\"nav navbar-nav navbar-right\">\n        <li>");
#nullable restore
#line 27 "C:\Users\marec\Documents\ProjekatWebPortal_Core\ProjekatWebPortal_Core\ProjekatWebPortal_Core\Views\Shared\_LoginPartial.cshtml"
       Write(Html.ActionLink("Register", "Register", "Account", routeValues: null, htmlAttributes: new { id = "registerLink" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\n        <li>");
#nullable restore
#line 28 "C:\Users\marec\Documents\ProjekatWebPortal_Core\ProjekatWebPortal_Core\ProjekatWebPortal_Core\Views\Shared\_LoginPartial.cshtml"
       Write(Html.ActionLink("Log in", "Login", "Account", routeValues: null, htmlAttributes: new { id = "loginLink" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\n    </ul>\n");
#nullable restore
#line 30 "C:\Users\marec\Documents\ProjekatWebPortal_Core\ProjekatWebPortal_Core\ProjekatWebPortal_Core\Views\Shared\_LoginPartial.cshtml"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<IdentityUser> UserManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<IdentityUser> SignInManager { get; private set; }
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
