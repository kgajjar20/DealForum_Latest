using System;
using System.Collections.Generic;
using System.Text;

namespace DealForumLibrary.Models
{
    public class CommonModel
    {

    }

    public class TextValue
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }
    public class TextIntValue
    {
        public int Value { get; set; }
        public string Text { get; set; }
    }
    public class TextValueGuid
    {
        public Guid Value { get; set; }
        public string Text { get; set; }
    }

}
