using DealForumLibrary.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace DealForumLibrary
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

        public enum CouponStatus : int
        {
            [Description("Approved")]
            Approved = 1,
            [Description("Pending")]
            Pending = 0,
            [Description("Declined")]
            Declined = 2
        }

        public enum PortalType : int
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

    public static class EnumHelperMethods
    {
        #region Get Enum value by Enum Description
        public static T GetValueFromEnumDescription<T>(string description)
        {
            var type = typeof(T);
            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (var field in type.GetFields())
            {
                var attribute = Attribute.GetCustomAttribute(field,
                    typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute != null)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }
            throw new ArgumentException("Not found.", "description");
            // or return default(T);
        }
        #endregion

        #region Get Enum description by passig Enum's Value
        //Get Enum description by passig Enum Value
        public static string GetEnumDescription<TEnum>(int? value)
        {
            try
            {
                if (value != null)
                {
                    return GetDescription((Enum)(object)((TEnum)(object)value));
                }
                else
                {
                    return string.Empty;
                }

            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
        #endregion

        #region  Get Description from Enum input
        public static string GetDescription(System.Enum input)
        {
            Type type = input.GetType();
            MemberInfo[] memInfo = type.GetMember(Convert.ToString(input));

            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = (object[])memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs != null && attrs.Length > 0)
                {
                    return ((DescriptionAttribute)attrs[0]).Description;
                }
            }
            return Convert.ToString(input);
        }
        #endregion

        public static List<TextIntValue> GetEnumList<T>()
        {
            List<TextIntValue> MyEnumLst = new List<TextIntValue>();
            try
            {
                Type enumType = typeof(T);

                if (enumType.BaseType != typeof(Enum))
                {
                    //throw new ArgumentException("T is not System.Enum");
                    MyEnumLst = new List<TextIntValue>();
                }
                else
                {
                    foreach (var e in Enum.GetValues(typeof(T)))
                    {
                        var fi = e.GetType().GetField(e.ToString());
                        var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

                        TextIntValue TV = new TextIntValue
                        {
                            Value = (int)e,
                            Text = (attributes.Length > 0) ? attributes[0].Description : e.ToString()
                        };

                        MyEnumLst.Add(TV);
                    }
                }
            }
            catch
            {
                MyEnumLst = new List<TextIntValue>();
            }

            return MyEnumLst;
        }

    }
}
