using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DealForumLibrary.CustomAttributeHelper
{
    public class CurrentDateAttribute : ValidationAttribute
    {
        public CurrentDateAttribute()
        {
        }

        public override bool IsValid(object value)
        {
            if (value == null) return true;
            var dt = (DateTime)value;
            if (dt >= DateTime.Now.Date)
            {
                return true;
            }
            return false;
        }
    }

}
