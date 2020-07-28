using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DealForumAPI.DB
{
    [Table("user")]
    public partial class User
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }
        [Required]
        [Column("email")]
        [StringLength(500)]
        public string Email { get; set; }
        [Required]
        [Column("password")]
        [StringLength(100)]
        public string Password { get; set; }
        [Column("emailverificationlink")]
        [StringLength(10)]
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
        [Column("lastname")]
        [StringLength(200)]
        public string Lastname { get; set; }
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
    }
}
