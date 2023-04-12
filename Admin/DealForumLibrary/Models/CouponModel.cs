using DealForumLibrary.CustomAttributeHelper;
using DealForumLibrary.Models.Datatables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DealForumLibrary.Models
{
    public class CouponModel
    {
        public CouponModel()
        {
            CouponsList = new List<CouponModel>();
        }

        public DataTableRequest Request { get; set; }
        public List<CouponModel> CouponsList { get; set; }
    }

    public class CouponDetail
    {
        public int Id { get; set; }
        public string CouponTitle { get; set; }
        public string CouponCode { get; set; }
        public string CouponLink { get; set; }
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public DateTime? CouponExpiry { get; set; }
        public string CouponExpiryStr => CouponExpiry != null ? CouponExpiry.Value.ToString("dd/MM/yyyy") : string.Empty;
        public string Description { get; set; }
        public int Status { get; set; }
        public string StatusText => EnumHelperMethods.GetEnumDescription<EnumHelper.Status>(Status);
    }

    public class AddEditCouponDetail
    {
        public AddEditCouponDetail()
        {
            StoreList = new List<TextIntValue>() { };
        }

        public int? Id { get; set; }

        [Required(ErrorMessage = "Coupon title is required.")]
        [StringLength(maximumLength: 1000, ErrorMessage = "Coupon name cannot more then 1000 character.")]
        public string CouponTitle { get; set; }


        [Required(ErrorMessage = "Coupon Code is required.")]
        [StringLength(maximumLength: 500, ErrorMessage = "Coupon code cannot more then 500 character.")]
        public string CouponCode { get; set; }


        [StringLength(maximumLength: 10000, ErrorMessage = "Coupon link cannot more then 10000 character.")]
        [Url(ErrorMessage = "Coupon link is not valid.")]
        public string CouponLink { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(maximumLength: 10000, ErrorMessage = "Description cannot more then 10000 character.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Store is required.")]
        public int StoreId { get; set; }

        [DataType(DataType.Date)]
        [CurrentDate(ErrorMessage = "Coupon Expiry must be after or equal to today's date.")]
        public DateTime? CouponExpiry { get; set; }
        public string CouponExpiryStr => CouponExpiry != null ? CouponExpiry.Value.ToString("dd/MM/yyyy") : string.Empty;
        public List<TextIntValue> StoreList { get; set; }
    }

    public class CouponStatusModel
    {
        [Required(ErrorMessage = "Id is required.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Status Id is required.")]
        public int StatusId { get; set; }
    }

    public class CouponGetDeleteModel
    {
        [Required(ErrorMessage = "Id is required.")]
        public int Id { get; set; }
    }


}
