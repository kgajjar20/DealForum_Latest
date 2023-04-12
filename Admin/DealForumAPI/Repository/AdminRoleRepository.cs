using DealForumAPI.CustomBindings;
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

namespace DealForumAPI.Repository
{
    public class AdminRoleRepository : IAdminRole
    {
        private DealForumContext _context;

        public AdminRoleRepository(DealForumContext context)
        {
            _context = context;
        }

        public async Task<DataTableResponse> GetRolesList(RoleModel model)
        {
            DataTableResponse response = new DataTableResponse();
            if (model.Request != null)
            {

                IQueryable<RoleDetails> roles = (from x in _context.Role
                                                 where x.Status != (int)Status.Deleted
                                                 select new RoleDetails()
                                                 {
                                                     Id = x.Id,
                                                     IsAdmin = x.Isadmin,
                                                     Description = x.Description,
                                                     Name = x.Name,
                                                     Status = x.Status
                                                 }).AsQueryable();

                //Searching
                roles = roles.ApplySearching(model.Request);

                //Total Records Count
                var totalRecords = await roles.CountAsync();

                // Sort Data
                roles = roles.ApplySorting(model.Request);

                //Paging
                var pagedRoles = roles.ApplyPaging(model.Request);


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

        public async Task<APIResponseModel> AddUpdateRole(AddEditRoleDetail model, IActionTracking _actionTracking, Guid modifiedBy)
        {
            APIResponseModel response = new APIResponseModel();

            #region Update Role
            if (model.Id != null && model.Id > 0)
            {
                Role role = await _context.Role.Where(x => x.Id == model.Id && x.Status != (int)Status.Deleted).FirstOrDefaultAsync();
                if (role != null)
                {
                    bool sameRoleNameExist = _context.Role.Where(x => x.Name.ToLower().Trim() == model.Name.ToLower().Trim() && x.Id != model.Id && x.Status != (int)Status.Deleted).Any();
                    if (sameRoleNameExist)
                    {
                        response.Code = (int)ResponseCode.BadRequest;
                        response.Status = false;
                        response.Message = string.Format(SharedResource.AlreadyExist, "Role name :" + model.Name);
                        return response;
                    }
                    else if (role.Isadmin == true)
                    {
                        response.Code = (int)ResponseCode.BadRequest;
                        response.Status = false;
                        response.Message = string.Format(AdminResource.ContactAdminToUpdate, "Role");
                        return response;
                    }
                    else
                    {
                        role.Name = model.Name;
                        role.Description = model.Description;
                        role.Modifiedby = modifiedBy;
                        role.Modifieddate = DateTime.Now;
                        await _context.SaveChangesAsync();

                        await _actionTracking.SaveAPIActionTracking((int)Common.Common.APITrackingType.Edit, $"AddUpdateRole Action Tracking Data");

                        response.Code = (int)ResponseCode.OK;
                        response.Status = true;
                        response.Message = string.Format(SharedResource.Updated, "Role");
                        return response;
                    }
                }
                else
                {
                    response.Code = (int)ResponseCode.BadRequest;
                    response.Status = false;
                    response.Message = string.Format(SharedResource.NotFound, "Role");
                    return response;
                }
            }

            #endregion

            #region Add Role
            else
            {
                bool sameRoleNameExist = _context.Role.Where(x => x.Name.ToLower().Trim() == model.Name.ToLower().Trim() && x.Status != (int)Status.Deleted).Any();
                if (sameRoleNameExist)
                {
                    response.Code = (int)ResponseCode.BadRequest;
                    response.Status = false;
                    response.Message = string.Format(SharedResource.AlreadyExist, "Role Name:" + model.Name);
                    return response;
                }
                else
                {
                    Role newRole = new Role();
                    newRole.Name = model.Name;
                    newRole.Description = model.Description;
                    newRole.Isadmin = false;
                    newRole.Status = (int)Status.Active;
                    newRole.Createdby = modifiedBy;
                    newRole.Createddate = DateTime.Now;
                    _context.Role.Add(newRole);
                    await _context.SaveChangesAsync();

                    await _actionTracking.SaveAPIActionTracking((int)Common.Common.APITrackingType.Add, $"AddUpdateRole Action Tracking Data");

                    response.Code = (int)ResponseCode.OK;
                    response.Status = true;
                    response.Message = string.Format(SharedResource.Added, "Role");
                    return response;

                }
            }

            #endregion
        }

        public async Task<APIResponseModel> ChangeRoleStatus(RoleStatusModel model, IActionTracking _actionTracking, Guid modifiedBy)
        {
            APIResponseModel response = new APIResponseModel();

            var statusList = EnumHelperMethods.GetEnumList<Status>();
            if (statusList.Where(x => x.Value == model.StatusId && x.Value != (int)Status.Deleted).Any())
            {
                var role = await _context.Role.Where(x => x.Id == model.Id && x.Status != (int)Status.Deleted).FirstOrDefaultAsync();
                if (role == null)
                {
                    response.Code = (int)ResponseCode.BadRequest;
                    response.Status = false;
                    response.Message = string.Format(SharedResource.NotFound, "Role");
                    return response;
                }
                else if (role.Isadmin == true)
                {
                    response.Code = (int)ResponseCode.BadRequest;
                    response.Status = false;
                    response.Message = string.Format(AdminResource.ContactAdminToUpdate, "Role");
                    return response;
                }
                else
                {
                    role.Status = model.StatusId;
                    role.Modifiedby = modifiedBy;
                    role.Modifieddate = DateTime.Now;
                    await _context.SaveChangesAsync();

                    await _actionTracking.SaveAPIActionTracking((int)Common.Common.APITrackingType.StatusChange, $"ChangeRoleStatus Action Tracking Data");

                    response.Code = (int)ResponseCode.OK;
                    response.Status = true;
                    response.Message = string.Format(model.StatusId == (int)Status.Active ? SharedResource.Activated : SharedResource.InActivated, "Role");
                    return response;
                }
            }
            else
            {
                response.Code = (int)ResponseCode.BadRequest;
                response.Status = false;
                response.Message = string.Format(SharedResource.NotValid, "Role Status");
                return response;
            }
        }

        public async Task<APIResponseModel> DeleteRole(int Id, IActionTracking _actionTracking, Guid modifiedBy)
        {
            APIResponseModel response = new APIResponseModel();
            var role = await _context.Role.Where(x => x.Id == Id && x.Status != (int)Status.Deleted).FirstOrDefaultAsync();
            var roleMappingExist = await _context.Usermapping.Where(x => x.Roleid == Id).AnyAsync();
            if (role == null)
            {
                response.Code = (int)ResponseCode.BadRequest;
                response.Status = false;
                response.Message = string.Format(SharedResource.NotFound, "Role");
                return response;
            }
            else if (role.Isadmin == true)
            {
                response.Code = (int)ResponseCode.BadRequest;
                response.Status = false;
                response.Message = string.Format(AdminResource.ContactAdminToDelete, "Role");
                return response;
            }
            else if (roleMappingExist == true)
            {
                response.Code = (int)ResponseCode.BadRequest;
                response.Status = false;
                response.Message = AdminResource.RoleIsInUse;
                return response;
            }
            else
            {
                role.Status = (int)Status.Deleted;
                role.Modifiedby = modifiedBy;
                role.Modifieddate = DateTime.Now;
                await _context.SaveChangesAsync();

                await _actionTracking.SaveAPIActionTracking((int)Common.Common.APITrackingType.Delete, $"Delete Role Action Tracking Data");

                response.Code = (int)ResponseCode.OK;
                response.Status = true;
                response.Message = string.Format(SharedResource.Deleted, "Role");
                return response;
            }
        }

        public async Task<APIResponseModel> GetRole(int Id, IActionTracking _actionTracking, Guid modifiedBy)
        {
            APIResponseModel response = new APIResponseModel();
            var role = await _context.Role.Where(x => x.Id == Id && x.Status != (int)Status.Deleted).FirstOrDefaultAsync();
            if (role == null)
            {
                response.Code = (int)ResponseCode.BadRequest;
                response.Status = false;
                response.Message = string.Format(SharedResource.NotFound, "Role");
                return response;
            }
            else
            {
                AddEditRoleDetail model = new AddEditRoleDetail
                {
                    Description = role.Description,
                    Id = role.Id,
                    Name = role.Name
                };
                await _actionTracking.SaveAPIActionTracking((int)Common.Common.APITrackingType.View, $"Get Role Action Tracking Data For Id:" + Id);
                response.Code = (int)ResponseCode.OK;
                response.Status = true;
                response.Data = JsonConvert.SerializeObject(model, Formatting.Indented);
                return response;
            }
        }
    }
}
