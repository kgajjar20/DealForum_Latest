using DealForumLibrary;
using DealForumLibrary.Models.Datatables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DealForumLibrary.Models.AdminAreaModels
{
    public class RoleModel
    {
        public RoleModel()
        {
            RolesList = new List<RoleModel>();
        }

        public DataTableRequest Request { get; set; }
        public List<RoleModel> RolesList { get; set; }
    }

    public class RoleDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsAdmin { get; set; }
        public int Status { get; set; }
        public string StatusText => EnumHelperMethods.GetEnumDescription<EnumHelper.Status>(Status);
    }

    public class AddEditRoleDetail
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Role name is required.")]
        [StringLength(maximumLength: 500, ErrorMessage = "Role name cannot more then 500 character.")]
        public string Name { get; set; }

        [StringLength(maximumLength: 10000, ErrorMessage = "Description cannot more then 10000 character.")]
        public string Description { get; set; }
    }

    public class RoleStatusModel
    {
        [Required(ErrorMessage = "Id is required.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Status Id is required.")]
        public int StatusId { get; set; }
    }

    
    public class RoleGetDeleteModel
    {
        [Required(ErrorMessage = "Id is required.")]
        public int Id { get; set; }
    }
}
