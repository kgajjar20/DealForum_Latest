#pragma checksum "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Views\Shared\_Layout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7df24aed201654b0ae8378df9e569240d5d2e120"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Layout), @"mvc.1.0.view", @"/Views/Shared/_Layout.cshtml")]
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
#line 1 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Views\_ViewImports.cshtml"
using DealForumAdmin;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Views\_ViewImports.cshtml"
using DealForumAdmin.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7df24aed201654b0ae8378df9e569240d5d2e120", @"/Views/Shared/_Layout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f573734e84c76c4e5f2759d609d92e950d79d522", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Layout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/site.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("nav-link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-inline ml-3"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/AdminLTE/plugins/summernote/summernote-bs4.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("sidebar-mini layout-navbar-fixed"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("height: auto;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7df24aed201654b0ae8378df9e569240d5d2e1206983", async() => {
                WriteLiteral("\r\n\r\n    <meta charset=\"utf-8\">\r\n    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">\r\n    <title>");
#nullable restore
#line 7 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Views\Shared\_Layout.cshtml"
      Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(" - DealForum</title>\r\n    <!-- Tell the browser to be responsive to screen width -->\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1\">\r\n    <!-- Font Awesome -->\r\n    <link rel=\"stylesheet\"");
                BeginWriteAttribute("href", " href=\"", 374, "\"", 448, 1);
#nullable restore
#line 11 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 381, Url.Content("~/AdminLTE/plugins/fontawesome-free/css/all.min.css"), 381, 67, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n    <!-- Ionicons -->\r\n    <link rel=\"stylesheet\" href=\"https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css\">\r\n    <!-- Tempusdominus Bbootstrap 4 -->\r\n    <link rel=\"stylesheet\"");
                BeginWriteAttribute("href", " href=\"", 646, "\"", 751, 1);
#nullable restore
#line 15 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 653, Url.Content("~/AdminLTE/plugins/tempusdominus-bootstrap-4/css/tempusdominus-bootstrap-4.min.css"), 653, 98, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n    <!-- iCheck -->\r\n    <link rel=\"stylesheet\"");
                BeginWriteAttribute("href", " href=\"", 802, "\"", 885, 1);
#nullable restore
#line 17 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 809, Url.Content("~/AdminLTE/plugins/icheck-bootstrap/icheck-bootstrap.min.css"), 809, 76, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n    <!-- Theme style -->\r\n    <link rel=\"stylesheet\"");
                BeginWriteAttribute("href", " href=\"", 941, "\"", 1000, 1);
#nullable restore
#line 19 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 948, Url.Content("~/AdminLTE/dist/css/adminlte.min.css"), 948, 52, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n    <!-- overlayScrollbars -->\r\n    <link rel=\"stylesheet\"");
                BeginWriteAttribute("href", " href=\"", 1062, "\"", 1151, 1);
#nullable restore
#line 21 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 1069, Url.Content("~/AdminLTE/plugins/overlayScrollbars/css/OverlayScrollbars.min.css"), 1069, 82, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n    <!-- Google Font: Source Sans Pro -->\r\n    <link href=\"https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700\" rel=\"stylesheet\">\r\n    <!--other-->\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "7df24aed201654b0ae8378df9e569240d5d2e12010609", async() => {
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
                WriteLiteral("\r\n");
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
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7df24aed201654b0ae8378df9e569240d5d2e12012496", async() => {
                WriteLiteral(@"
    <div class=""wrapper"">
        <!-- Navbar -->
        <nav class=""main-header navbar navbar-expand navbar-white navbar-light"">
            <!-- Left navbar links -->
            <ul class=""navbar-nav"">
                <li class=""nav-item"">
                    <a class=""nav-link"" data-widget=""pushmenu"" href=""#"" role=""button""><i class=""fas fa-bars""></i></a>
                </li>
                <li class=""nav-item d-none d-sm-inline-block"">
                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7df24aed201654b0ae8378df9e569240d5d2e12013250", async() => {
                    WriteLiteral("Dashboard");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                </li>\r\n                <li class=\"nav-item d-none d-sm-inline-block\">\r\n                    <a href=\"#\" class=\"nav-link\">Contact</a>\r\n                </li>\r\n            </ul>\r\n            <!-- SEARCH FORM -->\r\n            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7df24aed201654b0ae8378df9e569240d5d2e12015029", async() => {
                    WriteLiteral(@"
                <div class=""input-group input-group-sm"">
                    <input class=""form-control form-control-navbar"" type=""search"" placeholder=""Search"" aria-label=""Search"">
                    <div class=""input-group-append"">
                        <button class=""btn btn-navbar"" type=""submit"">
                            <i class=""fas fa-search""></i>
                        </button>
                    </div>
                </div>
            ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"

            <!-- Right navbar links -->
            <ul class=""navbar-nav ml-auto"">
                <!-- Notifications Dropdown Menu -->
                <li class=""nav-item dropdown"">
                    <a class=""nav-link"" data-toggle=""dropdown"" href=""#"">
                        <i class=""far fa-bell""></i>
                        <span class=""badge badge-warning navbar-badge"">15</span>
                    </a>
                    <div class=""dropdown-menu dropdown-menu-lg dropdown-menu-right"">
                        <span class=""dropdown-item dropdown-header"">15 Notifications</span>
                        <div class=""dropdown-divider""></div>
                        <a href=""#"" class=""dropdown-item"">
                            <i class=""fas fa-envelope mr-2""></i> 4 new messages
                            <span class=""float-right text-muted text-sm"">3 mins</span>
                        </a>
                        <div class=""dropdown-divider""></div>
                        <a href=""#""");
                WriteLiteral(@" class=""dropdown-item"">
                            <i class=""fas fa-users mr-2""></i> 8 friend requests
                            <span class=""float-right text-muted text-sm"">12 hours</span>
                        </a>
                        <div class=""dropdown-divider""></div>
                        <a href=""#"" class=""dropdown-item"">
                            <i class=""fas fa-file mr-2""></i> 3 new reports
                            <span class=""float-right text-muted text-sm"">2 days</span>
                        </a>
                        <div class=""dropdown-divider""></div>
                        <a href=""#"" class=""dropdown-item dropdown-footer"">See All Notifications</a>
                    </div>
                </li>
                <li class=""nav-item"">
                    <a class=""nav-link"" data-widget=""control-sidebar"" data-slide=""true"" href=""#"" role=""button"">
                        <i class=""fas fa-th-large""></i>
                    </a>
                </li>
          ");
                WriteLiteral(@"  </ul>
        </nav>
        <!-- /.navbar -->
        <!-- Main Sidebar Container -->
        <aside class=""main-sidebar sidebar-dark-primary elevation-4"">
            <!-- Brand Logo -->
            <a href=""#"" class=""brand-link"">
                <img");
                BeginWriteAttribute("src", " src=\"", 5065, "\"", 5123, 1);
#nullable restore
#line 97 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 5071, Url.Content("~/AdminLTE/dist/img/AdminLTELogo.png"), 5071, 52, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" alt=""AdminLTE Logo"" class=""brand-image img-circle elevation-3""
                     style=""opacity: .8"">
                <span class=""brand-text font-weight-light"">Deal Forum</span>
            </a>

            <!-- Sidebar -->
            <div class=""sidebar"">
                <!-- Sidebar user panel (optional) -->
                <div class=""user-panel mt-3 pb-3 mb-3 d-flex"">
                    <div class=""image"">
                        <img");
                BeginWriteAttribute("src", " src=\"", 5584, "\"", 5643, 1);
#nullable restore
#line 107 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 5590, Url.Content("~/AdminLTE/dist/img/user2-160x160.jpg"), 5590, 53, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" class=""img-circle elevation-2"" alt=""User Image"">
                    </div>
                    <div class=""info"">
                        <a href=""#"" class=""d-block"">Kaushal Gajjar</a>
                    </div>
                </div>

                <!-- Sidebar Menu -->
                <nav class=""mt-2"">
                    <ul class=""nav nav-pills nav-sidebar flex-column"" data-widget=""treeview"" role=""menu"" data-accordion=""false"">
                        <!-- Add icons to the links using the .nav-icon class
                        with font-awesome or any other icon font library -->
                        <li class=""nav-item"">
                            <a");
                BeginWriteAttribute("href", " href=\"", 6328, "\"", 6367, 1);
#nullable restore
#line 120 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 6335, Url.Action("Index","Dashboard"), 6335, 32, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" class=""nav-link active"">
                                <i class=""nav-icon fas fa-th""></i>
                                <p>Dashboard</p>
                            </a>
                        </li>
                        <li class=""nav-header"">User Management</li>
                        <li class=""nav-item has-treeview"">
                            <a href=""#"" class=""nav-link"">
                                <i class=""nav-icon fas fa-user""></i>
                                <p>
                                    User Management
                                    <i class=""right fas fa-angle-left""></i>
                                </p>
                            </a>
                            <ul class=""nav nav-treeview"" style=""display: none;"">
                                <li class=""nav-item"">
                                    <a");
                BeginWriteAttribute("href", " href=\"", 7250, "\"", 7284, 1);
#nullable restore
#line 136 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 7257, Url.Action("Index","Role"), 7257, 27, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" class=""nav-link"">
                                        <i class=""far fa-circle nav-icon""></i>
                                        <p>Roles</p>
                                    </a>
                                </li>
                                <li class=""nav-item"">
                                    <a");
                BeginWriteAttribute("href", " href=\"", 7613, "\"", 7657, 1);
#nullable restore
#line 142 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 7620, Url.Action("Index","RolePermission"), 7620, 37, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" class=""nav-link"">
                                        <i class=""far fa-circle nav-icon""></i>
                                        <p>Role Permission</p>
                                    </a>
                                </li>
                                <li class=""nav-item"">
                                    <a");
                BeginWriteAttribute("href", " href=\"", 7996, "\"", 8030, 1);
#nullable restore
#line 148 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 8003, Url.Action("Index","User"), 8003, 27, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" class=""nav-link"">
                                        <i class=""far fa-circle nav-icon""></i>
                                        <p>Users</p>
                                    </a>
                                </li>
                            </ul>
                        </li>
                    </ul>
                </nav>
                <!-- /.sidebar-menu -->
            </div>
            <!-- /.sidebar -->
        </aside>

        <!-- Content Wrapper. Contains page content -->
        <div class=""content-wrapper"">
         ");
#nullable restore
#line 164 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Views\Shared\_Layout.cshtml"
    Write(RenderBody());

#line default
#line hidden
#nullable disable
                WriteLiteral(@"       
        <!-- Control Sidebar -->
        <aside class=""control-sidebar control-sidebar-dark"">
            <!-- Control sidebar content goes here -->
        </aside>
        <!-- /.control-sidebar -->
    </div>
    <!-- ./wrapper -->
    <!-- jQuery -->
    <script");
                BeginWriteAttribute("src", " src=\"", 8897, "\"", 8958, 1);
#nullable restore
#line 173 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 8903, Url.Content("~/AdminLTE/plugins/jquery/jquery.min.js"), 8903, 55, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\r\n    <!-- jQuery UI 1.11.4 -->\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 9013, "\"", 9080, 1);
#nullable restore
#line 175 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 9019, Url.Content("~/AdminLTE/plugins/jquery-ui/jquery-ui.min.js"), 9019, 61, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\r\n    <!-- Resolve conflict in jQuery UI tooltip with Bootstrap tooltip -->\r\n    <script>\r\n        $.widget.bridge(\'uibutton\', $.ui.button)\r\n    </script>\r\n    <!-- Bootstrap 4 -->\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 9284, "\"", 9361, 1);
#nullable restore
#line 181 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 9290, Url.Content("~/AdminLTE/plugins/bootstrap/js/bootstrap.bundle.min.js"), 9290, 71, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\r\n    <!-- daterangepicker -->\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 9415, "\"", 9476, 1);
#nullable restore
#line 183 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 9421, Url.Content("~/AdminLTE/plugins/moment/moment.min.js"), 9421, 55, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 9500, "\"", 9575, 1);
#nullable restore
#line 184 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 9506, Url.Content("~/AdminLTE/plugins/daterangepicker/daterangepicker.js"), 9506, 69, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\r\n    <!-- Tempusdominus Bootstrap 4 -->\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 9639, "\"", 9741, 1);
#nullable restore
#line 186 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 9645, Url.Content("~/AdminLTE/plugins/tempusdominus-bootstrap-4/js/tempusdominus-bootstrap-4.min.js"), 9645, 96, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\r\n    <!-- Summernote -->\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7df24aed201654b0ae8378df9e569240d5d2e12028747", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    <!-- overlayScrollbars -->\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 9903, "\"", 9996, 1);
#nullable restore
#line 190 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 9909, Url.Content("~/AdminLTE/plugins/overlayScrollbars/js/jquery.overlayScrollbars.min.js"), 9909, 87, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\r\n    <!-- AdminLTE App -->\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 10047, "\"", 10099, 1);
#nullable restore
#line 192 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Views\Shared\_Layout.cshtml"
WriteAttributeValue("", 10053, Url.Content("~/AdminLTE/dist/js/adminlte.js"), 10053, 46, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\r\n    <!-- AdminLTE dashboard demo (This is only for demo purposes) -->\r\n    <!-- AdminLTE for demo purposes -->\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
</html>

<script>

    $(document).ready(function () {

        $(function () {
            $('.nav li>a').removeClass('active');
            $('nav a[href^=""/' + location.pathname.split(""/"")[1] + '""]').addClass('active');
        });

        $("".nav-link"").click(function () {
            if ($(this).parent('li').parent('ul.nav-treeview').length > 0) {
                debugger;
                $(this).addClass('active');
                var treeViewLength = $(this).parent('li').parent('ul.nav-treeview').parent('li.has-treeview').length;
                if (treeViewLength != null && treeViewLength !== undefined && treeViewLength > 0) {
                    $('.nav li>a').removeClass('active');
                    $(this).parent('li').parent('ul.nav-treeview').parent('li.has-treeview').find('a:first').addClass('active');
                }
            }
            else if ($(this).parent('li').hasClass('has-treeview')) {
                console.log('tree-view');
            }
         ");
            WriteLiteral("   else {\r\n                $(\'.nav li>a\').removeClass(\'active\');\r\n                $(this).addClass(\'active\');\r\n            }\r\n        });\r\n    });\r\n</script>\r\n");
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
