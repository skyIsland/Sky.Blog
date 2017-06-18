using System.Web.Mvc;
using Sky.Blog.Configs.Models;

namespace Sky.Blog.Controllers
{
    public class SettingController : BaseController
    {
        // GET: Setting
        public ActionResult BasicSetting()
        {
            var setting = Configs.ConfigHelper.GetBasicConfig();

            return View(setting);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateBasicSetting(Setting model)
        {
            Configs.ConfigHelper.SetBasicConfig(model);
            return RedirectToAction("BasicSetting");
        }
    }
}