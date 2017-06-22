using System;
using System.Web;
using System.Web.Mvc;
using Sky.Blog.Core.Authentication;
using Sky.Blog.Helper;
using Sky.Models;
using Sky.Common;
namespace Sky.Blog.Controllers
{
    public class AccountController : BaseController
    {
        private  IFormsAuthentication _authentication;             

        public AccountController()
        {
            
        }
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            //如果已经登录，直接跳转至文章管理列表页
            if (HttpContext.User.Identity.IsAuthenticated)
                return RedirectToAction("List", "Article");

            var cookie = Request.Cookies["UserName"];
            if (cookie != null)
            {
                ViewBag.UserName = cookie.Value;
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(SysUsers model,string verifyCode,bool rememberMe=false)
        {
            _authentication=new AspFormsAuthentication();
            if (model == null)
                throw new ArgumentNullException("model");
            //验证验证码是否正确
            var pwdErrorCount = Session["PwdErrorCount"];
            if (pwdErrorCount != null && Convert.ToInt32(pwdErrorCount) > 5)
            {
                var sessionVerifyCode = Session["VerifyCode"];
                if (sessionVerifyCode == null || verifyCode != sessionVerifyCode.ToString())
                    return Json(new AjaxResult {Data = new { errorCount = pwdErrorCount } ,Msg ="验证码输入错误,请刷新重试",Status = false});
            }
            var entity = SysUsers.FindByLoginName(model.LoginName);
            if (entity == null)
            {
                return Json(new AjaxResult(false,"用户名不存在"));
            }
            if (entity.PassWord != model.PassWord.ToMd5())
            {
                int count = 1;
                var errorCount = Session["PwdErrorCount"];
                if (errorCount != null)
                    count = Convert.ToInt32(errorCount) + 1;
                Session["PwdErrorCount"] = count;

                return Json(new AjaxResult(false, "用户名或密码输错了呢", new { errorCount = count }));
            }
            model.LastLoginIP = NewLife.Web.WebHelper.UserHost;
            model.LastLoginTime = DateTime.Now;
            model.LoginCount++;           

            //重置错误次数
            Session["PwdErrorCount"] = null;
            //保存身份票据
            _authentication.SetAuthenticationToken(entity.LoginName);
            //保存登录名
            if (rememberMe)
            {
                HttpCookie cookie = new HttpCookie("UserName")
                {
                    Value = entity.LoginName,
                    Expires = DateTime.Now.AddDays(5)
                };
                Response.Cookies.Set(cookie);
            }
            return Json(new AjaxResult(msg: "登录成功."));
        }

        //登出
        public ActionResult SignOut()
        {
            _authentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}