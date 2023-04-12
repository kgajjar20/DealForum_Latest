using DealForumAPI.Common;
using DealForumLibrary.Models;
using DealForumLibrary.Models.Datatables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealForumAPI.Interface
{
    public interface ICoupon
    {
        Task<APIResponseModel> AddUpdateCoupon(AddEditCouponDetail model, IActionTracking _actionTracking, Guid modifiedBy);
        Task<DataTableResponse> GetCouponsList(CouponModel model);
        Task<APIResponseModel> ChangeCouponStatus(CouponStatusModel model, IActionTracking _actionTracking, Guid modifiedBy);
        Task<APIResponseModel> DeleteCoupon(int Id, IActionTracking _actionTracking, Guid modifiedBy);
        Task<APIResponseModel> GetCoupon(int Id, IActionTracking _actionTracking, Guid modifiedBy);
    }
}
