using DealForumAPI.Common;
using DealForumAPI.DB;
using DealForumLibrary.Models;
using DealForumLibrary.Models.AdminAreaModels;
using DealForumLibrary.Models.Datatables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealForumAPI.Interface
{
    public interface IAdminForum
    {
        Task<DataTableResponse> GetForumsList(ForumModel model);
        Task<List<ForumDetail>> GetForumsList();
        Task<APIResponseModel> AddUpdateForum(AddEditForumDetail model, IActionTracking _actionTracking, Guid modifiedBy);
        Task<APIResponseModel> ChangeForumStatus(ForumStatusModel model, IActionTracking _actionTracking, Guid modifiedBy);
        Task<APIResponseModel> DeleteForum(Guid Id, IActionTracking _actionTracking, Guid modifiedBy);
        Task<APIResponseModel> GetForum(Guid Id, IActionTracking _actionTracking);
        Task<Forum> GetForumById(Guid Id);
    }
}
