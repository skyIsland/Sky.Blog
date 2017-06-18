using System.Collections.Generic;
using Sky.Models;
using XCode;

namespace Sky.Blog.Core
{
    /// <summary>
    /// 分页结果集
    /// </summary>
    public class Pager
    {
        /// <summary>
        /// 总行数
        /// </summary>
        public int TotalRows { set; get; }

        /// <summary>
        /// 每页显示的行数
        /// </summary>
        public int PageSize { set; get; }

        /// <summary>
        /// 当前页号
        /// </summary>
        public int PageNo { set; get; }

        /// <summary>
        /// 总页数
        /// </summary>
        public int TotalPages { set; get; }

        /// <summary>
        /// 当前页在数据库中的起始行
        /// </summary>
        public int StartRow { set; get; }

        /// <summary>
        /// 排序
        /// </summary>
        public string Sort { get; set; }

        /// <summary>
        /// 排序顺序
        /// </summary>
        public string Direction { get; set; }

        /// <summary>
        /// 结果集
        /// </summary>
        public List<Article> Items { get; set; }

        public Pager()
        {
            PageSize = 10;
            PageNo = 1;
            TotalPages = 0;
        }
    }
}