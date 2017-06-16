using Beginner.Blog.Core.VerifyCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Beginner.Blog.Controllers
{
    public class ValidateCodeController : Controller
    {
        // GET: ValidateCode
        public ActionResult GetValidateCode()
        {
            var vCode = new ValidateCode();
            string code = vCode.CreateValidateCode(5);
            Session["VerifyCode"] = code;
            byte[] bytes = vCode.CreateValidateGraphic(code);
            return File(bytes, @"image/jpeg");
        }
    }
}