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
    public class AdminStoreRepository : IAdminStore
    {
        private DealForumContext _context;

        public AdminStoreRepository(DealForumContext context)
        {
            _context = context;
        }

        #region Get Stores List
        public async Task<DataTableResponse> GetStoresList(StoreModel model)
        {
            DataTableResponse response = new DataTableResponse();
            if (model.Request != null)
            {

                IQueryable<StoreDetail> stores = (from x in _context.Store
                                                  where x.Status != (int)Status.Deleted
                                                  select new StoreDetail()
                                                  {
                                                      Id = x.Id,
                                                      Description = x.Description,
                                                      Logo = x.Logo,
                                                      Name = x.Name,
                                                      Websitelink = x.Websitelink,
                                                      Status = x.Status
                                                  }).AsQueryable();

                //Searching
                stores = stores.ApplySearching(model.Request);

                //Total Records Count
                var totalRecords = await stores.CountAsync();

                // Sort Data
                stores = stores.ApplySorting(model.Request);

                //Paging
                var pagedRoles = stores.ApplyPaging(model.Request);


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

        public async Task<List<StoreDetail>> GetStoresList()
        {
            List<StoreDetail> stores = await (from x in _context.Store
                                              where x.Status != (int)Status.Deleted
                                              select new StoreDetail()
                                              {
                                                  Id = x.Id,
                                                  Description = x.Description,
                                                  Logo = x.Logo,
                                                  Name = x.Name,
                                                  Websitelink = x.Websitelink,
                                                  Status = x.Status
                                              }).ToListAsync();
            return stores;

        }


        #endregion

        #region Add Update Store
        public async Task<APIResponseModel> AddUpdateStore(AddEditStoreDetail model, IActionTracking _actionTracking, Guid modifiedBy)
        {
            APIResponseModel response = new APIResponseModel();

            #region Update Store
            if (model.Id != null && model.Id > 0)
            {
                Store store = await _context.Store.Where(x => x.Id == model.Id && x.Status != (int)Status.Deleted
                ).FirstOrDefaultAsync();
                if (store != null)
                {
                    bool sameStoreNameExist = _context.Store.Where(x => x.Name.ToLower().Trim() == model.Name.ToLower().Trim() && x.Id != model.Id && x.Status != (int)Status.Deleted).Any();
                    if (sameStoreNameExist)
                    {
                        response.Code = (int)ResponseCode.BadRequest;
                        response.Status = false;
                        response.Message = string.Format(SharedResource.AlreadyExist, "Store name :" + model.Name);
                        return response;
                    }
                    else
                    {
                        store.Name = model.Name;
                        store.Logo = model.StoreLogo != null ? model.StoreLogo : store.Logo;
                        store.Description = model.Description;
                        store.Websitelink = model.WebsiteLink;
                        store.Modifiedby = modifiedBy;
                        store.Modifieddate = DateTime.Now;
                        await _context.SaveChangesAsync();

                        await _actionTracking.SaveAPIActionTracking((int)Common.Common.APITrackingType.Edit, $"AddUpdateStore Action Tracking Data");

                        response.Code = (int)ResponseCode.OK;
                        response.Status = true;
                        response.Message = string.Format(SharedResource.Updated, "Store");
                        return response;
                    }
                }
                else
                {
                    response.Code = (int)ResponseCode.BadRequest;
                    response.Status = false;
                    response.Message = string.Format(SharedResource.NotFound, "Store");
                    return response;
                }
            }

            #endregion

            #region Add Store
            else
            {
                bool sameStoreNameExist = _context.Store.Where(x => x.Name.ToLower().Trim() == model.Name.ToLower().Trim() && x.Status != (int)Status.Deleted).Any();
                if (sameStoreNameExist)
                {
                    response.Code = (int)ResponseCode.BadRequest;
                    response.Status = false;
                    response.Message = string.Format(SharedResource.AlreadyExist, "Store Name:" + model.Name);
                    return response;
                }
                else
                {

                    Store newStore = new Store();
                    newStore.Name = model.Name;
                    newStore.Description = model.Description;
                    newStore.Logo = model.StoreLogo;
                    newStore.Status = (int)Status.Active;
                    newStore.Websitelink = model.WebsiteLink;
                    newStore.Createdby = modifiedBy;
                    newStore.Createddate = DateTime.Now;
                    _context.Store.Add(newStore);
                    await _context.SaveChangesAsync();

                    await _actionTracking.SaveAPIActionTracking((int)Common.Common.APITrackingType.Add, $"AddUpdateStore Action Tracking Data");

                    response.Code = (int)ResponseCode.OK;
                    response.Status = true;
                    response.Message = string.Format(SharedResource.Added, "Store");
                    return response;

                }
            }

            #endregion
        }
        #endregion

        #region Change Store Status
        public async Task<APIResponseModel> ChangeStoreStatus(StoreStatusModel model, IActionTracking _actionTracking, Guid modifiedBy)
        {
            APIResponseModel response = new APIResponseModel();

            var statusList = EnumHelperMethods.GetEnumList<Status>();
            if (statusList.Where(x => x.Value == model.StatusId && x.Value != (int)Status.Deleted).Any())
            {
                var role = await _context.Store.Where(x => x.Id == model.Id && x.Status != (int)Status.Deleted).FirstOrDefaultAsync();
                if (role == null)
                {
                    response.Code = (int)ResponseCode.BadRequest;
                    response.Status = false;
                    response.Message = string.Format(SharedResource.NotFound, "Store");
                    return response;
                }
                else
                {
                    role.Status = model.StatusId;
                    role.Modifiedby = modifiedBy;
                    role.Modifieddate = DateTime.Now;
                    await _context.SaveChangesAsync();
                    await _actionTracking.SaveAPIActionTracking((int)Common.Common.APITrackingType.StatusChange, $"ChangeStoreStatus Action Tracking Data");

                    response.Code = (int)ResponseCode.OK;
                    response.Status = true;
                    response.Message = string.Format(model.StatusId == (int)Status.Active ? SharedResource.Activated : SharedResource.InActivated, "Store");
                    return response;
                }
            }
            else
            {
                response.Code = (int)ResponseCode.BadRequest;
                response.Status = false;
                response.Message = string.Format(SharedResource.NotValid, "Store Status");
                return response;
            }
        }

        #endregion

        #region Delete Store
        public async Task<APIResponseModel> DeleteStore(int Id, IActionTracking _actionTracking, Guid modifiedBy)
        {
            APIResponseModel response = new APIResponseModel();
            var store = await _context.Store.Where(x => x.Id == Id && x.Status != (int)Status.Deleted).FirstOrDefaultAsync();
            if (store == null)
            {
                response.Code = (int)ResponseCode.BadRequest;
                response.Status = false;
                response.Message = string.Format(SharedResource.NotFound, "Store");
                return response;
            }
            else
            {
                store.Status = (int)Status.Deleted;
                store.Modifiedby = modifiedBy;
                store.Modifieddate = DateTime.Now;
                await _context.SaveChangesAsync();

                await _actionTracking.SaveAPIActionTracking((int)Common.Common.APITrackingType.Delete, $"Delete Store Action Tracking Data");

                response.Code = (int)ResponseCode.OK;
                response.Status = true;
                response.Message = string.Format(SharedResource.Deleted, "Store");
                return response;
            }
        }

        #endregion

        #region Get Store
        public async Task<APIResponseModel> GetStore(int Id, IActionTracking _actionTracking)
        {
            APIResponseModel response = new APIResponseModel();
            var store = await _context.Store.Where(x => x.Id == Id && x.Status != (int)Status.Deleted).FirstOrDefaultAsync();
            if (store == null)
            {
                response.Code = (int)ResponseCode.BadRequest;
                response.Status = false;
                response.Message = string.Format(SharedResource.NotFound, "Store");
                return response;
            }
            else
            {
                AddEditStoreDetail model = new AddEditStoreDetail
                {
                    Description = store.Description,
                    Id = store.Id,
                    Name = store.Name,
                    StoreLogo = store.Logo,
                    WebsiteLink = store.Websitelink,
                };
                await _actionTracking.SaveAPIActionTracking((int)Common.Common.APITrackingType.View, $"Get Store Action Tracking Data For Id:" + Id);
                response.Code = (int)ResponseCode.OK;
                response.Status = true;
                response.Data = JsonConvert.SerializeObject(model, Formatting.Indented);
                return response;
            }
        }

        #endregion

        #region Get Store By Id
        public async Task<Store> GetStoreById(int Id)
        {
            return await _context.Store.Where(x => x.Id == Id && x.Status != (int)Status.Deleted).FirstOrDefaultAsync();
        }

        #endregion
    }
}
