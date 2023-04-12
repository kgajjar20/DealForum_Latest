using DealForumLibrary.CustomAttributeHelper;
using DealForumLibrary.Models.Datatables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DealForumLibrary.Models.AdminAreaModels
{
    public class ForumModel
    {
        public ForumModel()
        {
            ForumsList = new List<ForumModel>();
        }

        public DataTableRequest Request { get; set; }
        public List<ForumModel> ForumsList { get; set; }
    }

    public class ForumDetail
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public string StatusText => EnumHelperMethods.GetEnumDescription<EnumHelper.Status>(Status);
    }

    public class AddEditForumDetail
    {
        [NotEmpty]
        public Guid? Id { get; set; }
        public string Name { get; set; }
    }


    public class ForumStatusModel
    {
        [Required(ErrorMessage = "Id is required.")]
        [NotEmpty]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Status Id is required.")]
        public int StatusId { get; set; }
    }

    public class ForumGetDeleteModel
    {
        [Required(ErrorMessage = "Id is required.")]
        [NotEmpty]
        public Guid Id { get; set; }
    }
}
