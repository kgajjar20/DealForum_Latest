#pragma checksum "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Views\Shared\_Notifications.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9b98e592f613527c6798191bd6725159c0ef6da7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Notifications), @"mvc.1.0.view", @"/Views/Shared/_Notifications.cshtml")]
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
#nullable restore
#line 4 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Views\Shared\_Notifications.cshtml"
using DealForum.Common;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Views\Shared\_Notifications.cshtml"
using DealForumLibrary.EnumHelper;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9b98e592f613527c6798191bd6725159c0ef6da7", @"/Views/Shared/_Notifications.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f573734e84c76c4e5f2759d609d92e950d79d522", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Notifications : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<script>\r\n    $(document).ready(function ()\r\n    {\r\n");
#nullable restore
#line 6 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Views\Shared\_Notifications.cshtml"
          
            var errorList = Html.GetNotifications(NotificationType.ERROR);
            var warningList = Html.GetNotifications(NotificationType.WARNING);
            var successList = Html.GetNotifications(NotificationType.SUCCESS);
            var infoList = Html.GetNotifications(NotificationType.INFO);
            string message = string.Empty;
            int NotificationDisplayType =0;


            if (errorList != null)
            {
                if (errorList.Count() > 1)
                {
                    message += "There are " + errorList.Count() + " errors :";
                    message += "<ul>";

                    foreach (string msg in errorList)
                    {
                        message += "<li>" + Html.Raw(msg) + "</li>";
                    }

                    message += "</ul>";

                }
                else
                {
                    message = Convert.ToString(Html.Raw(errorList.First()));
                }
                NotificationDisplayType = (int)EnumHelper.NotificationErrorCode.Error;
            }

            if (warningList != null)
            {
                if (warningList.Count() > 1)
                {
                    message += "There are " + warningList.Count() + " warnings :";
                    message += "<ul>";

                    foreach (string msg in warningList)
                    {
                        message += "<li>" + Html.Raw(msg) + "</li>";
                    }

                    message += "</ul>";

                }
                else
                {
                    message = Convert.ToString(Html.Raw(warningList.First()));
                }
                NotificationDisplayType = (int)EnumHelper.NotificationErrorCode.InValid;
            }

            if (infoList != null)
            {
                if (infoList.Count() > 1)
                {
                    message += "There are " + infoList.Count() + " notifications :";
                    message += "<ul>";

                    foreach (string msg in infoList)
                    {
                        message += "<li>" + Html.Raw(msg) + "</li>";
                    }

                    message += "</ul>";

                }
                else
                {
                    message = Convert.ToString(Html.Raw(infoList.First()));
                }
                NotificationDisplayType = (int)EnumHelper.NotificationErrorCode.Mismatch;
            }

            if (successList != null)
            {
                if (successList.Count() > 1)
                {
                    message += "There are " + successList.Count() + " success notifications :";
                    message += "<ul>";

                    foreach (string msg in successList)
                    {
                        message += "<li>" + Html.Raw(msg) + "</li>";
                    }

                    message += "</ul>";

                }
                else
                {
                    message = Convert.ToString(Html.Raw(successList.First()));
                }
                NotificationDisplayType = (int)EnumHelper.NotificationErrorCode.Success;
            }
            

#line default
#line hidden
#nullable disable
            WriteLiteral("        ShowHideNotification(\'");
#nullable restore
#line 103 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Views\Shared\_Notifications.cshtml"
                         Write(message);

#line default
#line hidden
#nullable disable
            WriteLiteral("\',");
#nullable restore
#line 103 "D:\Web Development\Projects\DealForum\Admin\DealForumAdmin\Views\Shared\_Notifications.cshtml"
                                   Write(NotificationDisplayType);

#line default
#line hidden
#nullable disable
            WriteLiteral(@");
    });

    function ShowHideNotification(message,NotificationType) {
        if (NotificationType == 1)
        {
            success(message);
        }
        else if(NotificationType==500){
            error(message);
        }
        else if(NotificationType==3){
            info(message);
        }
       else if(NotificationType==2){
            warning(message);
        }
    }
</script>
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
