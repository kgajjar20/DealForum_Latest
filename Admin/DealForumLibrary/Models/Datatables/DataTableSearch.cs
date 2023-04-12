using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DealForumLibrary.Models.Datatables
{
    public class DataTableSearch
    {
        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("regex")]
        public bool Regex { get; set; }
    }
}
