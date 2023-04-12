using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DealForumAPI.DB
{
    [Table("deal")]
    public partial class Deal
    {
        [Key]
        public Guid Id { get; set; }
        [Column("forumid")]
        public Guid Forumid { get; set; }
        [Required]
        [Column("deallink")]
        public string Deallink { get; set; }
        [Required]
        [Column("dealtitile")]
        [StringLength(2000)]
        public string Dealtitile { get; set; }
        [Required]
        [Column("description")]
        public string Description { get; set; }
        [Column("dealprice", TypeName = "decimal(10, 2)")]
        public decimal? Dealprice { get; set; }
        [Column("retailprice", TypeName = "decimal(10, 2)")]
        public decimal? Retailprice { get; set; }
        [Column("startdate", TypeName = "datetime")]
        public DateTime? Startdate { get; set; }
        [Column("expirydate", TypeName = "datetime")]
        public DateTime? Expirydate { get; set; }
        [Column("status")]
        public int Status { get; set; }
        [Required]
        [Column("imagename")]
        public string Imagename { get; set; }
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
