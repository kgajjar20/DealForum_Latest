#pragma checksum "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Role\_RequestRole.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4deff842785b735a9e4cda1d3ca4d8ca3ed24411"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Role__RequestRole), @"mvc.1.0.view", @"/Areas/Admin/Views/Role/_RequestRole.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4deff842785b735a9e4cda1d3ca4d8ca3ed24411", @"/Areas/Admin/Views/Role/_RequestRole.cshtml")]
    public class Areas_Admin_Views_Role__RequestRole : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DealForumLibrary.Models.AdminAreaModels.AddEditRoleDetail>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Role\_RequestRole.cshtml"
  
    string ButtonName = "Save";
    if (Model.Id != null && Model.Id > 0)
    {
        ButtonName = "Update";
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 10 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Role\_RequestRole.cshtml"
 using (Html.BeginForm("AddUpdateRole", "Role", FormMethod.Post, new { @id = "frmAddUpdateRole", @enctype = "multipart/form-data" }))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Role\_RequestRole.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Role\_RequestRole.cshtml"
Write(Html.HiddenFor(m => m.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row gutter-20\">\r\n        <div class=\"col-sm-12\">\r\n            <div class=\"form-group\">\r\n                <label");
            BeginWriteAttribute("for", " for=\"", 523, "\"", 529, 0);
            EndWriteAttribute();
            WriteLiteral(">Role Name<span class=\"required\">*</span></label>\r\n                ");
#nullable restore
#line 18 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Role\_RequestRole.cshtml"
           Write(Html.TextBoxFor(m => m.Name, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 19 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Role\_RequestRole.cshtml"
           Write(Html.ValidationMessageFor(a => a.Name, "", new { @style = "color:red" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div class=\"col-sm-12\">\r\n            <div class=\"form-group\">\r\n                <label");
            BeginWriteAttribute("for", " for=\"", 881, "\"", 887, 0);
            EndWriteAttribute();
            WriteLiteral(">Description</label>\r\n                ");
#nullable restore
#line 25 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Role\_RequestRole.cshtml"
           Write(Html.TextAreaFor(m => m.Description, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 26 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Role\_RequestRole.cshtml"
           Write(Html.ValidationMessageFor(a => a.Description, "", new { @style = "color:red" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <div class=\"modal-footer\">\r\n        <button type=\"button\" id=\"btnSave\" class=\"btn btn-primary btn-sm mtp5\" onclick=\"SaveRole();\"");
            BeginWriteAttribute("title", " title=\"", 1276, "\"", 1295, 1);
#nullable restore
#line 31 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Role\_RequestRole.cshtml"
WriteAttributeValue("", 1284, ButtonName, 1284, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 31 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Role\_RequestRole.cshtml"
                                                                                                                    Write(ButtonName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</button>\r\n        <button type=\"button\" class=\"btn btn-secondary btn-sm mtp5\" data-dismiss=\"modal\" title=\"Cancel\">Cancel</button>\r\n    </div>\r\n");
#nullable restore
#line 34 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Role\_RequestRole.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DealForumLibrary.Models.AdminAreaModels.AddEditRoleDetail> Html { get; private set; }
    }
}
#pragma warning restore 1591
