using System.Collections.Generic;
using System.Linq;
using Sky.Models;
using XCode;

namespace Sky.Blog.Core
{
    /// <summary>
    /// 分页结果集
    /// </summary>
    public class Pager<T>
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
        public List<T> Items { get; set; }

        public Pager()
        {
            PageSize = 10;
            PageNo = 1;
            TotalPages = 0;
        }
    }
    public static class PagerExt
    {
        public static Pager<T> ToPager<T>(this EntityList<T> query, int pageNo, int pageSize) where T : IEntity
        {
            //总记录数
            var totalRows = query.Count;
            //总页数
            var totalPages = totalRows % pageSize == 0 ? totalRows / pageSize : totalRows / pageSize + 1;
            var page = new Pager<T>
            {
                TotalRows = query.Count,
                TotalPages = totalPages,
                PageNo = pageNo,
                PageSize = pageSize,
                Items = query.ToList().Skip((pageNo - 1) * pageSize).Take(pageSize).ToList()
            };
            return page;
        }
    }

}