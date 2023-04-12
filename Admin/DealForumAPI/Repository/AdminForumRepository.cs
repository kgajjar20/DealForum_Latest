using DealForumAPI.Common;
using DealForumAPI.CustomBindings;
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

namespace DealForumAPI.Repository
{
    public class AdminForumRepository : IAdminForum
    {

        private DealForumContext _context;

        public AdminForumRepository(DealForumContext context)
        {
            _context = context;
        }

        #region Get Forums List
        public async Task<DataTableResponse> GetForumsList(ForumModel model)
        {
            DataTableResponse response = new DataTableResponse();
            if (model.Request != null)
            {

                IQueryable<ForumDetail> list = (from x in _context.Forum
                                                where x.Status != (int)Status.Deleted
                                                select new ForumDetail()
                                                {
                                                    Id = x.Id,
                                                    Name = x.Forumname,
                                                    Status = x.Status
                                                }).AsQueryable();

                //Searching
                list = list.ApplySearching(model.Request);

                //Total Records Count
                var totalRecords = await list.CountAsync();

                // Sort Data
                list = list.ApplySorting(model.Request);

                //Paging
                var pagedRoles = list.ApplyPaging(model.Request);


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

        #region Get Forums List
        public async Task<List<ForumDetail>> GetForumsList()
        {
            List<ForumDetail> forums = await (from x in _context.Forum
                                              where x.Status != (int)Status.Deleted
                                              select new ForumDetail()
                                              {
                                                  Id = x.Id,
                                                  Name = x.Forumname,
                                                  Status = x.Status
                                              }).ToListAsync();
            return forums;

        }
        #endregion

        #region Add Update Forum
        public async Task<APIResponseModel> AddUpdateForum(AddEditForumDetail model, IActionTracking _actionTracking, Guid modifiedBy)
        {
            APIResponseModel response = new APIResponseModel();

            #region Update Forum
            if (model.Id != null && model.Id != Guid.Empty)
            {
                Forum Forum = await _context.Forum.Where(x => x.Id == model.Id && x.Status != (int)Status.Deleted).FirstOrDefaultAsync();
                if (Forum != null)
                {
                    bool sameForumNameExist = _context.Forum.Where(x => x.Forumname.ToLower().Trim() == model.Name.ToLower().Trim() && x.Id != model.Id && x.Status != (int)Status.Deleted).Any();
                    if (sameForumNameExist)
                    {
                        response.Code = (int)ResponseCode.BadRequest;
                        response.Status = false;
                        response.Message = string.Format(SharedResource.AlreadyExist, "Forum name :" + model.Name);
                        return response;
                    }
                    else
                    {
                        Forum.Forumname = model.Name;
                        Forum.Modifiedby = modifiedBy;
                        Forum.Modifieddate = DateTime.Now;
                        await _context.SaveChangesAsync();

                        await _actionTracking.SaveAPIActionTracking((int)Common.Common.APITrackingType.Edit, $"AddUpdateForum Action Tracking Data");

                        response.Code = (int)ResponseCode.OK;
                        response.Status = true;
                        response.Message = string.Format(SharedResource.Updated, "Forum");
                        return response;
                    }
                }
                else
                {
                    response.Code = (int)ResponseCode.BadRequest;
                    response.Status = false;
                    response.Message = string.Format(SharedResource.NotFound, "Forum");
                    return response;
                }
            }

            #endregion

            #region Add Forum
            else
            {
                bool sameForumNameExist = _context.Forum.Where(x => x.Forumname.ToLower().Trim() == model.Name.ToLower().Trim() && x.Status != (int)Status.Deleted).Any();
                if (sameForumNameExist)
                {
                    response.Code = (int)ResponseCode.BadRequest;
                    response.Status = false;
                    response.Message = string.Format(SharedResource.AlreadyExist, "Forum Name:" + model.Name);
                    return response;
                }
                else
                {

                    Forum newForum = new Forum();
                    newForum.Forumname = model.Name;
                    newForum.Status = (int)Status.Active;
                    newForum.Createdby = modifiedBy;
                    newForum.Createddate = DateTime.Now;
                    _context.Forum.Add(newForum);
                    await _context.SaveChangesAsync();

                    await _actionTracking.SaveAPIActionTracking((int)Common.Common.APITrackingType.Add, $"AddUpdateForum Action Tracking Data");

                    response.Code = (int)ResponseCode.OK;
                    response.Status = true;
                    response.Message = string.Format(SharedResource.Added, "Forum");
                    return response;

                }
            }

            #endregion
        }
        #endregion

        #region Change Forum Status
        public async Task<APIResponseModel> ChangeForumStatus(ForumStatusModel model, IActionTracking _actionTracking, Guid modifiedBy)
        {
            APIResponseModel response = new APIResponseModel();

            var statusList = EnumHelperMethods.GetEnumList<Status>();
            if (statusList.Where(x => x.Value == model.StatusId && x.Value != (int)Status.Deleted).Any())
            {
                var role = await _context.Forum.Where(x => x.Id == model.Id && x.Status != (int)Status.Deleted).FirstOrDefaultAsync();
                if (role == null)
                {
                    response.Code = (int)ResponseCode.BadRequest;
                    response.Status = false;
                    response.Message = string.Format(SharedResource.NotFound, "Forum");
                    return response;
                }
                else
                {
                    role.Status = model.StatusId;
                    role.Modifiedby = modifiedBy;
                    role.Modifieddate = DateTime.Now;
                    await _context.SaveChangesAsync();
                    await _actionTracking.SaveAPIActionTracking((int)Common.Common.APITrackingType.StatusChange, $"ChangeForumStatus Action Tracking Data");

                    response.Code = (int)ResponseCode.OK;
                    response.Status = true;
                    response.Message = string.Format(model.StatusId == (int)Status.Active ? SharedResource.Activated : SharedResource.InActivated, "Forum");
                    return response;
                }
            }
            else
            {
                response.Code = (int)ResponseCode.BadRequest;
                response.Status = false;
                response.Message = string.Format(SharedResource.NotValid, "Forum Status");
                return response;
            }
        }

        #endregion

        #region Delete Forum
        public async Task<APIResponseModel> DeleteForum(Guid Id, IActionTracking _actionTracking, Guid modifiedBy)
        {
            APIResponseModel response = new APIResponseModel();
            var Forum = await _context.Forum.Where(x => x.Id == Id && x.Status != (int)Status.Deleted).FirstOrDefaultAsync();
            if (Forum == null)
            {
                response.Code = (int)ResponseCode.BadRequest;
                response.Status = false;
                response.Message = string.Format(SharedResource.NotFound, "Forum");
                return response;
            }
            else
            {
                Forum.Status = (int)Status.Deleted;
                Forum.Modifiedby = modifiedBy;
                Forum.Modifieddate = DateTime.Now;
                await _context.SaveChangesAsync();

                await _actionTracking.SaveAPIActionTracking((int)Common.Common.APITrackingType.Delete, $"Delete Forum Action Tracking Data");

                response.Code = (int)ResponseCode.OK;
                response.Status = true;
                response.Message = string.Format(SharedResource.Deleted, "Forum");
                return response;
            }
        }

        #endregion

        #region Get Forum
        public async Task<APIResponseModel> GetForum(Guid Id, IActionTracking _actionTracking)
        {
            APIResponseModel response = new APIResponseModel();
            var Forum = await _context.Forum.Where(x => x.Id == Id && x.Status != (int)Status.Deleted).FirstOrDefaultAsync();
            if (Forum == null)
            {
                response.Code = (int)ResponseCode.BadRequest;
                response.Status = false;
                response.Message = string.Format(SharedResource.NotFound, "Forum");
                return response;
            }
            else
            {
                AddEditForumDetail model = new AddEditForumDetail
                {
                    Id = Forum.Id,
                    Name = Forum.Forumname,
                };
                await _actionTracking.SaveAPIActionTracking((int)Common.Common.APITrackingType.View, $"Get Forum Action Tracking Data For Id:" + Id);
                response.Code = (int)ResponseCode.OK;
                response.Status = true;
                response.Data = JsonConvert.SerializeObject(model, Formatting.Indented);
                return response;
            }
        }

        #endregion

        #region Get Forum By Id
        public async Task<Forum> GetForumById(Guid Id)
        {
            return await _context.Forum.Where(x => x.Id == Id && x.Status != (int)Status.Deleted).FirstOrDefaultAsync();
        }

        #endregion

    }
}
