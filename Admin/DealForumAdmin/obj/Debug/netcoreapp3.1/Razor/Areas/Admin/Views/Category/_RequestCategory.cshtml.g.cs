#pragma checksum "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Category\_RequestCategory.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "cb40c34548ea426fc4aa083fb869ae09396ba66c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Category__RequestCategory), @"mvc.1.0.view", @"/Areas/Admin/Views/Category/_RequestCategory.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cb40c34548ea426fc4aa083fb869ae09396ba66c", @"/Areas/Admin/Views/Category/_RequestCategory.cshtml")]
    public class Areas_Admin_Views_Category__RequestCategory : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DealForumLibrary.Models.AdminAreaModels.AddEditCategoryDetail>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Category\_RequestCategory.cshtml"
  
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
#line 12 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Category\_RequestCategory.cshtml"
 using (Html.BeginForm("AddUpdateCategory", "Category", FormMethod.Post, new { @id = "frmAddUpdateCategory", @enctype = "multipart/form-data" }))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Category\_RequestCategory.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Category\_RequestCategory.cshtml"
Write(Html.HiddenFor(m => m.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row gutter-20\">\r\n\r\n        <div class=\"col-sm-12\">\r\n            <div class=\"form-group\">\r\n                <label");
            BeginWriteAttribute("for", " for=\"", 597, "\"", 603, 0);
            EndWriteAttribute();
            WriteLiteral(">Category Name<span class=\"required\">*</span></label>\r\n                ");
#nullable restore
#line 21 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Category\_RequestCategory.cshtml"
           Write(Html.TextBoxFor(m => m.Name, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 22 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Category\_RequestCategory.cshtml"
           Write(Html.ValidationMessageFor(a => a.Name, "", new { @style = "color:red" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div class=\"col-sm-12\">\r\n            <div class=\"form-group\">\r\n                <label");
            BeginWriteAttribute("for", " for=\"", 959, "\"", 965, 0);
            EndWriteAttribute();
            WriteLiteral(">Description</label>\r\n                ");
#nullable restore
#line 28 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Category\_RequestCategory.cshtml"
           Write(Html.TextAreaFor(m => m.Description, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 29 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Category\_RequestCategory.cshtml"
           Write(Html.ValidationMessageFor(a => a.Description, "", new { @style = "color:red" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <div class=\"modal-footer\">\r\n        <button type=\"button\" id=\"btnSave\" class=\"btn btn-primary btn-sm mtp5\" onclick=\"SaveCategory();\"");
            BeginWriteAttribute("title", " title=\"", 1358, "\"", 1377, 1);
#nullable restore
#line 34 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Category\_RequestCategory.cshtml"
WriteAttributeValue("", 1366, ButtonName, 1366, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 34 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Category\_RequestCategory.cshtml"
                                                                                                                        Write(ButtonName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</button>\r\n        <button type=\"button\" class=\"btn btn-secondary btn-sm mtp5\" data-dismiss=\"modal\" title=\"Cancel\">Cancel</button>\r\n    </div>\r\n");
#nullable restore
#line 37 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Category\_RequestCategory.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DealForumLibrary.Models.AdminAreaModels.AddEditCategoryDetail> Html { get; private set; }
    }
}
#pragma warning restore 1591
