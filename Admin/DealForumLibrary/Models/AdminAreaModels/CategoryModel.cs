using DealForumLibrary.Models.Datatables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DealForumLibrary.Models.AdminAreaModels
{
    public class CategoryModel
    {
        public CategoryModel()
        {
            CategorysList = new List<CategoryModel>();
        }
        public DataTableRequest Request { get; set; }
        public List<CategoryModel> CategorysList { get; set; }
    }

    public class CategoryDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public string StatusText => EnumHelperMethods.GetEnumDescription<EnumHelper.Status>(Status);
    }

    public class AddEditCategoryDetail
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Category name is required.")]
        [StringLength(maximumLength: 500, ErrorMessage = "Category name cannot more then 500 character.")]
        public string Name { get; set; }

        [StringLength(maximumLength: 10000, ErrorMessage = "Description cannot more then 10000 character.")]
        public string Description { get; set; }
    }

    public class CategoryStatusModel
    {
        [Required(ErrorMessage = "Id is required.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Status Id is required.")]
        public int StatusId { get; set; }
    }

    public class CategoryGetDeleteModel
    {
        [Required(ErrorMessage = "Id is required.")]
        public int Id { get; set; }
    }

}
