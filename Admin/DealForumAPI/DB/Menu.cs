using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DealForumAPI.DB
{
    [Table("menu")]
    public partial class Menu
    {
        public Menu()
        {
            InverseParentmenu = new HashSet<Menu>();
            Roleprivilege = new HashSet<Roleprivilege>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("menuiconclass")]
        [StringLength(200)]
        public string Menuiconclass { get; set; }
        [Column("controller")]
        [StringLength(500)]
        public string Controller { get; set; }
        [Column("action")]
        [StringLength(500)]
        public string Action { get; set; }
        [Column("menutitle")]
        [StringLength(500)]
        public string Menutitle { get; set; }
        [Column("sortorder")]
        public int? Sortorder { get; set; }
        [Column("parentmenuid")]
        public int? Parentmenuid { get; set; }
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

        [ForeignKey(nameof(Parentmenuid))]
        [InverseProperty(nameof(Menu.InverseParentmenu))]
        public virtual Menu Parentmenu { get; set; }
        [InverseProperty(nameof(Menu.Parentmenu))]
        public virtual ICollection<Menu> InverseParentmenu { get; set; }
        [InverseProperty("Menu")]
        public virtual ICollection<Roleprivilege> Roleprivilege { get; set; }
    }
}
