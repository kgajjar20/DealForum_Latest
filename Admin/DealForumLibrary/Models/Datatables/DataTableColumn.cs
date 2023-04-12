using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DealForumLibrary.Models.Datatables
{
    public class DataTableColumn
    {
        [JsonProperty("data")]
        public string Data { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("searchable")]
        public bool Searchable { get; set; }

        [JsonProperty("orderable")]
        public bool Orderable { get; set; }

        public DataTableSearch Search { get; set; }
    }
}
