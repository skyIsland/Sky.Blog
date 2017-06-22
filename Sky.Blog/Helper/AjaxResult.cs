using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sky.Blog.Helper
{
    /// <summary>
    /// Ajax返回结果
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AjaxResult
    {
        /// <summary>
        /// 状态
        /// </summary>
        public bool Status { get; set; }
        /// <summary>
        /// 返回信息
        /// </summary>
        public string Msg { get; set; }
        /// <summary>
        /// 返回数据
        /// </summary>
        public object Data { get; set; }

        public AjaxResult()
        {
            
        }
        public AjaxResult(bool status=true, string msg="傻大蒙好帅", object data=null)
        {
            Status = status;
            Msg = msg;
            Data = data;
        }
    }

   
}