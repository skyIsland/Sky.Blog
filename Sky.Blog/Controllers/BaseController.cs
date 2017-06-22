using System.Collections.Generic;
using System.Web.Mvc;
using Sky.Blog.Configs.Models;
using Sky.Blog.Helper;
namespace Sky.Blog.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {


        protected Setting GetSetting()
        {
            return Configs.ConfigHelper.GetBasicConfig();
        }      
    }
}