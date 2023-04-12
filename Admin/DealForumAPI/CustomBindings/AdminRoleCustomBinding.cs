using DealForumLibrary.Models.AdminAreaModels;
using DealForumLibrary.Models.Datatables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealForumAPI.CustomBindings
{
    public static class AdminRoleCustomBinding
    {
        public enum AdminRoleFields
        {
            Id,
            Name,
            Description,
            Status,
        }


        public static IQueryable<RoleDetails> ApplyPaging(this IQueryable<RoleDetails> data, DataTableRequest request)
        {
            if (request.Length > 0)
            {
                data = data.Skip(request.Start).Take(request.Length);
            }
            return data;
        }

        public static IQueryable<RoleDetails> ApplySearching(this IQueryable<RoleDetails> data, DataTableRequest request)
        {
            if (request.Search != null && !string.IsNullOrWhiteSpace(request.Search.Value) && request.Search.Regex == false)
            {
                string searchText = request.Search.Value.ToLower();
                data = data.Where(x => x.Name.ToLower().Contains(searchText) || x.Description.ToLower().Contains(searchText)).AsQueryable();
            }
            return data;
        }

        public static IQueryable<RoleDetails> ApplySorting(this IQueryable<RoleDetails> data, DataTableRequest request)
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

        private static IQueryable<RoleDetails> AddSortExpression(IQueryable<RoleDetails> data, bool isAscending, string memberName)
        {
            AdminRoleFields adminRoleFields = GetAdminRoleFieldsEnum(memberName);
            if (isAscending)
            {
                switch (adminRoleFields)
                {
                    case AdminRoleFields.Id:
                        data = data.OrderBy(order => order.Id);
                        break;
                    case AdminRoleFields.Name:
                        data = data.OrderBy(order => order.Name);
                        break;
                    case AdminRoleFields.Description:
                        data = data.OrderBy(order => order.Description);
                        break;
                    case AdminRoleFields.Status:
                        data = data.OrderBy(order => order.Status);
                        break;
                }
            }
            else
            {
                switch (adminRoleFields)
                {
                    case AdminRoleFields.Id:
                        data = data.OrderByDescending(order => order.Id);
                        break;
                    case AdminRoleFields.Name:
                        data = data.OrderByDescending(order => order.Name);
                        break;
                    case AdminRoleFields.Description:
                        data = data.OrderByDescending(order => order.Description);
                        break;
                    case AdminRoleFields.Status:
                        data = data.OrderByDescending(order => order.Status);
                        break;
                }
            }
            return data;
        }

        private static AdminRoleFields GetAdminRoleFieldsEnum(string FieldValue)
        {
            return (AdminRoleFields)Enum.Parse(typeof(AdminRoleFields), FieldValue);
        }

    }
}
