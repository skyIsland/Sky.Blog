using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace Sky.Common
{
    public class Utils
    {
        /// <summary>
        /// 根据相对路径或绝对路径获取绝对路径
        /// </summary>
        /// <param name="localPath">相对路径或绝对路径</param>
        /// <returns>绝对路径</returns>
        public static string GetFilePath(string localPath)
        {
            return Regex.IsMatch(localPath, @"([A-Za-z]):\\([\S]*)") ? localPath : HttpContext.Current.Server.MapPath(localPath);
        }
    }
}
