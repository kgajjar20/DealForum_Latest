using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DealForumAPI.DB
{
    [Table("apiactiontracking")]
    public partial class Apiactiontracking
    {
        [Key]
        public Guid Id { get; set; }
        [Column("traceid")]
        [StringLength(1000)]
        public string Traceid { get; set; }
        [Column("actiontypeid")]
        public int? Actiontypeid { get; set; }
        [Column("description")]
        [StringLength(1000)]
        public string Description { get; set; }
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
        [Column("actiontime", TypeName = "datetime")]
        public DateTime? Actiontime { get; set; }

        [ForeignKey(nameof(Userid))]
        [InverseProperty("Apiactiontracking")]
        public virtual User User { get; set; }
    }
}
