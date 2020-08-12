using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealForum.Models
{
    public class AjaxResponseModel
    {
        public bool IsSuccess { get; set; }
        public string ResponseMessage { get; set; }
        public string RedirectURL { get; set; }
    }
}
