#pragma checksum "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Shared\_LayoutMain.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bb05dc702603668297a8f5e5a58e9d6fd017523e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Shared__LayoutMain), @"mvc.1.0.view", @"/Areas/Admin/Views/Shared/_LayoutMain.cshtml")]
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
#line 1 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Shared\_LayoutMain.cshtml"
using DealForum.Common;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bb05dc702603668297a8f5e5a58e9d6fd017523e", @"/Areas/Admin/Views/Shared/_LayoutMain.cshtml")]
    public class Areas_Admin_Views_Shared__LayoutMain : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/AdminLTE/plugins/summernote/summernote-bs4.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("sidebar-mini layout-navbar-fixed"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("height: auto;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<!DOCTYPE html>\r\n<html lang=\"en\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bb05dc702603668297a8f5e5a58e9d6fd017523e4306", async() => {
                WriteLiteral("\r\n\r\n    <meta charset=\"utf-8\">\r\n    <meta http-equiv=\"X-UA-Compatible\" content=\"IE=edge\">\r\n    <title>");
#nullable restore
#line 9 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Shared\_LayoutMain.cshtml"
      Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(" - DealForum</title>\r\n    <!-- Tell the browser to be responsive to screen width -->\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1\">\r\n    <!-- Font Awesome -->\r\n    <link rel=\"stylesheet\"");
                BeginWriteAttribute("href", " href=\"", 402, "\"", 476, 1);
#nullable restore
#line 13 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Shared\_LayoutMain.cshtml"
WriteAttributeValue("", 409, Url.Content("~/AdminLTE/plugins/fontawesome-free/css/all.min.css"), 409, 67, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n    <!-- Ionicons -->\r\n    <link rel=\"stylesheet\" href=\"https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css\">\r\n    <!-- Tempusdominus Bbootstrap 4 -->\r\n    <link rel=\"stylesheet\"");
                BeginWriteAttribute("href", " href=\"", 674, "\"", 779, 1);
#nullable restore
#line 17 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Shared\_LayoutMain.cshtml"
WriteAttributeValue("", 681, Url.Content("~/AdminLTE/plugins/tempusdominus-bootstrap-4/css/tempusdominus-bootstrap-4.min.css"), 681, 98, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n    <!-- iCheck -->\r\n    <link rel=\"stylesheet\"");
                BeginWriteAttribute("href", " href=\"", 830, "\"", 913, 1);
#nullable restore
#line 19 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Shared\_LayoutMain.cshtml"
WriteAttributeValue("", 837, Url.Content("~/AdminLTE/plugins/icheck-bootstrap/icheck-bootstrap.min.css"), 837, 76, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n    <!-- Theme style -->\r\n    <link rel=\"stylesheet\"");
                BeginWriteAttribute("href", " href=\"", 969, "\"", 1028, 1);
#nullable restore
#line 21 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Shared\_LayoutMain.cshtml"
WriteAttributeValue("", 976, Url.Content("~/AdminLTE/dist/css/adminlte.min.css"), 976, 52, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n    <!-- overlayScrollbars -->\r\n    <link rel=\"stylesheet\"");
                BeginWriteAttribute("href", " href=\"", 1090, "\"", 1179, 1);
#nullable restore
#line 23 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Shared\_LayoutMain.cshtml"
WriteAttributeValue("", 1097, Url.Content("~/AdminLTE/plugins/overlayScrollbars/css/OverlayScrollbars.min.css"), 1097, 82, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n    <!-- Google Font: Source Sans Pro -->\r\n    <link href=\"https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700\" rel=\"stylesheet\">\r\n    <!--other-->\r\n    <link rel=\"stylesheet\"");
                BeginWriteAttribute("href", " href=\"", 1379, "\"", 1416, 1);
#nullable restore
#line 27 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Shared\_LayoutMain.cshtml"
WriteAttributeValue("", 1386, Url.Content("~/css/site.css"), 1386, 30, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" />\r\n    <!-- Custom -->\r\n    <link");
                BeginWriteAttribute("href", " href=\"", 1452, "\"", 1503, 1);
#nullable restore
#line 29 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Shared\_LayoutMain.cshtml"
WriteAttributeValue("", 1459, Url.Content("~/css/Custom/stickynotes.css"), 1459, 44, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" rel=\"stylesheet\" />\r\n");
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bb05dc702603668297a8f5e5a58e9d6fd017523e9675", async() => {
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
                    <a asp-action=""Index"" asp-controller=""Home"" class=""nav-link"">Dashboard</a>
                </li>
                <li class=""nav-item d-none d-sm-inline-block"">
                    <a href=""#"" class=""nav-link"">Contact</a>
                </li>
            </ul>
            <!-- SEARCH FORM -->
            <form class=""form-inline ml-3"">
                <div class=""input-group input-group-sm"">
                    <input class=""form-control form-control-navbar"" type=""search"" placeholder=""Search"" aria-label=""Search"">
                 ");
                WriteLiteral(@"   <div class=""input-group-append"">
                        <button class=""btn btn-navbar"" type=""submit"">
                            <i class=""fas fa-search""></i>
                        </button>
                    </div>
                </div>
            </form>

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
                       ");
                WriteLiteral(@"     <i class=""fas fa-envelope mr-2""></i> 4 new messages
                            <span class=""float-right text-muted text-sm"">3 mins</span>
                        </a>
                        <div class=""dropdown-divider""></div>
                        <a href=""#"" class=""dropdown-item"">
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
                </");
                WriteLiteral("li>\r\n                <li class=\"nav-item dropdown user-menu\">\r\n                    <a href=\"#\" class=\"nav-link dropdown-toggle\" data-toggle=\"dropdown\" aria-expanded=\"false\">\r\n                        <img");
                BeginWriteAttribute("src", " src=\"", 4881, "\"", 4940, 1);
#nullable restore
#line 91 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Shared\_LayoutMain.cshtml"
WriteAttributeValue("", 4887, Url.Content("~/AdminLTE/dist/img/user2-160x160.jpg"), 4887, 53, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" class=""user-image img-circle elevation-2"" alt=""User Image"">
                        <span class=""d-none d-md-inline"">Alexander Pierce</span>
                    </a>
                    <ul class=""dropdown-menu dropdown-menu-lg dropdown-menu-right"" style=""left: inherit; right: 0px;"">
                        <!-- User image -->
                        <li class=""user-header bg-primary"">
                            <img");
                BeginWriteAttribute("src", " src=\"", 5369, "\"", 5428, 1);
#nullable restore
#line 97 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Shared\_LayoutMain.cshtml"
WriteAttributeValue("", 5375, Url.Content("~/AdminLTE/dist/img/user2-160x160.jpg"), 5375, 53, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"img-circle elevation-2\" alt=\"User Image\">\r\n\r\n                            <p>\r\n                                ");
#nullable restore
#line 100 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Shared\_LayoutMain.cshtml"
                           Write(UserSession.FirstName);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
#nullable restore
#line 100 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Shared\_LayoutMain.cshtml"
                                                  Write(UserSession.LastName);

#line default
#line hidden
#nullable disable
                WriteLiteral(" - ");
#nullable restore
#line 100 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Shared\_LayoutMain.cshtml"
                                                                          Write(UserSession.RoleName);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                <small>\r\n                                    Member since ");
#nullable restore
#line 102 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Shared\_LayoutMain.cshtml"
                                            Write(String.Format("{0:MMM} {1}", UserSession.CreatedDate.Value, "."));

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
#nullable restore
#line 102 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Shared\_LayoutMain.cshtml"
                                                                                                              Write(UserSession.CreatedDate.Value.Year);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                </small>
                            </p>
                        </li>
                        <!-- Menu Body -->
                        <li class=""user-body"">
                            <div class=""row"">
                                <div class=""col-4 text-center"">
                                    <a href=""#"">Followers</a>
                                </div>
                                <div class=""col-4 text-center"">
                                    <a href=""#"">Sales</a>
                                </div>
                                <div class=""col-4 text-center"">
                                    <a href=""#"">Friends</a>
                                </div>
                            </div>
                            <!-- /.row -->
                        </li>
                        <!-- Menu Footer-->
                        <li class=""user-footer"">
                            <a href=""#"" class=""btn btn-default btn-flat""");
                WriteLiteral(">Profile</a>\r\n                            <a");
                BeginWriteAttribute("href", " href=\'", 6876, "\'", 6932, 1);
#nullable restore
#line 124 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Shared\_LayoutMain.cshtml"
WriteAttributeValue("", 6883, Url.Action("Logout","Home",new { Area ="Admin"}), 6883, 49, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" class=""btn btn-default btn-flat float-right"">Sign out</a>
                        </li>
                    </ul>
                </li>
                <li class=""nav-item"">
                    <a class=""nav-link"" data-widget=""control-sidebar"" data-slide=""true"" href=""#"" role=""button"">
                        <i class=""fas fa-th-large""></i>
                    </a>
                </li>
            </ul>
        </nav>
        <!-- /.navbar -->
        <!-- Main Sidebar Container -->
        <aside class=""main-sidebar sidebar-dark-primary elevation-4"">
            <!-- Brand Logo -->
            <a href=""#"" class=""brand-link"">
                <img");
                BeginWriteAttribute("src", " src=\"", 7604, "\"", 7662, 1);
#nullable restore
#line 140 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Shared\_LayoutMain.cshtml"
WriteAttributeValue("", 7610, Url.Content("~/AdminLTE/dist/img/AdminLTELogo.png"), 7610, 52, false);

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
                BeginWriteAttribute("src", " src=\"", 8123, "\"", 8182, 1);
#nullable restore
#line 150 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Shared\_LayoutMain.cshtml"
WriteAttributeValue("", 8129, Url.Content("~/AdminLTE/dist/img/user2-160x160.jpg"), 8129, 53, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"img-circle elevation-2\" alt=\"User Image\">\r\n                    </div>\r\n                    <div class=\"info\">\r\n                        <a href=\"#\" class=\"d-block\">");
#nullable restore
#line 153 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Shared\_LayoutMain.cshtml"
                                               Write(UserSession.FirstName);

#line default
#line hidden
#nullable disable
                WriteLiteral(" ");
#nullable restore
#line 153 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Shared\_LayoutMain.cshtml"
                                                                      Write(UserSession.LastName);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</a>
                    </div>
                </div>

                <!-- Sidebar Menu -->
                <nav class=""mt-2"">
                    <ul class=""nav nav-pills nav-sidebar flex-column"" data-widget=""treeview"" role=""menu"" data-accordion=""false"">
                        <!-- Add icons to the links using the .nav-icon class
                        with font-awesome or any other icon font library -->
                        <li class=""nav-item"">
                            <a");
                BeginWriteAttribute("href", " href=\"", 8897, "\"", 8957, 1);
#nullable restore
#line 163 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Shared\_LayoutMain.cshtml"
WriteAttributeValue("", 8904, Url.Action("Index","Dashboard",new { Area ="Admin"}), 8904, 53, false);

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
                BeginWriteAttribute("href", " href=\"", 9840, "\"", 9895, 1);
#nullable restore
#line 179 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Shared\_LayoutMain.cshtml"
WriteAttributeValue("", 9847, Url.Action("Index","Role",new { Area ="Admin"}), 9847, 48, false);

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
                BeginWriteAttribute("href", " href=\"", 10224, "\"", 10289, 1);
#nullable restore
#line 185 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Shared\_LayoutMain.cshtml"
WriteAttributeValue("", 10231, Url.Action("Index","RolePermission",new { Area ="Admin"}), 10231, 58, false);

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
                BeginWriteAttribute("href", " href=\"", 10628, "\"", 10683, 1);
#nullable restore
#line 191 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Shared\_LayoutMain.cshtml"
WriteAttributeValue("", 10635, Url.Action("Index","User",new { Area ="Admin"}), 10635, 48, false);

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
#line 207 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Shared\_LayoutMain.cshtml"
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
    </div>
    <!-- ./wrapper -->
    <!-- jQuery -->
    <script");
                BeginWriteAttribute("src", " src=\"", 11582, "\"", 11643, 1);
#nullable restore
#line 217 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Shared\_LayoutMain.cshtml"
WriteAttributeValue("", 11588, Url.Content("~/AdminLTE/plugins/jquery/jquery.min.js"), 11588, 55, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\r\n    <!-- jQuery UI 1.11.4 -->\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 11698, "\"", 11765, 1);
#nullable restore
#line 219 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Shared\_LayoutMain.cshtml"
WriteAttributeValue("", 11704, Url.Content("~/AdminLTE/plugins/jquery-ui/jquery-ui.min.js"), 11704, 61, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\r\n    <!-- Resolve conflict in jQuery UI tooltip with Bootstrap tooltip -->\r\n    <script>\r\n        $.widget.bridge(\'uibutton\', $.ui.button)\r\n    </script>\r\n    <!-- Bootstrap 4 -->\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 11969, "\"", 12046, 1);
#nullable restore
#line 225 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Shared\_LayoutMain.cshtml"
WriteAttributeValue("", 11975, Url.Content("~/AdminLTE/plugins/bootstrap/js/bootstrap.bundle.min.js"), 11975, 71, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\r\n    <!-- daterangepicker -->\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 12100, "\"", 12161, 1);
#nullable restore
#line 227 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Shared\_LayoutMain.cshtml"
WriteAttributeValue("", 12106, Url.Content("~/AdminLTE/plugins/moment/moment.min.js"), 12106, 55, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 12185, "\"", 12260, 1);
#nullable restore
#line 228 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Shared\_LayoutMain.cshtml"
WriteAttributeValue("", 12191, Url.Content("~/AdminLTE/plugins/daterangepicker/daterangepicker.js"), 12191, 69, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\r\n    <!-- Tempusdominus Bootstrap 4 -->\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 12324, "\"", 12426, 1);
#nullable restore
#line 230 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Shared\_LayoutMain.cshtml"
WriteAttributeValue("", 12330, Url.Content("~/AdminLTE/plugins/tempusdominus-bootstrap-4/js/tempusdominus-bootstrap-4.min.js"), 12330, 96, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\r\n    <!-- Summernote -->\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bb05dc702603668297a8f5e5a58e9d6fd017523e29220", async() => {
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
                WriteLiteral("\r\n    <!-- overlayScrollbars -->\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 12588, "\"", 12681, 1);
#nullable restore
#line 234 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Shared\_LayoutMain.cshtml"
WriteAttributeValue("", 12594, Url.Content("~/AdminLTE/plugins/overlayScrollbars/js/jquery.overlayScrollbars.min.js"), 12594, 87, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\r\n    <!-- AdminLTE App -->\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 12732, "\"", 12784, 1);
#nullable restore
#line 236 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Shared\_LayoutMain.cshtml"
WriteAttributeValue("", 12738, Url.Content("~/AdminLTE/dist/js/adminlte.js"), 12738, 46, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\r\n    <!-- AdminLTE dashboard demo (This is only for demo purposes) -->\r\n    <!-- AdminLTE for demo purposes -->\r\n    <!-- Custom-->\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 12940, "\"", 12988, 1);
#nullable restore
#line 240 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Shared\_LayoutMain.cshtml"
WriteAttributeValue("", 12946, Url.Content("~/js/Custom/stickynotes.js"), 12946, 42, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\r\n    <script");
                BeginWriteAttribute("src", " src=\"", 13012, "\"", 13055, 1);
#nullable restore
#line 241 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Areas\Admin\Views\Shared\_LayoutMain.cshtml"
WriteAttributeValue("", 13018, Url.Content("~/js/Custom/Common.js"), 13018, 37, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral("></script>\r\n\r\n\r\n    <div id=\"_NotificationShare\">\r\n        <partial name=\"_Notifications\" />\r\n    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
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