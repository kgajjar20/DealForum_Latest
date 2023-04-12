using DealForumAPI.Common;
using DealForumLibrary.Models;
using DealForumLibrary.Models.AdminAreaModels;
using DealForumLibrary.Models.Datatables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealForumAPI.Interface
{
    public interface IAdminRole
    {
        Task<DataTableResponse> GetRolesList(RoleModel model);
        Task<APIResponseModel> AddUpdateRole(AddEditRoleDetail model, IActionTracking actionTracking,Guid modifiedBy);
        Task<APIResponseModel> ChangeRoleStatus(RoleStatusModel model, IActionTracking actionTracking,Guid modifiedBy);
        Task<APIResponseModel> DeleteRole(int Id, IActionTracking actionTracking, Guid modifiedBy);
        Task<APIResponseModel> GetRole(int Id, IActionTracking actionTracking, Guid modifiedBy);
    }
}
