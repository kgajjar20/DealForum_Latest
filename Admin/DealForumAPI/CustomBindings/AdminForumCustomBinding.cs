using DealForumLibrary.Models.AdminAreaModels;
using DealForumLibrary.Models.Datatables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealForumAPI.CustomBindings
{
    public static class AdminForumCustomBinding
    {
        public enum AdminForumFields
        {
            Id,
            ForumName,
            Status,
        }


        public static IQueryable<ForumDetail> ApplyPaging(this IQueryable<ForumDetail> data, DataTableRequest request)
        {
            if (request.Length > 0)
            {
                data = data.Skip(request.Start).Take(request.Length);
            }
            return data;
        }

        public static IQueryable<ForumDetail> ApplySearching(this IQueryable<ForumDetail> data, DataTableRequest request)
        {
            if (request.Search != null && !string.IsNullOrWhiteSpace(request.Search.Value) && request.Search.Regex == false)
            {
                string searchText = request.Search.Value.ToLower();
                data = data.Where(x => x.Name.ToLower().Contains(searchText)).AsQueryable();
            }
            return data;
        }

        public static IQueryable<ForumDetail> ApplySorting(this IQueryable<ForumDetail> data, DataTableRequest request)
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

        private static IQueryable<ForumDetail> AddSortExpression(IQueryable<ForumDetail> data, bool isAscending, string memberName)
        {
            AdminForumFields AdminForumFields = GetAdminForumFieldsEnum(memberName);
            if (isAscending)
            {
                switch (AdminForumFields)
                {
                    case AdminForumFields.Id:
                        data = data.OrderBy(order => order.Id);
                        break;
                    case AdminForumFields.ForumName:
                        data = data.OrderBy(order => order.Name);
                        break;
                    case AdminForumFields.Status:
                        data = data.OrderBy(order => order.Status);
                        break;
                }
            }
            else
            {
                switch (AdminForumFields)
                {
                    case AdminForumFields.Id:
                        data = data.OrderByDescending(order => order.Id);
                        break;
                    case AdminForumFields.ForumName:
                        data = data.OrderByDescending(order => order.Name);
                        break;
                    case AdminForumFields.Status:
                        data = data.OrderByDescending(order => order.Status);
                        break;
                }
            }
            return data;
        }

        private static AdminForumFields GetAdminForumFieldsEnum(string FieldValue)
        {
            return (AdminForumFields)Enum.Parse(typeof(AdminForumFields), FieldValue);
        }
    }
}
