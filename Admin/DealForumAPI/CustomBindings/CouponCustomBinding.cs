using DealForumLibrary.Models;
using DealForumLibrary.Models.Datatables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealForumAPI.CustomBindings
{
    public static class CouponCustomBinding
    {
        public enum CouponFields
        {
            Id,
            CouponTitle,
            CouponCode,
            CouponLink,
            StoreName,
            CouponExpiry,
            Description,
            Status
        }


        public static IQueryable<CouponDetail> ApplyPaging(this IQueryable<CouponDetail> data, DataTableRequest request)
        {
            if (request.Length > 0)
            {
                data = data.Skip(request.Start).Take(request.Length);
            }
            return data;
        }

        public static IQueryable<CouponDetail> ApplySearching(this IQueryable<CouponDetail> data, DataTableRequest request)
        {
            if (request.Search != null && !string.IsNullOrWhiteSpace(request.Search.Value) && request.Search.Regex == false)
            {
                string searchText = request.Search.Value.ToLower();
                data = data.Where(x => x.StoreName.ToLower().Contains(searchText) || x.Description.ToLower().Contains(searchText) || x.CouponTitle.ToLower().Contains(searchText)
                                        || x.CouponCode.ToLower().Contains(searchText) || x.CouponLink.ToLower().Contains(searchText)
                                        ).AsQueryable();
            }
            return data;
        }

        public static IQueryable<CouponDetail> ApplySorting(this IQueryable<CouponDetail> data, DataTableRequest request)
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

        private static IQueryable<CouponDetail> AddSortExpression(IQueryable<CouponDetail> data, bool isAscending, string memberName)
        {
            CouponFields CouponFields = GetCouponFieldsEnum(memberName);
            if (isAscending)
            {
                switch (CouponFields)
                {
                    case CouponFields.Id:
                        data = data.OrderBy(order => order.Id);
                        break;
                    case CouponFields.CouponTitle:
                        data = data.OrderBy(order => order.CouponTitle);
                        break;
                    case CouponFields.Description:
                        data = data.OrderBy(order => order.Description);
                        break;
                    case CouponFields.Status:
                        data = data.OrderBy(order => order.Status);
                        break;
                    case CouponFields.CouponCode:
                        data = data.OrderBy(order => order.CouponCode);
                        break;
                    case CouponFields.CouponLink:
                        data = data.OrderBy(order => order.CouponLink);
                        break;
                    case CouponFields.StoreName:
                        data = data.OrderBy(order => order.StoreName);
                        break;
                    case CouponFields.CouponExpiry:
                        data = data.OrderBy(order => order.CouponExpiry);
                        break;
                }
            }
            else
            {
                switch (CouponFields)
                {
                    case CouponFields.Id:
                        data = data.OrderByDescending(order => order.Id);
                        break;
                    case CouponFields.CouponTitle:
                        data = data.OrderByDescending(order => order.CouponTitle);
                        break;
                    case CouponFields.Description:
                        data = data.OrderByDescending(order => order.Description);
                        break;
                    case CouponFields.Status:
                        data = data.OrderByDescending(order => order.Status);
                        break;
                    case CouponFields.CouponCode:
                        data = data.OrderByDescending(order => order.CouponCode);
                        break;
                    case CouponFields.CouponLink:
                        data = data.OrderByDescending(order => order.CouponLink);
                        break;
                    case CouponFields.StoreName:
                        data = data.OrderByDescending(order => order.StoreName);
                        break;
                    case CouponFields.CouponExpiry:
                        data = data.OrderByDescending(order => order.CouponExpiry);
                        break;
                }
            }
            return data;
        }

        private static CouponFields GetCouponFieldsEnum(string FieldValue)
        {
            return (CouponFields)Enum.Parse(typeof(CouponFields), FieldValue);
        }
    }
}
