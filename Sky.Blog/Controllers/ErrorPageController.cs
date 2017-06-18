﻿using System.Web.Mvc;

namespace Sky.Blog.Controllers
{
    public class ErrorPageController : Controller
    {
        // 404
        public ActionResult Error404()
        {
            return View();
        }
        //500
        public ActionResult Error500()
        {
            return View();
        }
        //非法操作
        public ActionResult IllegalOperation()
        {
            return View();
        }
        //无操作权限
        public ActionResult LackAuthority()
        {
            return View();
        }

        public ActionResult ErrorTips()
        {
            return View();
        }
    }
}