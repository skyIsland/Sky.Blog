using System.Web.Mvc;
using Sky.Blog.Core.VerifyCode;

namespace Sky.Blog.Controllers
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