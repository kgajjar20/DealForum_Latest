using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DealForumLibrary.Models.Datatables
{
    public class DataTableResponse
    {
        [JsonProperty("draw")]
        public int draw { get; set; }

        [JsonProperty("recordsTotal")]
        public long recordsTotal { get; set; }

        [JsonProperty("recordsFiltered")]
        public int recordsFiltered { get; set; }

        [JsonProperty("data")]
        public object[] data { get; set; }

        [JsonProperty("error")]
        public string error { get; set; }

    }
}
