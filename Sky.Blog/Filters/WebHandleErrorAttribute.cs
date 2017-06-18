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
            //记录日志
            XTrace.Log.Error("发生错误:"+context.Exception.Message);

            //获取当前的请求对象
            var request = context.RequestContext.HttpContext.Request;
            //如果请求方式为AJax，将返回Json格式数据
            if (request.IsAjaxRequest())
            {
                var result = new JsonResult
                {
                    Data = DataHelper.GetResult(false, "服务器发生异常，请稍候再试或联系管理员"),
                    ContentEncoding = System.Text.Encoding.UTF8,
                    ContentType = "text/plain"
                };
                if (request.HttpMethod.ToUpper() == "GET")
                    result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

                context.Result = result;
            }
            else
            {
                context.Result = new RedirectResult("/500");
            }
            //设置为已处理
            context.ExceptionHandled = true;
            base.OnException(filterContext);
        }
    }
}