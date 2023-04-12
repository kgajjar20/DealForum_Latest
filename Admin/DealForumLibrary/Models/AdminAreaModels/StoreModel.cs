using DealForumLibrary.Models.Datatables;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DealForumLibrary.Models.AdminAreaModels
{
    public class StoreModel
    {
        public StoreModel()
        {
            StoresList = new List<StoreModel>();
        }

        public DataTableRequest Request { get; set; }
        public List<StoreModel> StoresList { get; set; }
    }
    public class StoreDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public string Websitelink { get; set; }
        public int Status { get; set; }
        public string StatusText => EnumHelperMethods.GetEnumDescription<EnumHelper.Status>(Status);
    }

    public class AddEditStoreDetail
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Store name is required.")]
        [StringLength(maximumLength: 500, ErrorMessage = "Store name cannot more then 500 character.")]
        public string Name { get; set; }

        [StringLength(maximumLength: 10000, ErrorMessage = "Description cannot more then 10000 character.")]
        public string Description { get; set; }

        [Url(ErrorMessage = "Website link is not valid.")]
        public string WebsiteLink { get; set; }
        public string StoreLogo { get; set; }
    }

    public class StoreStatusModel
    {
        [Required(ErrorMessage = "Id is required.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Status Id is required.")]
        public int StatusId { get; set; }
    }

    public class StoreGetDeleteModel
    {
        [Required(ErrorMessage = "Id is required.")]
        public int Id { get; set; }
    }



}
