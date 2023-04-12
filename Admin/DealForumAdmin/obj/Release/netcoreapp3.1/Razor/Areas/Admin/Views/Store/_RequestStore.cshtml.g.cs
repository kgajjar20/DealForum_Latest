#pragma checksum "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Store\_RequestStore.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e31d6c9ed0a3daef4452afee2ac0f51159af7b65"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Store__RequestStore), @"mvc.1.0.view", @"/Areas/Admin/Views/Store/_RequestStore.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e31d6c9ed0a3daef4452afee2ac0f51159af7b65", @"/Areas/Admin/Views/Store/_RequestStore.cshtml")]
    public class Areas_Admin_Views_Store__RequestStore : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DealForumLibrary.Models.AdminAreaModels.AddEditStoreDetail>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 4 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Store\_RequestStore.cshtml"
  
    string ButtonName = "Save";
    if (Model.Id != null && Model.Id > 0)
    {
        ButtonName = "Update";
    }
    var defaultImage = Url.Content("~/images/userphotos/profile-photo.png");

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 13 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Store\_RequestStore.cshtml"
 using (Html.BeginForm("AddUpdateStore", "Store", FormMethod.Post, new { @id = "frmAddUpdateStore", @enctype = "multipart/form-data" }))
{
    

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Store\_RequestStore.cshtml"
Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Store\_RequestStore.cshtml"
Write(Html.HiddenFor(m => m.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"row gutter-20\">\r\n\r\n        <div class=\"col-md-12\">\r\n            <div class=\"userimg form-group\">\r\n                <img");
            BeginWriteAttribute("src", " src=\"", 669, "\"", 720, 1);
#nullable restore
#line 21 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Store\_RequestStore.cshtml"
WriteAttributeValue("", 675, Url.Content("~/userimages/"+Model.StoreLogo), 675, 45, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"max-height:250px !important;\"");
            BeginWriteAttribute("onerror", " onerror=\"", 758, "\"", 793, 3);
            WriteAttributeValue("", 768, "this.src=\'", 768, 10, true);
#nullable restore
#line 21 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Store\_RequestStore.cshtml"
WriteAttributeValue("", 778, defaultImage, 778, 13, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 791, "\';", 791, 2, true);
            EndWriteAttribute();
            BeginWriteAttribute("alt", " alt=\"", 794, "\"", 800, 0);
            EndWriteAttribute();
            WriteLiteral(" id=\"ImgId\" class=\"img-fluid mx-auto d-block\">\r\n                ");
#nullable restore
#line 22 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Store\_RequestStore.cshtml"
           Write(Html.HiddenFor(m => m.StoreLogo));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </div>

            <div class=""form-group"">
                <div class=""custom-file"">
                    <input type=""file"" id=""customfile"" name=""customfile"" class=""custom-file-input"" onclick=""initialize(this)"" onchange=""ReadFileName(this)"">
                    <label class=""custom-file-label"" id=""lblChooseFile"" for=""customfile"">Choose file</label>
                </div>
            </div>
        </div>

        <div class=""col-sm-12"">
            <div class=""form-group"">
                <label");
            BeginWriteAttribute("for", " for=\"", 1426, "\"", 1432, 0);
            EndWriteAttribute();
            WriteLiteral(">Store Name<span class=\"required\">*</span></label>\r\n                ");
#nullable restore
#line 36 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Store\_RequestStore.cshtml"
           Write(Html.TextBoxFor(m => m.Name, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 37 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Store\_RequestStore.cshtml"
           Write(Html.ValidationMessageFor(a => a.Name, "", new { @style = "color:red" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div class=\"col-sm-12\">\r\n            <div class=\"form-group\">\r\n                <label");
            BeginWriteAttribute("for", " for=\"", 1785, "\"", 1791, 0);
            EndWriteAttribute();
            WriteLiteral(">Description</label>\r\n                ");
#nullable restore
#line 43 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Store\_RequestStore.cshtml"
           Write(Html.TextAreaFor(m => m.Description, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 44 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Store\_RequestStore.cshtml"
           Write(Html.ValidationMessageFor(a => a.Description, "", new { @style = "color:red" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <div class=\"col-sm-12\">\r\n            <div class=\"form-group\">\r\n                <label");
            BeginWriteAttribute("for", " for=\"", 2129, "\"", 2135, 0);
            EndWriteAttribute();
            WriteLiteral(">Website Link</label>\r\n                ");
#nullable restore
#line 50 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Store\_RequestStore.cshtml"
           Write(Html.TextBoxFor(m => m.WebsiteLink, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 51 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Store\_RequestStore.cshtml"
           Write(Html.ValidationMessageFor(a => a.WebsiteLink, "", new { @style = "color:red" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n    </div>\r\n    <div class=\"modal-footer\">\r\n        <button type=\"button\" id=\"btnSave\" class=\"btn btn-primary btn-sm mtp5\" onclick=\"SaveStore();\"");
            BeginWriteAttribute("title", " title=\"", 2525, "\"", 2544, 1);
#nullable restore
#line 56 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Store\_RequestStore.cshtml"
WriteAttributeValue("", 2533, ButtonName, 2533, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 56 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Store\_RequestStore.cshtml"
                                                                                                                     Write(ButtonName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</button>\r\n        <button type=\"button\" class=\"btn btn-secondary btn-sm mtp5\" data-dismiss=\"modal\" title=\"Cancel\">Cancel</button>\r\n    </div>\r\n");
#nullable restore
#line 59 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Store\_RequestStore.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<script type=""text/javascript"">


    var _validFileExtensions = ["".JPEG"", "".jpeg"", "".JPG"", "".jpg"", "".png"", "".PNG"", "".bmp"", "".BMP"", "".gif"", "".GIF"", "".tiff"", "".TIFF""];
    function ValidateSingleInput(oInput) {
        debugger;
        if (oInput.type == ""file"") {
            var sFileName = oInput.value;
            if (sFileName.length > 0) {
                var blnValid = false;
                for (var j = 0; j < _validFileExtensions.length; j++) {
                    var sCurExtension = _validFileExtensions[j];
                    if (sFileName.substr(sFileName.length - sCurExtension.length, sCurExtension.length).toLowerCase() == sCurExtension.toLowerCase()) {
                        blnValid = true;
                        break;
                    }
                }

                if (!blnValid) {
                    var ogFileName = sFileName.replace(""C:\\fakepath\\"", """");
                    info(""Sorry, "" + ogFileName + "" is invalid, allowed extension are : .jpeg,.jpg,.pn");
            WriteLiteral("g,.bmp,.gif,.tiff\");\r\n                    oInput.value = \"\";\r\n                     $(\'#ImgId\').attr(\'src\', \'");
#nullable restore
#line 84 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Store\_RequestStore.cshtml"
                                         Write(defaultImage);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"');
                    return false;
                }
                else {
                    var fsize = oInput.files[0].size;
                    const file = Math.round((fsize / 1024));
                    if (file > 20480) //20 MB
                    {
                        info(""Maximum 20 MB image is allowed."");
                        oInput.value = """";
                        $('#ImgId').attr('src', '");
#nullable restore
#line 94 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Store\_RequestStore.cshtml"
                                            Write(defaultImage);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"');
                        return false;
                    }
                }
            }
        }
        return true;
    }


    function ReadFileName(fileInput) {
        debugger;
        if (fileInput.files && fileInput.files[0]) {
            var result = ValidateSingleInput(fileInput);
            if (result) {
                var reader = new FileReader();
                reader.onloadend = function (e) {
                    $('#ImgId').attr('src', e.target.result);
                    $(""#StoreLogoPath"").val($(fileInput).val());
                }
                reader.readAsDataURL(fileInput.files[0]);
            }
        }
        else
        {
                $('#ImgId').attr('src', '");
#nullable restore
#line 119 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Store\_RequestStore.cshtml"
                                    Write(defaultImage);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"');
        }
    }

    function initialize() {
        document.body.onfocus = checkIt;
        console.log('initializing');
    }

    // Define a function to check if
    // the user failed to upload file
    function checkIt() {
        // Check if the number of files
        // is not zero
        var theFile = document.getElementById('customfile');
        if (theFile.value.length) {
        }
        // Alert the user if the number
        // of file is zero
        else {
                $('#ImgId').attr('src', '");
#nullable restore
#line 139 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Store\_RequestStore.cshtml"
                                    Write(defaultImage);

#line default
#line hidden
#nullable disable
            WriteLiteral("\');\r\n            }\r\n        document.body.onfocus = null;\r\n    }\r\n\r\n\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DealForumLibrary.Models.AdminAreaModels.AddEditStoreDetail> Html { get; private set; }
    }
}
#pragma warning restore 1591