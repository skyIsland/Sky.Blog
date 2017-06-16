﻿using System.IO;
using System.Web;
using Newtonsoft.Json;
using Sky.Blog.Configs.Models;
using Sky.Blog.Helper;

namespace Sky.Blog.Configs
{
    public class ConfigHelper
    {
        /// <summary>
        /// 获取配置信息
        /// </summary>
        /// <returns></returns>
        public static Setting GetBasicConfig()
        {
            var settingCache = HttpContext.Current.Cache["Setting"];
            if (settingCache == null)
            {
                var settingString = FileHelper.ReadFile(WebHelper.GetFilePath("~/Configs/Files/") + "setting.json");
                var setting = JsonConvert.DeserializeObject<Setting>(settingString);

                HttpContext.Current.Cache.Insert("Setting", setting);

                return setting;
            }
            return settingCache as Setting;
        }
        /// <summary>
        /// 保存配置信息
        /// </summary>
        /// <param name="setting"></param>
        public static void SetBasicConfig(Setting setting)
        {
            var path = WebHelper.GetFilePath("~/Configs/Files/") + "setting.json";
            var fs = File.Create(path);
            fs.Close();
            var jsonStr = JsonConvert.SerializeObject(setting);
            var fr = new StreamWriter(path);
            fr.Write(jsonStr);
            fr.Close();
            //清除缓存
            HttpContext.Current.Cache.Remove("Setting");
        }
    }
}