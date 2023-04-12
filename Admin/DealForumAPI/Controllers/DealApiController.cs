using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DealForumAPI.Common;
using DealForumAPI.Helper;
using DealForumAPI.Interface;
using DealForumAPI.Resources;
using DealForumLibrary;
using DealForumLibrary.Models;
using DealForumLibrary.Models.AdminAreaModels;
using DealForumLibrary.Models.Datatables;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using static DealForumLibrary.EnumHelper;

namespace DealForumAPI.Controllers
{
    [Route("[controller]")]
    [ApiVersion("1.0")]
    [ApiController]
    [Authorize]
    public class DealApiController : ControllerBase
    {


    }
}
