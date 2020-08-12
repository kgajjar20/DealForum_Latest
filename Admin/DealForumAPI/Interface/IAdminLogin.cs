using DealForumAPI.DB;
using DealForumLibrary.Models.AdminAreaModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealForumAPI.Interface
{
    public interface IAdminLogin
    {
        Task<UserModel> AdminPortalUserExistAsync(AdminLoginModel model);
        Task<bool> ValidateAdminPortalLogin(AdminLoginModel model);
    }
}
