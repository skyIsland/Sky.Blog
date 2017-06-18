using Sky.Models;
using XCode;
using System.Web.Mvc;
using Sky.Blog.Units;
namespace Sky.Blog
{
    /// <summary>
    /// 模型绑定
    /// </summary>
    public class ModelBinderConfig
    {
        public static void RegisterBinder()
        {
            //实例化模型绑定对象
            var binder = new Binder();
            var types = typeof(SysUsers).Assembly.GetTypes();

            foreach (var type in types)
            {
                //确定模型类型是否派生自EntityBase
                if (type.IsSubclassOf(typeof(EntityBase)))
                {
                    ModelBinders.Binders.Add(type, binder);
                }
            }
            //ModelBinders.Binders.Add(typeof(QueryRequest), new FlexGridQueryBinder());
            //ModelBinders.Binders.Add(typeof(Pager), new GridQueryBinder());
        }
    }
}