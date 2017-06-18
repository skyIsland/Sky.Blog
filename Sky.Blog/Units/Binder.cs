using System;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using XCode;

namespace Sky.Blog.Units
{
    /// <summary>
    /// 模型绑定--传入ID时自动查找该实体类的数据(XCode)
    /// </summary>
    public class Binder : DefaultModelBinder
    {
        private static readonly Regex LISTREG = new Regex(@"[\d+]", RegexOptions.Compiled);
        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            //获取路由的ID
            var rid = controllerContext.RouteData.Values["Id"];
            #region 处理ID
            var id = rid?.ToString() ?? "";
            if (string.IsNullOrEmpty(id))
                id = controllerContext.HttpContext.Request["id"];
            if (string.IsNullOrEmpty(id))
                id = controllerContext.HttpContext.Request["Id"];
            if (string.IsNullOrEmpty(id))
                id = controllerContext.HttpContext.Request["ID"];
            #endregion
            if (!string.IsNullOrEmpty(id) && !LISTREG.IsMatch(bindingContext.ModelName))
            {
                int i;
                if (int.TryParse(id, out i) && i > 0)
                {
                    var op = EntityFactory.CreateOperate(modelType.Name);
                    var r = op.FindByKey(i);
                    if (r != null)
                        return r;
                }
            }
            return base.CreateModel(controllerContext, bindingContext, modelType);
        }

    }
}