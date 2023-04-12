using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DealForumAPI.DB
{
    [Table("couponcategory")]
    public partial class Couponcategory
    {
        [Column("couponid")]
        public int Couponid { get; set; }
        [Column("categoryid")]
        public int Categoryid { get; set; }
    }
}
