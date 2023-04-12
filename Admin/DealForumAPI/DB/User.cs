using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DealForumAPI.DB
{
    [Table("user")]
    public partial class User
    {
        public User()
        {
            Apiactiontracking = new HashSet<Apiactiontracking>();
            Apiexceptiontracking = new HashSet<Apiexceptiontracking>();
            Usermapping = new HashSet<Usermapping>();
        }

        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        [Required]
        [Column("email")]
        [StringLength(500)]
        public string Email { get; set; }
        [Required]
        [Column("passwordhash")]
        public string Passwordhash { get; set; }
        [Required]
        [Column("passwordsalt")]
        public string Passwordsalt { get; set; }
        [Column("emailverificationlink")]
        public string Emailverificationlink { get; set; }
        [Column("emailverified")]
        public bool Emailverified { get; set; }
        [Column("emailverifieddate", TypeName = "datetime")]
        public DateTime? Emailverifieddate { get; set; }
        [Required]
        [Column("firstname")]
        [StringLength(200)]
        public string Firstname { get; set; }
        [Column("middlename")]
        [StringLength(200)]
        public string Middlename { get; set; }
        [Required]
        [Column("lastname")]
        [StringLength(200)]
        public string Lastname { get; set; }
        [Column("profilephoto")]
        [StringLength(2000)]
        public string Profilephoto { get; set; }
        [Column("gender")]
        public int? Gender { get; set; }
        [Column("birthdate", TypeName = "datetime")]
        public DateTime? Birthdate { get; set; }
        [Column("displayofficialbadge")]
        public bool Displayofficialbadge { get; set; }
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

        [InverseProperty("User")]
        public virtual ICollection<Apiactiontracking> Apiactiontracking { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<Apiexceptiontracking> Apiexceptiontracking { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<Usermapping> Usermapping { get; set; }
    }
}
