#pragma checksum "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Store\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c5da5ed7e274bbc2ad764ceb17e9345e4f944c9a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Store_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Store/Index.cshtml")]
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
#line 1 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Store\Index.cshtml"
using DealForumLibrary.Models.AdminAreaModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Store\Index.cshtml"
using Microsoft.AspNetCore.Antiforgery;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c5da5ed7e274bbc2ad764ceb17e9345e4f944c9a", @"/Areas/Admin/Views/Store/Index.cshtml")]
    public class Areas_Admin_Views_Store_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DealForumLibrary.Models.AdminAreaModels.RoleModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Custom/Common.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 7 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Store\Index.cshtml"
  
    ViewData["Title"] = "Stores";
    Layout = "~/Areas/Admin/Views/Shared/_LayoutMain.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c5da5ed7e274bbc2ad764ceb17e9345e4f944c9a3966", async() => {
                WriteLiteral("\r\n    <!-- DataTables -->\r\n    <link");
                BeginWriteAttribute("href", " href=\"", 340, "\"", 430, 1);
#nullable restore
#line 16 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Store\Index.cshtml"
WriteAttributeValue("", 347, Url.Content("~/AdminLTE/plugins/datatables-bs4/css/dataTables.bootstrap4.min.css"), 347, 83, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" rel=\"stylesheet\" />\r\n    <link");
                BeginWriteAttribute("href", " href=\"", 462, "\"", 559, 1);
#nullable restore
#line 17 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Store\Index.cshtml"
WriteAttributeValue("", 469, Url.Content("~/AdminLTE/plugins/datatables-responsive/css/responsive.bootstrap4.min.css"), 469, 90, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" rel=\"stylesheet\" />\r\n\r\n    <!-- DataTables -->\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 620, "\"", 696, 1);
#nullable restore
#line 20 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Store\Index.cshtml"
WriteAttributeValue("", 626, Url.Content("~/AdminLTE/plugins/datatables/jquery.dataTables.min.js"), 626, 70, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 720, "\"", 807, 1);
#nullable restore
#line 21 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Store\Index.cshtml"
WriteAttributeValue("", 726, Url.Content("~/AdminLTE/plugins/datatables-bs4/js/dataTables.bootstrap4.min.js"), 726, 81, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 831, "\"", 925, 1);
#nullable restore
#line 22 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Store\Index.cshtml"
WriteAttributeValue("", 837, Url.Content("~/AdminLTE/plugins/datatables-responsive/js/dataTables.responsive.min.js"), 837, 88, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 949, "\"", 1043, 1);
#nullable restore
#line 23 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Store\Index.cshtml"
WriteAttributeValue("", 955, Url.Content("~/AdminLTE/plugins/datatables-responsive/js/responsive.bootstrap4.min.js"), 955, 88, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 1067, "\"", 1119, 1);
#nullable restore
#line 24 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Store\Index.cshtml"
WriteAttributeValue("", 1073, Url.Content("~/js/Custom/datatableCommon.js"), 1073, 46, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\r\n");
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
            WriteLiteral(@"

<div class=""modal fade"" id=""AddStoreModel"" tabindex=""-1"" Store=""dialog"" data-backdrop=""static"" data-keyboard=""false"">
    <div class=""modal-dialog modal-dialog-centered model"">
        <div class=""modal-content"">
            <div class=""modal-header"">
                <h5 class=""modal-title"" id=""formHeader"">Add Store</h5>
                <button type=""button"" class=""close"" data-dismiss=""modal"" id=""CloseForm"" title=""Close"" aria-label=""Close""> <span aria-hidden=""true"">&times;</span> </button>
            </div>
            <div class=""modal-body clearfix pb-0"" id=""divModelContent"">
");
#nullable restore
#line 35 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Store\Index.cshtml"
                  
                    await Html.RenderPartialAsync("_RequestStore", new AddEditStoreDetail());
                

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            </div>
        </div>
    </div>
</div>
<section class=""content-header"">
    <div class=""container-fluid"">
        <div class=""row mb-2"">
            <div class=""col-sm-6"">
                <h1>Stores</h1>
            </div>
            <div class=""col-sm-6"">
                <ol class=""breadcrumb float-sm-right"">
                    <li class=""breadcrumb-item""><a href=""#"">Store Management</a></li>
                    <li class=""breadcrumb-item active"">Stores</li>
                </ol>
            </div>
        </div>
    </div><!-- /.container-fluid -->
</section>
<section class=""content"">
    <div class=""container-fluid"">
        <div class=""row"">
            <div class=""col-12"">

                <!-- /.card -->

                <div class=""card"">
                    <div class=""card-header"">
                        <div class=""col-md-6"">
                            <h3 class=""card-title"">DataTable with default features</h3>
                        </div>
          ");
            WriteLiteral(@"              <div class=""col-md-6 float-right"">
                            <button type=""button"" class=""btn btn-link text-secondary float-right"" data-toggle=""modal"" data-target=""#AddStoreModel"" onclick=""AddStore()"" title=""Add Store"">
                                <i class=""fas fa-plus""></i>
                            </button>
                        </div>
                    </div>
                    <!-- /.card-header -->
                    <div class=""card-body"">
                        <div id=""example1_wrapper"" class=""dataTables_wrapper dt-bootstrap4"">
                            <div class=""row"">
                                <div class=""col-sm-12"">
                                    ");
#nullable restore
#line 80 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Store\Index.cshtml"
                               Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                    <table id=""tblStore"" class=""table table-bordered table-striped dataTable dtr-inline"" cellspacing=""0"" width=""100%"">
                                        <thead>
                                            <tr>
                                                <th>Id</th>
                                                <th width=""20%"">Name</th>
                                                <th width=""30%"">Description</th>
                                                <th width=""20%"">Image</th>
                                                <th width=""20%"">Website Link</th>
                                                <th width=""5%"">Status</th>
                                                <th width=""5%"">Action</th>
                                            </tr>
                                        </thead>
                                        <tbody></tbody>
                                    </table>
                                </div>");
            WriteLiteral(@"
                            </div>
                        </div>
                    </div>
                    <!-- /.card-body -->
                </div>
                <!-- /.card -->
            </div>
            <!-- /.col -->
        </div>
        <!-- /.row -->
    </div>
    <!-- /.container-fluid -->
</section>


");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c5da5ed7e274bbc2ad764ceb17e9345e4f944c9a12859", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

<script type=""text/javascript"">

    var StoreDataTable = null;
    var storeImagesFolder = ""storeimages"";
    $(function () {
        StoreDataTable = $(""#tblStore"").DataTable({
            ""ajax"": {
                ""url"": _BaseUrl + ""Admin/Store/GetStoresList"",
                ""type"": ""post"",
                ""headers"": { ""MY-XSRF-TOKEN"": $('input[name=""__RequestVerificationToken""]').val() }
            },
            'columnDefs': [
                { ""defaultContent"": ""-"", ""targets"": ""_all"" },
                {
                    'targets': [6], // column index (start from 0)
                    'orderable': false, // set orderable false for selected columns
                }
            ],
            ""columns"": [
                { ""data"": ""Id"", ""visible"": false, ""searchable"": false, ""orderable"": false },
                { ""data"": ""Name"" },
                { ""data"": ""Description"" },
                {
                    ""data"": ""Logo"",
                    ""defaultContent"": """",
            WriteLiteral(@"
                    ""mRender"": function (data, type, row) {
                        debugger;
                        if (row[""Logo""] != null) {
                            var path = _BaseUrl + storeImagesFolder + ""/"" + row[""Logo""];
                            return ""<img style='max-height: 20px;' src='"" + path + ""' />"";
                        }
                        else
                        {
                            return ""-"";
                        }
                    }
                },
                {
                    ""data"": ""Websitelink"",
                    ""defaultContent"": ""-"",
                    ""mRender"": function (data, type, row) {
                        if (row[""Websitelink""] != null) {
                            return ""<a class='text-primary mr-2' href='Javascript:void(0);'  onclick='OpenWebsite(this)' data-website="" + row[""Websitelink""] + ""  title='Go to Website'>"" + row[""Websitelink""] + ""</a>"";
                        }
                        el");
            WriteLiteral(@"se {
                            return ""-"";
                        }

                    }
                },
                {
                    ""data"": ""Status"",
                    ""defaultContent"": """",
                    ""mRender"": function (data, type, row) {
                        if (row[""Status""] == 1) {
                            return ""<div class='custom-control custom-switch'>""
                                + ""<input type='checkbox' checked data-id='"" + row[""Id""] + ""' id='cs-"" + row[""Id""] + ""' checked='checked' onchange='ChangeStatus(this,0)' class='custom-control-input' id='customSwitch1'>""
                                + ""<label class='custom-control-label' for='cs-"" + row[""Id""] + ""'></label></div>"";
                        }
                        else {
                            return ""<div class='custom-control custom-switch'><input type='checkbox' data-id='"" + row[""Id""] + ""' id='cs-"" + row[""Id""] + ""'  onchange='ChangeStatus(this,1)' class='custom-control-input");
            WriteLiteral(@"' id='customSwitch1'><label class='custom-control-label' for='cs-"" + row[""Id""] + ""'></label></div>"";
                        }
                    }
                },
                {
                    ""defaultContent"": """",
                    ""mRender"": function (data, type, row) {
                        return '<a class=""text-primary mr-2"" href=""Javascript:void(0);"" onclick=""RequestStore(this)""  data-id=""' + row[""Id""] + '"" title=""Edit""><i class=""fas fa-pencil-alt""></i></a>'
                            + '<a class=""text-danger"" href=""Javascript:void(0);"" data-id=""' + row[""Id""] + '"" onclick=""DeleteStore(this)"" title=""Delete""><i class=""far fa-trash-alt""></i></a>';
                    }
                }

            ]
        });

        $('.dataTables_filter input')
            .off()
            .on('keyup', function (e) {
                if (e.keyCode == 13) /* if enter is pressed */ {
                    StoreDataTable.search(this.value.trim(), false, false).draw();
              ");
            WriteLiteral(@"  }
            });
    });



    function SaveStore() {
        var form = $('#frmAddUpdateStore');
        $.validator.unobtrusive.parse(form);
        form.validate();
        if (form.valid()) {
            $(""#frmAddUpdateStore"").ajaxSubmit({
                target: """",
                type: ""POST"",
                success: function (res) {
                    if (res.result === true) {
                        $('#CloseForm').click();
                        success(res.message);
                        $('#tblStore').DataTable().ajax.reload();
                    }
                    else {
                        if (res.message !== null && res.message !== undefined && res.message !== '') {
                            error(res.message);
                        }
                        else { error(""Some error has been occured.""); }
                    }
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    var errorMess");
            WriteLiteral(@"age = jqXHR.status + ': ' + jqXHR.statusText
                    error('Error - ' + errorMessage);
                }
            });
        }
    }

    function Clearform() {
        $(""#frmAddUpdateStore"").closest('form').find(""input[type=text], textarea"").val("""");
    }

    function AddStore() {
        Clearform();
        $('#formHeader').html('Add Store');
        $.ajax({
            url: _BaseUrl + 'Admin/Store/AddStore',
            type: 'GET',
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                if (data !== null) {
                    $(""#divModelContent"").html(data);
                } else {
                    $('#CloseForm').click();
                    error('SOMETHING WENT WRONG!');
                }
            },
            error: function (e) {
                $('#CloseForm').click();
                error('SOMETHING WENT WRONG!');
            }
        });
    }

    function RequestStore(ele");
            WriteLiteral(@") {
        var id = $(ele).data(""id"");

        $.ajax({
            headers: { ""MY-XSRF-TOKEN"": $('input[name=""__RequestVerificationToken""]').val() },
            url: _BaseUrl + 'Admin/Store/EditStore',
            type: 'POST',
            data: JSON.stringify({ Id: id }),
            contentType: 'application/json; charset=utf-8',
            success: function (resp) {
                $(""#divModelContent"").html(resp);
                $(""#AddStoreModel"").modal('show');
            },
            error: function (e) {
                error('Something went wrong, please try after sometime!');
            }
        });
    }

    function DeleteStore(ele) {
        event.preventDefault();
        var id = $(ele).data(""id"");
        var ischek = false;
        strconfirm = ""Are you sure you want to delete selected Store?"";
        if (confirm(strconfirm)) {
            $.ajax({
                headers: { ""MY-XSRF-TOKEN"": $('input[name=""__RequestVerificationToken""]').val() },
       ");
            WriteLiteral(@"         url: _BaseUrl + 'Admin/Store/DeleteStore',
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify({ ""Id"": id }),
                success: function (res) {
                    if (res.result === true) {
                        success(res.message);
                        $('#tblStore').DataTable().ajax.reload();
                    }
                    else {
                        if (res.message !== null && res.message !== undefined && res.message !== '') {
                            error(res.message);
                        }
                        else { error(""Some error has been occured.""); }
                    }
                },
                error: function (e) {
                    $(""#"" + id).prop(""checked"", ischek);
                    error('Something went wrong!');
                    return false;
                }
            });
        }
        else {
            return fal");
            WriteLiteral(@"se;
        }
    }

    function ChangeStatus(ele, sts) {
        event.preventDefault();
        var id = $(ele).data(""id"");
        var strconfirm = """";
        var ischek = false;
        if (sts === 0) {
            strconfirm = ""Are you sure you want to inactive selected Store?"";
            ischek = true;
        }
        else {
            strconfirm = ""Are you sure you want to active selected Store?"";
            ischek = false;
        }
        if (confirm(strconfirm)) {
            $.ajax({
                headers: { ""MY-XSRF-TOKEN"": $('input[name=""__RequestVerificationToken""]').val() },
                url: _BaseUrl + 'Admin/Store/ChangeStatus',
                type: 'POST',
                contentType: 'application/json; charset=utf-8',
                data: JSON.stringify({ ID: id, StatusId: sts }),
                success: function (res) {
                    if (res.result === true) {
                        success(res.message);
                        $('#tblStor");
            WriteLiteral(@"e').DataTable().ajax.reload();
                    }
                    else {
                        if (res.message !== null && res.message !== undefined && res.message !== '') {
                            error(res.message);
                        }
                        else { error(""Some error has been occured.""); }
                        $(""#"" + id).prop(""checked"", ischek);
                    }
                },
                error: function (e) {
                    $(""#"" + id).prop(""checked"", ischek);
                    error('Something went wrong!');
                    return false;
                }
            });
        }
        else {
            var id = $(ele).attr('id');
            $(""#"" + id).prop(""checked"", ischek);
            return false;
        }
    }

</script>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IAntiforgery AntiForgery { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DealForumLibrary.Models.AdminAreaModels.RoleModel> Html { get; private set; }
    }
}
#pragma warning restore 1591