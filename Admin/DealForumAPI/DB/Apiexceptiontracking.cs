using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DealForumAPI.DB
{
    [Table("apiexceptiontracking")]
    public partial class Apiexceptiontracking
    {
        [Key]
        public Guid Id { get; set; }
        [Column("traceid")]
        [StringLength(1000)]
        public string Traceid { get; set; }
        [Column("exception")]
        [StringLength(1000)]
        public string Exception { get; set; }
        [Column("controller")]
        [StringLength(1000)]
        public string Controller { get; set; }
        [Column("action")]
        [StringLength(1000)]
        public string Action { get; set; }
        [Column("httpmethod")]
        [StringLength(1000)]
        public string Httpmethod { get; set; }
        [Column("url")]
        [StringLength(1000)]
        public string Url { get; set; }
        [Column("userid")]
        public Guid? Userid { get; set; }
        [Column("portaltype")]
        public int? Portaltype { get; set; }
        [Column("exceptiontime", TypeName = "datetime")]
        public DateTime? Exceptiontime { get; set; }

        [ForeignKey(nameof(Userid))]
        [InverseProperty("Apiexceptiontracking")]
        public virtual User User { get; set; }
    }
}
