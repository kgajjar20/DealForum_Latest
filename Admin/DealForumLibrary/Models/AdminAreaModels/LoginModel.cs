using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DealForumLibrary.Models.AdminAreaModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string Email { get; set; }


        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [MinLength(5,ErrorMessage = "Password must be at least 5 characters long.")]
        [MaxLength(100,ErrorMessage = "Maximum 100 character allowed.")]
        public string Password { get; set; }
    }
}
