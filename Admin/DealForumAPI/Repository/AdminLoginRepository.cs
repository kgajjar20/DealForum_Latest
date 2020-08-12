using DealForumAPI.DB;
using DealForumAPI.Interface;
using DealForumAPI.SecurityHelper;
using DealForumLibrary.Models.AdminAreaModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DealForumLibrary.Common.Common;
using static DealForumLibrary.EnumHelper.EnumHelper;

namespace DealForumAPI.Repository
{

    public class AdminLoginRepository : IAdminLogin
    {
        DealForumContext _context;
        public AdminLoginRepository(DealForumContext context)
        {
            _context = context;
        }

        public async Task<UserModel> AdminPortalUserExistAsync(AdminLoginModel model)
        {

            var adminPortalUser = await (from x in _context.User
                                         join y in _context.Usermapping on x.Id equals y.Userid
                                         join z in _context.Role on y.Roleid equals z.Id
                                         where x.Status == (int)Status.Active
                                         && y.Status == (int)Status.Active
                                         && z.Status == (int)Status.Active
                                         && x.Email.ToLower().Trim() == model.Email.ToLower().Trim()
                                         && x.Emailverified == true
                                         select new UserModel()
                                         {
                                             Email = x.Email,
                                             RoleId = y.Roleid,
                                             RoleName = z.Name,
                                             IsAdmin = z.Isadmin,
                                             Birthdate = x.Birthdate ?? null,
                                             Displayofficialbadge = x.Displayofficialbadge,
                                             Emailverified = x.Emailverified,
                                             Firstname = x.Firstname,
                                             Lastname = x.Lastname,
                                             Gender = x.Gender ?? null,
                                             Id = x.Id,
                                             Middlename = x.Middlename ?? string.Empty,
                                             Status = x.Status,
                                             CreatedDate = y.Createddate
                                         }).FirstOrDefaultAsync();

            return adminPortalUser;
        }


        public async Task<bool> ValidateAdminPortalLogin(AdminLoginModel model)
        {
            bool result = false;
            User user = await _context.User.Where(x => x.Email.ToLower().Trim() == model.Email.ToLower().Trim()).FirstOrDefaultAsync();
            if (user != null)
            {
                result = Hash.Validate(model.Password, user.Passwordsalt, user.Passwordhash);
            }
            return result;
        }

    }
}
