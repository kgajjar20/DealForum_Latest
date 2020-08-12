using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DealForumAPI.DB
{
    [Table("usermapping")]
    public partial class Usermapping
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("userid")]
        public Guid Userid { get; set; }
        [Column("roleid")]
        public int Roleid { get; set; }
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

        [ForeignKey(nameof(Roleid))]
        [InverseProperty("Usermapping")]
        public virtual Role Role { get; set; }
        [ForeignKey(nameof(Userid))]
        [InverseProperty("Usermapping")]
        public virtual User User { get; set; }
    }
}
