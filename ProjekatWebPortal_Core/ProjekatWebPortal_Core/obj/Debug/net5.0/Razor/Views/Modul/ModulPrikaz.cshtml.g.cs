#pragma checksum "C:\Users\nikol\Desktop\ProjekatWebPortal_Core\ProjekatWebPortal_Core\ProjekatWebPortal_Core\Views\Modul\ModulPrikaz.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3b4b285f32c55c959a9b15d7c0a873209d8fdae4"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Modul_ModulPrikaz), @"mvc.1.0.view", @"/Views/Modul/ModulPrikaz.cshtml")]
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
#line 1 "C:\Users\nikol\Desktop\ProjekatWebPortal_Core\ProjekatWebPortal_Core\ProjekatWebPortal_Core\Views\_ViewImports.cshtml"
using ProjekatWebPortal_Core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\nikol\Desktop\ProjekatWebPortal_Core\ProjekatWebPortal_Core\ProjekatWebPortal_Core\Views\_ViewImports.cshtml"
using ProjekatWebPortal_Core.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3b4b285f32c55c959a9b15d7c0a873209d8fdae4", @"/Views/Modul/ModulPrikaz.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6fcf4eb3f441ff7d7d92df9b08f3a80beae8ece2", @"/Views/_ViewImports.cshtml")]
    public class Views_Modul_ModulPrikaz : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<ProjekatWebPortal_Core.Models.ModulModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Content/img/uredi.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("uredi"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Content/img/obrisi.png"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\nikol\Desktop\ProjekatWebPortal_Core\ProjekatWebPortal_Core\ProjekatWebPortal_Core\Views\Modul\ModulPrikaz.cshtml"
  
    ViewBag.Title = "ModulPrikaz";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div id=\"sredina\">\r\n");
#nullable restore
#line 8 "C:\Users\nikol\Desktop\ProjekatWebPortal_Core\ProjekatWebPortal_Core\ProjekatWebPortal_Core\Views\Modul\ModulPrikaz.cshtml"
     if (this.User.IsInRole("SuperAdministrator") || this.User.IsInRole("LokalniUrednik"))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <a id=""novi-materijal"" href=""/Modul/DodajModul"">
            <svg width=""60"" height=""60"" xmlns=""http://www.w3.org/2000/svg"">
                <g>
                    <title>background</title>
                    <rect fill=""none"" id=""canvas_background"" height=""62"" width=""62"" y=""-1"" x=""-1"" />
                    <g display=""none"" overflow=""visible"" y=""0"" x=""0"" height=""100%"" width=""100%"" id=""canvasGrid"">
                        <rect fill=""url(#gridpattern)"" stroke-width=""0"" y=""0"" x=""0"" height=""100%"" width=""100%"" />
                    </g>
                </g>
                <g>
                    <title>Layer 1</title>
                    <rect id=""svg_4"" height=""26"" width=""3"" y=""17"" x=""28.5"" fill-opacity=""null"" stroke-opacity=""null"" stroke-width=""0"" stroke=""#000"" fill=""#fff"" />
                    <rect transform=""rotate(90, 29.898, 30)"" id=""svg_9"" height=""26"" width=""3"" y=""17"" x=""28.397959"" fill-opacity=""null"" stroke-opacity=""null"" stroke-width=""0"" stroke=""#000"" fill=""#fff"" />
         ");
            WriteLiteral("       </g>\r\n            </svg>\r\n        </a>\r\n");
#nullable restore
#line 26 "C:\Users\nikol\Desktop\ProjekatWebPortal_Core\ProjekatWebPortal_Core\ProjekatWebPortal_Core\Views\Modul\ModulPrikaz.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 28 "C:\Users\nikol\Desktop\ProjekatWebPortal_Core\ProjekatWebPortal_Core\ProjekatWebPortal_Core\Views\Modul\ModulPrikaz.cshtml"
     foreach (var modul in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"kartica-predmet clear-fix\"");
            BeginWriteAttribute("id", " id=\"", 1441, "\"", 1460, 1);
#nullable restore
#line 30 "C:\Users\nikol\Desktop\ProjekatWebPortal_Core\ProjekatWebPortal_Core\ProjekatWebPortal_Core\Views\Modul\ModulPrikaz.cshtml"
WriteAttributeValue("", 1446, modul.modulId, 1446, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n            <a class=\"naziv-predmeta-na-kartici\" href=\"#\">");
#nullable restore
#line 31 "C:\Users\nikol\Desktop\ProjekatWebPortal_Core\ProjekatWebPortal_Core\ProjekatWebPortal_Core\Views\Modul\ModulPrikaz.cshtml"
                                                     Write(modul.modulNaziv);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n            <div class=\"kontrole clear-fix\">\r\n");
