using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DealForumAPI.DB
{
    [Table("coupon")]
    public partial class Coupon
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("coupontitle")]
        [StringLength(1000)]
        public string Coupontitle { get; set; }
        [Required]
        [Column("couponcode")]
        [StringLength(500)]
        public string Couponcode { get; set; }
        [Column("couponlink")]
        public string Couponlink { get; set; }
        [Required]
        [Column("description")]
        public string Description { get; set; }
        [Column("storeid")]
        public int Storeid { get; set; }
        [Column("couponexpiry", TypeName = "date")]
        public DateTime? Couponexpiry { get; set; }
        [Column("status")]
        public int Status { get; set; }
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
