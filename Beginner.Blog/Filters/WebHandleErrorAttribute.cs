﻿using Beginner.Blog.Core.Engines;
using Beginner.Blog.Core.Logging;
using Beginner.Blog.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Beginner.Blog.Filters
{
    /// <summary>
    /// 全局错误处理类
    /// </summary>
    public class WebHandleErrorAttribute : HandleErrorAttribute
    {
        private readonly ILogger _logger;
        public WebHandleErrorAttribute()
        {
            _logger = EngineContainerFactory.GetContainer().GetInstance<ILogger>();
        }

        public override void OnException(ExceptionContext filterContext)
        {
            var context = filterContext;
            //记录日志
            _logger.Error(context.Exception,context.Exception.Message);

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