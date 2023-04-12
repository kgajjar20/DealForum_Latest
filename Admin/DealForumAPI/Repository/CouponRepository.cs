using DealForumAPI.Common;
using DealForumAPI.DB;
using DealForumAPI.Interface;
using DealForumAPI.Resources;
using DealForumLibrary;
using DealForumLibrary.Models;
using DealForumLibrary.Models.AdminAreaModels;
using DealForumLibrary.Models.Datatables;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DealForumLibrary.EnumHelper;
using DealForumAPI.CustomBindings;

namespace DealForumAPI.Repository
{
    public class CouponRepository : ICoupon
    {
        #region Member Declaration
        private DealForumContext _context;
        public CouponRepository(DealForumContext context)
        {
            _context = context;
        }

        #endregion

        #region Get Coupons List
        public async Task<DataTableResponse> GetCouponsList(CouponModel model)
        {
            DataTableResponse response = new DataTableResponse();
            if (model.Request != null)
            {

                IQueryable<CouponDetail> Coupons = (from x in _context.Coupon
                                                    join y in _context.Store on x.Storeid equals y.Id
                                                    where x.Status != (int)Status.Deleted
                                                    select new CouponDetail()
                                                    {
                                                        Id = x.Id,
                                                        CouponCode = x.Couponcode,
                                                        CouponExpiry = x.Couponexpiry,
                                                        CouponLink = x.Couponlink,
                                                        CouponTitle = x.Coupontitle,
                                                        StoreId = x.Storeid,
                                                        StoreName = y.Name,
                                                        Description = x.Description,
                                                        Status = x.Status
                                                    }).AsQueryable();

                //Searching
                Coupons = Coupons.ApplySearching(model.Request);

                //Total Records Count
                var totalRecords = await Coupons.CountAsync();

                // Sort Data
                Coupons = Coupons.ApplySorting(model.Request);

                //Paging
                var pagedRoles = Coupons.ApplyPaging(model.Request);


                response.draw = model.Request.Draw;
                response.recordsTotal = totalRecords;
                response.recordsFiltered = totalRecords;
                response.data = pagedRoles.ToArray();
                response.error = string.Empty;
            }
            else
            {
                response.error = SharedResource.RequestCannotNull;
            }
            return response;

        }

        #endregion

        #region Add Update Coupon
        public async Task<APIResponseModel> AddUpdateCoupon(AddEditCouponDetail model, IActionTracking _actionTracking, Guid modifiedBy)
        {
            APIResponseModel response = new APIResponseModel();

            #region Update Coupon
            if (model.Id != null && model.Id > 0)
            {
                Coupon Coupon = await _context.Coupon.Where(x => x.Id == model.Id && x.Status != (int)Status.Deleted).FirstOrDefaultAsync();
                if (Coupon != null)
                {
                    bool sameCouponNameExist = _context.Coupon.Where(x => x.Couponcode.ToLower().Trim() == model.CouponCode.ToLower().Trim() && x.Id != model.Id && x.Status != (int)Status.Deleted
                                                && x.Coupontitle.ToLower().Trim() == model.CouponTitle.ToLower().Trim() && x.Couponlink.ToLower().Trim() == model.CouponLink.ToLower().Trim()
                                                && x.Couponexpiry == model.CouponExpiry).Any();
                    if (sameCouponNameExist)
                    {
                        response.Code = (int)ResponseCode.BadRequest;
                        response.Status = false;
                        response.Message = string.Format(SharedResource.AlreadyExist, "Same Coupon");
                        return response;
                    }
                    else
                    {
                        Coupon.Couponcode = model.CouponCode;
                        Coupon.Description = model.Description;
                        Coupon.Couponexpiry = model.CouponExpiry;
                        Coupon.Couponlink = model.CouponLink;
                        Coupon.Coupontitle = model.CouponTitle;
                        Coupon.Storeid = model.StoreId;
                        Coupon.Modifiedby = modifiedBy;
                        Coupon.Modifieddate = DateTime.Now;
                        await _context.SaveChangesAsync();
                        await _actionTracking.SaveAPIActionTracking((int)Common.Common.APITrackingType.Edit, $"AddUpdateCoupon Action Tracking Data");

                        response.Code = (int)ResponseCode.OK;
                        response.Status = true;
                        response.Message = string.Format(SharedResource.Updated, "Coupon");
                        return response;
                    }
                }
                else
                {
                    response.Code = (int)ResponseCode.BadRequest;
                    response.Status = false;
                    response.Message = string.Format(SharedResource.NotFound, "Coupon");
                    return response;
                }
            }

            #endregion

            #region Add Coupon
            else
            {
                bool sameCouponNameExist = _context.Coupon.Where(x => x.Couponcode.ToLower().Trim() == model.CouponCode.ToLower().Trim() && x.Status != (int)Status.Deleted
                            && x.Coupontitle.ToLower().Trim() == model.CouponTitle.ToLower().Trim() && x.Couponlink.ToLower().Trim() == model.CouponLink.ToLower().Trim()
                            && x.Couponexpiry == model.CouponExpiry).Any();

                if (sameCouponNameExist)
                {
                    response.Code = (int)ResponseCode.BadRequest;
                    response.Status = false;
                    response.Message = string.Format(SharedResource.AlreadyExist, "Same Coupon");
                    return response;
                }
                else
                {

                    Coupon newCoupon = new Coupon();
                    newCoupon.Couponcode = model.CouponCode;
                    newCoupon.Description = model.Description;
                    newCoupon.Couponexpiry = model.CouponExpiry;
                    newCoupon.Couponlink = model.CouponLink;
                    newCoupon.Coupontitle = model.CouponTitle;
                    newCoupon.Storeid = model.StoreId;
                    newCoupon.Status = (int)Status.Active;
                    newCoupon.Createdby = modifiedBy;
                    newCoupon.Createddate = DateTime.Now;
                    _context.Coupon.Add(newCoupon);
                    await _context.SaveChangesAsync();

                    await _actionTracking.SaveAPIActionTracking((int)Common.Common.APITrackingType.Add, $"AddUpdateCoupon Action Tracking Data");

                    response.Code = (int)ResponseCode.OK;
                    response.Status = true;
                    response.Message = string.Format(SharedResource.Added, "Coupon");
                    return response;

                }
            }

            #endregion
        }
        #endregion

