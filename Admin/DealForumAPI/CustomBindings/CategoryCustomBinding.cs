using DealForumLibrary.Models.AdminAreaModels;
using DealForumLibrary.Models.Datatables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealForumAPI.CustomBindings
{
    public static class CategoryCustomBinding
    {
        public enum CategoryFields
        {
            Id,
            Name,
            Description,
            Status,
        }


        public static IQueryable<CategoryDetail> ApplyPaging(this IQueryable<CategoryDetail> data, DataTableRequest request)
        {
            if (request.Length > 0)
            {
                data = data.Skip(request.Start).Take(request.Length);
            }
            return data;
        }

        public static IQueryable<CategoryDetail> ApplySearching(this IQueryable<CategoryDetail> data, DataTableRequest request)
        {
            if (request.Search != null && !string.IsNullOrWhiteSpace(request.Search.Value) && request.Search.Regex == false)
            {
                string searchText = request.Search.Value.ToLower();
                data = data.Where(x => x.Name.ToLower().Contains(searchText) || x.Description.ToLower().Contains(searchText)).AsQueryable();
            }
            return data;
        }

        public static IQueryable<CategoryDetail> ApplySorting(this IQueryable<CategoryDetail> data, DataTableRequest request)
        {
            if (request.Order != null && request.Order.Any())
            {
                foreach (DataTableOrder order in request.Order)
                {
                    int sortColumnIndex = order.Column;
                    string columnName = request.Columns[sortColumnIndex].Data;
                    bool isAscending = string.Compare(order.Dir, "asc", true) == 0 ? true : false;
                    data = AddSortExpression(data, isAscending, columnName);
                }
            }
            else
            {
                data = data.OrderByDescending(x => x.Id);
            }

            return data;
        }

        private static IQueryable<CategoryDetail> AddSortExpression(IQueryable<CategoryDetail> data, bool isAscending, string memberName)
        {
            CategoryFields CategoryFields = GetCategoryFieldsEnum(memberName);
            if (isAscending)
            {
                switch (CategoryFields)
                {
                    case CategoryFields.Id:
                        data = data.OrderBy(order => order.Id);
                        break;
                    case CategoryFields.Name:
                        data = data.OrderBy(order => order.Name);
                        break;
                    case CategoryFields.Description:
                        data = data.OrderBy(order => order.Description);
                        break;
                    case CategoryFields.Status:
                        data = data.OrderBy(order => order.Status);
                        break;
                }
            }
            else
            {
                switch (CategoryFields)
                {
                    case CategoryFields.Id:
                        data = data.OrderByDescending(order => order.Id);
                        break;
                    case CategoryFields.Name:
                        data = data.OrderByDescending(order => order.Name);
                        break;
                    case CategoryFields.Description:
                        data = data.OrderByDescending(order => order.Description);
                        break;
                    case CategoryFields.Status:
                        data = data.OrderByDescending(order => order.Status);
                        break;
                }
            }
            return data;
        }

        private static CategoryFields GetCategoryFieldsEnum(string FieldValue)
        {
            return (CategoryFields)Enum.Parse(typeof(CategoryFields), FieldValue);
        }

    }
}
