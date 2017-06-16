﻿using Beginner.Blog.Configs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Beginner.Blog.Controllers
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