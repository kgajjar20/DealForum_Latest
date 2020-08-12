using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DealForumLibrary.EnumHelper
{
    public static class EnumHelper
    {
        public enum APILogTrackingType : int
        {
            Request = 1,
            Response = 2
        }

        public enum APITrackingType : int
        {
            Login = 1,
            Registeration = 2,
            ForgotPassword = 3,
            Add = 4,
            Edit = 5,
            Delete = 6,
            Search = 7,
            View = 8,
            ResetPassword = 9,
            VerifyEmail = 10,
            VerifyMenuRights = 11,
            Invitation = 12,
            FileDownload = 13
        }

        public enum Gender : int
        {
            [Description("Male")]
            Male = 1,
            [Description("Female")]
            Female = 2,
            [Description("Other")]
            Other = 3
        }
        public enum LoginStatus
        {
            Failed,
            Success,
            EmailNotVerified,
            BadRequest
        }


        public enum Status : int
        {
            [Description("Active")]
            Active = 1,
            [Description("InActive")]
            InActive = 0,
            [Description("Deleted")]
            Deleted = 2
        }

        public  enum PortalType : int
        {
            [Description("Client")]
            Client = 1,

            [Description("Admin")]
            Admin = 2,
        }

        public enum RoleType : int
        {
            [Description("Admin")]
            Admin = 1,

        }

        #region API Response Status (Enum)
        public enum ResponseStatus : int
        {
            [Description("Sucess")]
            Sucess = 1,
            [Description("Failed")]
            Failed = 0
        }

        #endregion

        #region API Response Codes (Enum)
        public enum ResponseCode : int
        {
            OK = 200,
            BadRequest = 400,
            Unauthorized = 401,
            Forbidden = 403,
            NotFound = 404,
            MethodNotAllowed = 405,
            InternalServerError = 500,
            ServiceUnavailable = 503,
            CustomError = 999,
            RequestTimeout = 408,
            Duplicate = 409,
            DoNotHavePermission = 9999,
        }
        #endregion

        public enum NotificationErrorCode
        {
            Success = 1,
            InValid = 2,
            Mismatch = 3,
            Error = 500,
            NotFound = 404
        }
    }
}
