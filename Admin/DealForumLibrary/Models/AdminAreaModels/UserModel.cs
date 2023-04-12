using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DealForumLibrary.Models.AdminAreaModels
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public bool Emailverified { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string FullName => string.Format("{0} {1}", Firstname, Lastname);
        public string Lastname { get; set; }
        public int? Gender { get; set; }
        public DateTime? Birthdate { get; set; }
        public bool Displayofficialbadge { get; set; }
        public int Status { get; set; }
        public string JWT { get; set; }
        public int? RoleId { get; set; }
        public string RoleName { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ProfilePhoto { get; set; }
        public byte[] ProfilePhotoByte { get; set; }
    }
}
