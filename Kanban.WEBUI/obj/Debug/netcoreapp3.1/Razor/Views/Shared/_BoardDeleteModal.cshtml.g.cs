#pragma checksum "C:\Users\M\source\repos\Kanban\Kanban.WEBUI\Views\Shared\_BoardDeleteModal.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f69a4d2b782cf772d85eff15eb9200baf6bc7829"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__BoardDeleteModal), @"mvc.1.0.view", @"/Views/Shared/_BoardDeleteModal.cshtml")]
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
#line 1 "C:\Users\M\source\repos\Kanban\Kanban.WEBUI\Views\_ViewImports.cshtml"
using Kanban.WEBUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\M\source\repos\Kanban\Kanban.WEBUI\Views\_ViewImports.cshtml"
using Kanban.WEBUI.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f69a4d2b782cf772d85eff15eb9200baf6bc7829", @"/Views/Shared/_BoardDeleteModal.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b2af7db111df8c9c8b3c3c9990aca182eca068cd", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__BoardDeleteModal : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<div class=""modal fade"" tabindex=""-1"" role=""dialog"" aria-hidden=""true"" id=""board-delete-modal"">
	<div class=""modal-dialog modal-sm"">
		<div class=""modal-content"">
			<div class=""modal-header"">
				<h4 class=""modal-title"" id=""myModalLabel"">Are you sure?</h4>
				<button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close""><span aria-hidden=""true"">&times;</span></button>
			</div>
			<div class=""modal-footer"">
				<button type=""button"" class=""btn btn-danger"" id=""board-delete-modal-btn-yes"">Yes</button>
				<button type=""button"" class=""btn btn-primary"" id=""board-delete-modal-btn-no"">No</button>
			</div>
		</div>
	</div>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591