using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DealForumAPI.DB
{
    [Table("dealcategory")]
    public partial class Dealcategory
    {
        [Key]
        public Guid Id { get; set; }
        [Column("dealid")]
        public Guid Dealid { get; set; }
        [Column("categoryid")]
        public int Categoryid { get; set; }
    }
}
