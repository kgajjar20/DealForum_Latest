using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DealForumAPI.DB
{
    [Table("category")]
    public partial class Category
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("name")]
        [StringLength(500)]
        public string Name { get; set; }
        [Column("description")]
        public string Description { get; set; }
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
