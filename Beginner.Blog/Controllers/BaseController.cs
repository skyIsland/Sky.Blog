using Beginner.Blog.Configs.Models;
using Beginner.Blog.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Beginner.Blog.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {


        protected Setting GetSetting()
        {
            return Configs.ConfigHelper.GetBasicConfig();
        }


        protected Dictionary<string, object> GetResult(bool success, string message, object data = null)
        {
            return DataHelper.GetResult(success, message, data);
        }
    }
}