        #region Change Coupon Status
        public async Task<APIResponseModel> ChangeCouponStatus(CouponStatusModel model, IActionTracking _actionTracking, Guid modifiedBy)
        {
            APIResponseModel response = new APIResponseModel();

            var statusList = EnumHelperMethods.GetEnumList<Status>();
            if (statusList.Where(x => x.Value == model.StatusId && x.Value != (int)Status.Deleted).Any())
            {
                var role = await _context.Coupon.Where(x => x.Id == model.Id && x.Status != (int)Status.Deleted).FirstOrDefaultAsync();
                if (role == null)
                {
                    response.Code = (int)ResponseCode.BadRequest;
                    response.Status = false;
                    response.Message = string.Format(SharedResource.NotFound, "Coupon");
                    return response;
                }
                else
                {
                    role.Status = model.StatusId;
                    role.Modifiedby = modifiedBy;
                    role.Modifieddate = DateTime.Now;
                    await _context.SaveChangesAsync();
                    await _actionTracking.SaveAPIActionTracking((int)Common.Common.APITrackingType.StatusChange, $"ChangeCouponstatus Action Tracking Data");

                    response.Code = (int)ResponseCode.OK;
                    response.Status = true;
                    response.Message = string.Format(model.StatusId == (int)Status.Active ? SharedResource.Activated : SharedResource.InActivated, "Coupon");
                    return response;
                }
            }
            else
            {
                response.Code = (int)ResponseCode.BadRequest;
                response.Status = false;
                response.Message = string.Format(SharedResource.NotValid, "Coupon Status");
                return response;
            }
        }

        #endregion

        #region Delete Coupon
        public async Task<APIResponseModel> DeleteCoupon(int Id, IActionTracking _actionTracking, Guid modifiedBy)
        {
            APIResponseModel response = new APIResponseModel();
            var Coupon = await _context.Coupon.Where(x => x.Id == Id && x.Status != (int)Status.Deleted).FirstOrDefaultAsync();
            if (Coupon == null)
            {
                response.Code = (int)ResponseCode.BadRequest;
                response.Status = false;
                response.Message = string.Format(SharedResource.NotFound, "Coupon");
                return response;
            }
            else
            {
                Coupon.Status = (int)Status.Deleted;
                Coupon.Modifiedby = modifiedBy;
                Coupon.Modifieddate = DateTime.Now;
                await _context.SaveChangesAsync();

                await _actionTracking.SaveAPIActionTracking((int)Common.Common.APITrackingType.Delete, $"Delete Coupon Action Tracking Data");

                response.Code = (int)ResponseCode.OK;
                response.Status = true;
                response.Message = string.Format(SharedResource.Deleted, "Coupon");
                return response;
            }
        }

        #endregion

        #region Get Coupon
        public async Task<APIResponseModel> GetCoupon(int Id, IActionTracking _actionTracking, Guid modifiedBy)
        {
            APIResponseModel response = new APIResponseModel();
            var Coupon = await _context.Coupon.Where(x => x.Id == Id && x.Status != (int)Status.Deleted).FirstOrDefaultAsync();
            if (Coupon == null)
            {
                response.Code = (int)ResponseCode.BadRequest;
                response.Status = false;
                response.Message = string.Format(SharedResource.NotFound, "Coupon");
                return response;
            }
            else
            {
                AddEditCouponDetail model = new AddEditCouponDetail
                {
                    Description = Coupon.Description,
                    Id = Coupon.Id,
                    StoreId = Coupon.Storeid,
                    CouponTitle = Coupon.Coupontitle,
                    CouponCode = Coupon.Couponcode,
                    CouponExpiry = Coupon.Couponexpiry,
                    CouponLink = Coupon.Couponlink,
                    StoreList = (from x in _context.Store where x.Status == (int)Status.Active select new TextIntValue() { Text = x.Name, Value = x.Id }).ToList(),
                };

                await _actionTracking.SaveAPIActionTracking((int)Common.Common.APITrackingType.View, $"Get Coupon Action Tracking Data For Id:" + Id);
                response.Code = (int)ResponseCode.OK;
                response.Status = true;
                response.Data = JsonConvert.SerializeObject(model, Formatting.Indented);
                return response;
            }
        }

        #endregion
    }
}
