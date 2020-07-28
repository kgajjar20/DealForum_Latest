using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DealForumAPI.DB
{
    [Table("roleprivilege")]
    public partial class Roleprivilege
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("roleid")]
        public int Roleid { get; set; }
        [Column("menuid")]
        public int Menuid { get; set; }
        [Column("view")]
        public bool View { get; set; }
        [Column("modify")]
        public bool Modify { get; set; }
        [Column("createdby")]
        public Guid? Createdby { get; set; }
        [Column("createddate", TypeName = "datetime")]
        public DateTime? Createddate { get; set; }
        [Column("modifiedby")]
        public Guid? Modifiedby { get; set; }
        [Column("modifieddate", TypeName = "datetime")]
        public DateTime? Modifieddate { get; set; }

        [ForeignKey(nameof(Menuid))]
        [InverseProperty("Roleprivilege")]
        public virtual Menu Menu { get; set; }
        [ForeignKey(nameof(Roleid))]
        [InverseProperty("Roleprivilege")]
        public virtual Role Role { get; set; }
    }
}
