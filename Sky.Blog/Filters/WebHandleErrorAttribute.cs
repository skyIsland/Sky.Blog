using System.Web;
using System.Web.Mvc;
using Sky.Blog.Core.Engines;
using Sky.Blog.Helper;
using NewLife.Log;
namespace Sky.Blog.Filters
{
    /// <summary>
    /// 全局错误处理类
    /// </summary>
    public class WebHandleErrorAttribute : HandleErrorAttribute
    {      
        public override void OnException(ExceptionContext filterContext)
        {
            var context = filterContext;
            //获取当前的请求对象
            var request = context.RequestContext.HttpContext.Request;
            #region 记录日志
            //错误发生地址
            string url = request.RawUrl;
            //错误信息
            string msg = filterContext.Exception.Message;
            XTrace.Log.Error($"发生错误,错误地址:{url}!异常消息:{msg}");
            #endregion

            #region 暂时屏蔽Ajax请求发生的错误--没用到异步
            //如果请求方式为AJax，将返回Json格式数据
            //if (request.IsAjaxRequest())
            //{
            //    var result = new JsonResult
            //    {
            //        Data = DataHelper.GetResult(false, "服务器发生异常，请稍候再试或联系管理员"),
            //        ContentEncoding = System.Text.Encoding.UTF8,
            //        ContentType = "text/plain"
            //    };
            //    if (request.HttpMethod.ToUpper() == "GET")
            //        result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            //    context.Result = result;
            //}
            //else
            //{
            //}
            #endregion
          
            //设置为已处理
            context.ExceptionHandled = true;
            context.Result = new RedirectResult("/ErrorPage/Error500");
            base.OnException(filterContext);
        }
    }
}