using Beginner.Blog.Core.Interceptor;
using Beginner.Blog.Filters;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Interception;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Beginner.Blog.Core.Email;

namespace Beginner.Blog
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //注册autofac
            AutoFacBootStrapper.Register();
            //初始化邮件
            EmailServiceFactory.InitializeEmailServiceFactory(new SmtpService());

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);


            //添加拦截器
            DbInterception.Add(new EfInterceptorLogging());
            DbInterception.Add(new EfInterceptorTransientErrors());
        }
    }
}
