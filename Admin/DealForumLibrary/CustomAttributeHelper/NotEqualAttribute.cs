using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DealForumLibrary.CustomAttributeHelper
{
    public class NotEqualAttribute : ValidationAttribute
    {
        private string OtherProperty { get; set; }

        public NotEqualAttribute(string otherProperty)
        {
            OtherProperty = otherProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // get other property value
            var otherPropertyInfo = validationContext.ObjectType.GetProperty(OtherProperty);
            var otherValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance);


            // verify values

            if (Convert.ToString(value).Equals(Convert.ToString(otherValue)))
                return new ValidationResult(string.Format("Old Password and New Password cannot be same.", validationContext.MemberName, OtherProperty));
            else
                return ValidationResult.Success;
        }
    }
}
