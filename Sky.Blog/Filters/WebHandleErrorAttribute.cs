using System.Web;
using System.Web.Mvc;
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
            XTrace.WriteException(context.Exception);
            #endregion

            #region 处理错误
            //如果请求方式为AJax，将返回Json格式数据
            if (request.IsAjaxRequest())
            {
                var result = new JsonResult
                {                    
                    Data =new AjaxResult {Status = false,Msg = context.Exception.Message},
                    ContentEncoding = System.Text.Encoding.UTF8,
                    ContentType = "text/plain"
                };
                if (request.HttpMethod.ToUpper() == "GET")
                    result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

                context.Result = result;
            }
            else//非ajax
            {
              context.Result = new RedirectResult("/ErrorPage/Error500");
            }
            #endregion
            //设置为已处理
            context.ExceptionHandled = true;            
            base.OnException(filterContext);
        }
    }
}