#nullable restore
#line 33 "C:\Users\nikol\Desktop\ProjekatWebPortal_Core\ProjekatWebPortal_Core\ProjekatWebPortal_Core\Views\Modul\ModulPrikaz.cshtml"
                 if (this.User.IsInRole("SuperAdministrator") || this.User.IsInRole("LokalniUrednik"))
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <a");
            BeginWriteAttribute("href", " href=", 1736, "", 1778, 1);
#nullable restore
#line 35 "C:\Users\nikol\Desktop\ProjekatWebPortal_Core\ProjekatWebPortal_Core\ProjekatWebPortal_Core\Views\Modul\ModulPrikaz.cshtml"
WriteAttributeValue("", 1742, "/Modul/EditModul/"+modul.modulId, 1742, 36, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"kontrola-ikonica edit\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3b4b285f32c55c959a9b15d7c0a873209d8fdae48469", async() => {
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
            WriteLiteral("</a>\r\n                    <a href=\"#\" class=\"kontrola-ikonica dugme-delete\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "3b4b285f32c55c959a9b15d7c0a873209d8fdae49660", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</a>\r\n");
#nullable restore
#line 37 "C:\Users\nikol\Desktop\ProjekatWebPortal_Core\ProjekatWebPortal_Core\ProjekatWebPortal_Core\Views\Modul\ModulPrikaz.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                <a class=\"predmet-kontrole opis\" id=\"showOpis\" href=\"#\" data-opis=\"");
#nullable restore
#line 38 "C:\Users\nikol\Desktop\ProjekatWebPortal_Core\ProjekatWebPortal_Core\ProjekatWebPortal_Core\Views\Modul\ModulPrikaz.cshtml"
                                                                              Write(modul.modulOpis);

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-toggle=\"modal\" data-target=\"#opisModal\">OPIS</a>\r\n                ");
#nullable restore
#line 39 "C:\Users\nikol\Desktop\ProjekatWebPortal_Core\ProjekatWebPortal_Core\ProjekatWebPortal_Core\Views\Modul\ModulPrikaz.cshtml"
           Write(Html.ActionLink("MATERIJALI", "MaterijaliPrikaz", "Materijal", new { id = modul.modulId }, new { @class = "predmet-kontrole getMaterijali", tabindex = modul.modulId }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 83 "C:\Users\nikol\Desktop\ProjekatWebPortal_Core\ProjekatWebPortal_Core\ProjekatWebPortal_Core\Views\Modul\ModulPrikaz.cshtml"
               
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    <div class=""modal fade"" id=""opisModal"" role=""dialog"">
        <div class=""modal-dialog"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <button type=""button"" class=""close"" data-dismiss=""modal"">&times;</button>
                    <h4 class=""modal-title"">Opis modula <span>   </span></h4>
                </div>
                <div class=""modal-body"">
                    <p id=""PrikazOpis""></p>
                </div>
                <div class=""modal-footer"">
                    <button type=""button"" class=""btn btn-default"" data-dismiss=""modal"">Zatvori</button>
                </div>
            </div>
        </div>
    </div>
    <div class=""modal fade"" id=""deleteModal"" role=""dialog"">
        <div class=""modal-dialog"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <button type=""button"" class=""close"" data-dismiss=""modal"">&times;</button>
                    <h4 class=""moda");
            WriteLiteral(@"l-title"">Obavestenje <span>   </span></h4>
                </div>
                <div class=""modal-body"">
                    <p>Da li ste sigurni da želite da obrisete modul?</p>
                    <input type=""hidden"" id=""hiddenModulId"" />
                </div>
                <div class=""modal-footer"">
                    <button id=""deleteConfirm"" type=""button"" class=""btn btn-default"">Potvrdi</button>
                    <button type=""button"" class=""btn btn-secondary"" data-dismiss=""modal"">Odustani</button>
                </div>
            </div>
        </div>
    </div>
    <div id=""snackbar""><span>Modul uspešno izmenjen!</span></div>
    <div id=""snackbarDel""><span>Modul uspešno obrisan!</span></div>
</div>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<ProjekatWebPortal_Core.Models.ModulModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591