using System.Configuration;

namespace Sky.Blog.Helper
{
    public class ConfigHelper
    {
        /// <summary>
        /// 获取配置信息
        /// </summary>
        /// <param name="key">配置项名称</param>
        /// <param name="defaultVal">默认值</param>
        /// <returns></returns>
        public static string AppSetting(string key, string defaultVal)
        {
            string value = ConfigurationManager.AppSettings[key];
            return string.IsNullOrEmpty(value) ? defaultVal : value.Trim();
        }

        
    }
}