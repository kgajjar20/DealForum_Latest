using DealForumLibrary.CustomAttributeHelper;
using DealForumLibrary.Models.Datatables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DealForumLibrary.Models.AdminAreaModels
{
    public class DealModel
    {
        public DealModel()
        {
            DealsList = new List<DealModel>();
        }

        public DataTableRequest Request { get; set; }
        public List<DealModel> DealsList { get; set; }

    }

    public class DealDetail
    {
        public Guid Id { get; set; }
        public string DealTitle { get; set; }
        public Guid ForumId { get; set; }
        public string ForumName { get; set; }
        public string DealLink { get; set; }
        public DateTime? DealStartDate { get; set; }
        public string DealStartDateStr => DealStartDate != null ? DealStartDate.Value.ToString("dd/MM/yyyy") : string.Empty;
        public DateTime? DealExpiryDate { get; set; }
        public string DealExpiryDateStr => DealExpiryDate != null ? DealExpiryDate.Value.ToString("dd/MM/yyyy") : string.Empty;
        public decimal DealPrice { get; set; }
        public decimal RetailPrice { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public string StatusText => EnumHelperMethods.GetEnumDescription<EnumHelper.Status>(Status);
    }



    public class AddEditDealDetail
    {
        public AddEditDealDetail()
        {
            ForumList = new List<TextValueGuid>() { };
        }

        [NotEmpty]
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(2000, ErrorMessage = "Title cannot more then 2000 characters.")]
        public string DealTitle { get; set; }

        [Required(ErrorMessage = "Please select Forum.")]
        [NotEmpty]
        public Guid ForumId { get; set; }

        [StringLength(maximumLength: 10000, ErrorMessage = "Deal link cannot more then 10000 character.")]
        [Url(ErrorMessage = "Deal link is not valid.")]
        public string DealLink { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(maximumLength: 10000, ErrorMessage = "Description cannot more then 10000 character.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Deal Price is required.")]
        public decimal DealPrice { get; set; }

        [Required(ErrorMessage = "Retail Price is required.")]
        public decimal RetailPrice { get; set; }

        [DataType(DataType.Date)]

        public DateTime? DealStartDate { get; set; }


        [DataType(DataType.Date)]
        [CurrentDate(ErrorMessage = "Deal Expiry Date must be after or equal to today's date.")]
        public DateTime? DealExpiryDate { get; set; }

        public List<TextValueGuid> ForumList { get; set; }

    }

    public class DealStatusModel
    {
        [Required(ErrorMessage = "Id is required.")]
        [NotEmpty]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Status Id is required.")]
        public int StatusId { get; set; }
    }

    public class DealGetDeleteModel
    {
        [Required(ErrorMessage = "Id is required.")]
        [NotEmpty]
        public Guid Id { get; set; }
    }


}
