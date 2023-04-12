using DealForumLibrary.Models.AdminAreaModels;
using DealForumLibrary.Models.Datatables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealForumAPI.CustomBindings
{
    public static class AdminStoreCustomBinding
    {
        public enum AdminStoreFields
        {
            Id,
            Description,
            Logo,
            Name,
            Websitelink,
            Status,
        }


        public static IQueryable<StoreDetail> ApplyPaging(this IQueryable<StoreDetail> data, DataTableRequest request)
        {
            if (request.Length > 0)
            {
                data = data.Skip(request.Start).Take(request.Length);
            }
            return data;
        }

        public static IQueryable<StoreDetail> ApplySearching(this IQueryable<StoreDetail> data, DataTableRequest request)
        {
            if (request.Search != null && !string.IsNullOrWhiteSpace(request.Search.Value) && request.Search.Regex == false)
            {
                string searchText = request.Search.Value.ToLower();
                data = data.Where(x => x.Name.ToLower().Contains(searchText) || x.Description.ToLower().Contains(searchText)
                                        || x.Logo.ToLower().Contains(searchText) || x.Websitelink.ToLower().Contains(searchText)).AsQueryable();
            }
            return data;
        }

        public static IQueryable<StoreDetail> ApplySorting(this IQueryable<StoreDetail> data, DataTableRequest request)
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

        private static IQueryable<StoreDetail> AddSortExpression(IQueryable<StoreDetail> data, bool isAscending, string memberName)
        {
            AdminStoreFields adminStoreFields = GetAdminStoreFieldsEnum(memberName);
            if (isAscending)
            {
                switch (adminStoreFields)
                {
                    case AdminStoreFields.Id:
                        data = data.OrderBy(order => order.Id);
                        break;
                    case AdminStoreFields.Name:
                        data = data.OrderBy(order => order.Name);
                        break;
                    case AdminStoreFields.Description:
                        data = data.OrderBy(order => order.Description);
                        break;
                    case AdminStoreFields.Status:
                        data = data.OrderBy(order => order.Status);
                        break;
                    case AdminStoreFields.Websitelink:
                        data = data.OrderBy(order => order.Websitelink);
                        break;
                }
            }
            else
            {
                switch (adminStoreFields)
                {
                    case AdminStoreFields.Id:
                        data = data.OrderByDescending(order => order.Id);
                        break;
                    case AdminStoreFields.Name:
                        data = data.OrderByDescending(order => order.Name);
                        break;
                    case AdminStoreFields.Description:
                        data = data.OrderByDescending(order => order.Description);
                        break;
                    case AdminStoreFields.Status:
                        data = data.OrderByDescending(order => order.Status);
                        break;
                    case AdminStoreFields.Websitelink:
                        data = data.OrderByDescending(order => order.Websitelink);
                        break;
                }
            }
            return data;
        }

        private static AdminStoreFields GetAdminStoreFieldsEnum(string FieldValue)
        {
            return (AdminStoreFields)Enum.Parse(typeof(AdminStoreFields), FieldValue);
        }
    }
}
