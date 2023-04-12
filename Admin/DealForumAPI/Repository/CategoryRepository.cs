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
    public class CategoryRepository : ICategory
    {
        private DealForumContext _context;

        public CategoryRepository(DealForumContext context)
        {
            _context = context;
        }

        #region Get Categories List
        public async Task<DataTableResponse> GetCategoriesList(CategoryModel model)
        {
            DataTableResponse response = new DataTableResponse();
            if (model.Request != null)
            {

                IQueryable<CategoryDetail> Categories = (from x in _context.Category
                                                  where x.Status != (int)Status.Deleted
                                                  select new CategoryDetail()
                                                  {
                                                      Id = x.Id,
                                                      Description = x.Description,
                                                      Name = x.Name,
                                                      Status = x.Status
                                                  }).AsQueryable();

                //Searching
                Categories = Categories.ApplySearching(model.Request);

                //Total Records Count
                var totalRecords = await Categories.CountAsync();

                // Sort Data
                Categories = Categories.ApplySorting(model.Request);

                //Paging
                var pagedRoles = Categories.ApplyPaging(model.Request);


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

        #region Add Update Category
        public async Task<APIResponseModel> AddUpdateCategory(AddEditCategoryDetail model, IActionTracking _actionTracking, Guid modifiedBy)
        {
            APIResponseModel response = new APIResponseModel();

            #region Update Category
            if (model.Id != null && model.Id > 0)
            {
                Category Category = await _context.Category.Where(x => x.Id == model.Id && x.Status != (int)Status.Deleted).FirstOrDefaultAsync();
                if (Category != null)
                {
                    bool sameCategoryNameExist = _context.Category.Where(x => x.Name.ToLower().Trim() == model.Name.ToLower().Trim() && x.Id != model.Id && x.Status != (int)Status.Deleted).Any();
                    if (sameCategoryNameExist)
                    {
                        response.Code = (int)ResponseCode.BadRequest;
                        response.Status = false;
                        response.Message = string.Format(SharedResource.AlreadyExist, "Category name :" + model.Name);
                        return response;
                    }
                    else
                    {
                        Category.Name = model.Name;
                        Category.Description = model.Description;
                        Category.Modifiedby = modifiedBy;
                        Category.Modifieddate = DateTime.Now;
                        await _context.SaveChangesAsync();

                        await _actionTracking.SaveAPIActionTracking((int)Common.Common.APITrackingType.Edit, $"AddUpdateCategory Action Tracking Data");

                        response.Code = (int)ResponseCode.OK;
                        response.Status = true;
                        response.Message = string.Format(SharedResource.Updated, "Category");
                        return response;
                    }
                }
                else
                {
                    response.Code = (int)ResponseCode.BadRequest;
                    response.Status = false;
                    response.Message = string.Format(SharedResource.NotFound, "Category");
                    return response;
                }
            }

            #endregion

            #region Add Category
            else
            {
                bool sameCategoryNameExist = _context.Category.Where(x => x.Name.ToLower().Trim() == model.Name.ToLower().Trim() && x.Status != (int)Status.Deleted).Any();
                if (sameCategoryNameExist)
                {
                    response.Code = (int)ResponseCode.BadRequest;
                    response.Status = false;
                    response.Message = string.Format(SharedResource.AlreadyExist, "Category Name:" + model.Name);
                    return response;
                }
                else
                {

                    Category newCategory = new Category();
                    newCategory.Name = model.Name;
                    newCategory.Description = model.Description;
                    newCategory.Status = (int)Status.Active;
                    newCategory.Createdby = modifiedBy;
                    newCategory.Createddate = DateTime.Now;
                    _context.Category.Add(newCategory);
                    await _context.SaveChangesAsync();

                    await _actionTracking.SaveAPIActionTracking((int)Common.Common.APITrackingType.Add, $"AddUpdateCategory Action Tracking Data");

                    response.Code = (int)ResponseCode.OK;
                    response.Status = true;
                    response.Message = string.Format(SharedResource.Added, "Category");
                    return response;

                }
            }

            #endregion
        }
        #endregion

        #region Change Category Status
        public async Task<APIResponseModel> ChangeCategoryStatus(CategoryStatusModel model, IActionTracking _actionTracking, Guid modifiedBy)
        {
            APIResponseModel response = new APIResponseModel();

            var statusList = EnumHelperMethods.GetEnumList<Status>();
            if (statusList.Where(x => x.Value == model.StatusId && x.Value != (int)Status.Deleted).Any())
            {
                var role = await _context.Category.Where(x => x.Id == model.Id && x.Status != (int)Status.Deleted).FirstOrDefaultAsync();
                if (role == null)
                {
                    response.Code = (int)ResponseCode.BadRequest;
                    response.Status = false;
                    response.Message = string.Format(SharedResource.NotFound, "Category");
                    return response;
                }
                else
                {
                    role.Status = model.StatusId;
                    role.Modifiedby = modifiedBy;
                    role.Modifieddate = DateTime.Now;
                    await _context.SaveChangesAsync();
                    await _actionTracking.SaveAPIActionTracking((int)Common.Common.APITrackingType.StatusChange, $"ChangeCategoriestatus Action Tracking Data");

                    response.Code = (int)ResponseCode.OK;
                    response.Status = true;
                    response.Message = string.Format(model.StatusId == (int)Status.Active ? SharedResource.Activated : SharedResource.InActivated, "Category");
                    return response;
                }
            }
            else
            {
                response.Code = (int)ResponseCode.BadRequest;
                response.Status = false;
                response.Message = string.Format(SharedResource.NotValid, "Category Status");
                return response;
            }
        }

        #endregion

        #region Delete Category
        public async Task<APIResponseModel> DeleteCategory(int Id, IActionTracking _actionTracking, Guid modifiedBy)
        {
            APIResponseModel response = new APIResponseModel();
            var Category = await _context.Category.Where(x => x.Id == Id && x.Status != (int)Status.Deleted).FirstOrDefaultAsync();
            if (Category == null)
            {
                response.Code = (int)ResponseCode.BadRequest;
                response.Status = false;
                response.Message = string.Format(SharedResource.NotFound, "Category");
                return response;
            }
            else
            {
                Category.Status = (int)Status.Deleted;
                Category.Modifiedby = modifiedBy;
                Category.Modifieddate = DateTime.Now;
                await _context.SaveChangesAsync();

                await _actionTracking.SaveAPIActionTracking((int)Common.Common.APITrackingType.Delete, $"Delete Category Action Tracking Data");

                response.Code = (int)ResponseCode.OK;
                response.Status = true;
                response.Message = string.Format(SharedResource.Deleted, "Category");
                return response;
            }
        }

        #endregion

        #region Get Category
        public async Task<APIResponseModel> GetCategory(int Id, IActionTracking _actionTracking, Guid modifiedBy)
        {
            APIResponseModel response = new APIResponseModel();
            var Category = await _context.Category.Where(x => x.Id == Id && x.Status != (int)Status.Deleted).FirstOrDefaultAsync();
            if (Category == null)
            {
                response.Code = (int)ResponseCode.BadRequest;
                response.Status = false;
                response.Message = string.Format(SharedResource.NotFound, "Category");
                return response;
            }
            else
            {
                AddEditCategoryDetail model = new AddEditCategoryDetail
                {
                    Description = Category.Description,
                    Id = Category.Id,
                    Name = Category.Name,
                };
                await _actionTracking.SaveAPIActionTracking((int)Common.Common.APITrackingType.View, $"Get Category Action Tracking Data For Id:" + Id);
                response.Code = (int)ResponseCode.OK;
                response.Status = true;
                response.Data = JsonConvert.SerializeObject(model, Formatting.Indented);
                return response;
            }
        }

        #endregion

    }
}
