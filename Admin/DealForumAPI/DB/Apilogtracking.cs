using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DealForumAPI.DB
{
    [Table("apilogtracking")]
    public partial class Apilogtracking
    {
        [Key]
        public int Id { get; set; }
        public string Traceid { get; set; }
        [StringLength(100)]
        public string Ipaddress { get; set; }
        [StringLength(100)]
        public string Httpmethod { get; set; }
        [StringLength(100)]
        public string Apiname { get; set; }
        public string Requestbody { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Requesttime { get; set; }
        public string Responsebody { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Responsetime { get; set; }
        public int? Requestedby { get; set; }
        public int? Requestedfrom { get; set; }
        public string Url { get; set; }
        public string Requestedapp { get; set; }
        public string Mobiledata { get; set; }
        public string Authtoken { get; set; }
        [StringLength(500)]
        public string Apiversion { get; set; }
    }
}
