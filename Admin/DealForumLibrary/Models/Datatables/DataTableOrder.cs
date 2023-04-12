using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace DealForumLibrary.Models.Datatables
{
    public class DataTableOrder
    {
        [JsonProperty("column")]
        public int Column { get; set; }

        [JsonProperty("dir")]
        public string Dir { get; set; }
    }
}
