using DealForumAPI.DB;
using DealForumAPI.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DealForumAPI.Repository
{
    public class DealRepository : IDeal
    {
        #region Member Declaration
        private DealForumContext _context;
        public DealRepository(DealForumContext context)
        {
            _context = context;
        }
        #endregion



    }
}
