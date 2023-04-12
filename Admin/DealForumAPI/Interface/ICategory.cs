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
    public interface ICategory
    {
        Task<APIResponseModel> AddUpdateCategory(AddEditCategoryDetail model, IActionTracking _actionTracking, Guid modifiedBy);
        Task<DataTableResponse> GetCategoriesList(CategoryModel model);
        Task<APIResponseModel> ChangeCategoryStatus(CategoryStatusModel model, IActionTracking _actionTracking, Guid modifiedBy);
        Task<APIResponseModel> DeleteCategory(int Id, IActionTracking _actionTracking, Guid modifiedBy);
        Task<APIResponseModel> GetCategory(int Id, IActionTracking _actionTracking, Guid modifiedBy);
    }
}
