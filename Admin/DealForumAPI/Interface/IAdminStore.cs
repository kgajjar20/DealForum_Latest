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
    public interface IAdminStore
    {
        Task<APIResponseModel> AddUpdateStore(AddEditStoreDetail model, IActionTracking _actionTracking, Guid modifiedBy);
        Task<DataTableResponse> GetStoresList(StoreModel model);
        Task<List<StoreDetail>> GetStoresList();
        Task<APIResponseModel> ChangeStoreStatus(StoreStatusModel model, IActionTracking _actionTracking, Guid modifiedBy);
        Task<APIResponseModel> DeleteStore(int Id, IActionTracking _actionTracking, Guid modifiedBy);
        Task<APIResponseModel> GetStore(int Id, IActionTracking _actionTracking);
        Task<Store> GetStoreById(int Id);
    }
}
