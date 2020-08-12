using System;
using System.Collections.Generic;
using System.Text;

namespace DealForumLibrary.Models
{
    public class APIResponseModel
    {
        public bool Status { get; set; }
        public int Code { get; set; }
        public string Message { get; set; }
        public string Data { get; set; }
    }
}
