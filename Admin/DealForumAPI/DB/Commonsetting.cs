using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DealForumAPI.DB
{
    [Table("commonsetting")]
    public partial class Commonsetting
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("smtpserver")]
        [StringLength(500)]
        public string Smtpserver { get; set; }
        [Column("smtpusername")]
        [StringLength(500)]
        public string Smtpusername { get; set; }
        [Column("smtppassword")]
        [StringLength(500)]
        public string Smtppassword { get; set; }
        [Column("smtpfromemail")]
        [StringLength(500)]
        public string Smtpfromemail { get; set; }
        [Column("smtpfromname")]
        [StringLength(500)]
        public string Smtpfromname { get; set; }
        [Column("smtpport")]
        public int? Smtpport { get; set; }
        [Column("isssl")]
        public bool Isssl { get; set; }
        [Column("siteurl")]
        [StringLength(500)]
        public string Siteurl { get; set; }
        [Column("apibaseurl")]
        [StringLength(500)]
        public string Apibaseurl { get; set; }
        [Column("createdby")]
        public Guid? Createdby { get; set; }
        [Column("createddate", TypeName = "datetime")]
        public DateTime? Createddate { get; set; }
        [Column("modifiedby")]
        public Guid? Modifiedby { get; set; }
        [Column("modifieddate", TypeName = "datetime")]
        public DateTime? Modifieddate { get; set; }
    }
}
