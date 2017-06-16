using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sky.Models;
using Sky.Blog.Core;
using Sky.Blog.Models;
using XCode;

namespace Sky.Blog.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }
        //public ActionResult List()
        //{
        //    return View(GetList(new SearchInfo(1)));
        //}
        ///// <summary>
        ///// 加载侧边数据
        ///// </summary>
        //private void LoadSideInfo()
        //{
        //    var state = (int)ArticleStatus.Normal;
        //    //获取分类信息
        //    ViewBag.Categories = Category.FindAll("",Category._.IsTop+","+Category._.Sort,null,0,0);
        //    //获取归档信息
        //    ViewBag.Archives = _archiveRepository.Table.OrderByDescending(p => p.Id).ToList();

        //    var topQuery = from a in _articleRepository.Table
        //                   where a.State == state
        //                   select new ArticleTopModel
        //                   {
        //                       Id = a.Id,
        //                       Title = a.Title,
        //                       Hits = a.Hits,
        //                       IsTop = a.IsTop
        //                   };
        //    //获取阅读排行榜TOP7
        //    ViewBag.Top = topQuery.OrderByDescending(p => p.Hits).ThenByDescending(p => p.IsTop).Skip((1 - 1) * 7).Take(7).ToList();
        //}
        ///// <summary>
        ///// 获取文章列表
        ///// </summary>
        ///// <param name="info">查询条件</param>
        ///// <param name="isLoadSideInfo">是否加载侧边数据</param>
        ///// <returns></returns>
        //private Pager<Article> GetList(SearchInfo info, bool isLoadSideInfo = true)
        //{
        //    var pageSize = 15;//默认
        //    var setting = Configs.ConfigHelper.GetBasicConfig();
        //    if (setting != null)
        //        pageSize = setting.WebsitePageSize;

        //    if (isLoadSideInfo)
        //        LoadSideInfo();
        //    var state = (int)ArticleStatus.Normal;

        //    var query = _articleRepository.Table.Where(p => p.State == state);
        //    var exp=new WhereExpression();
        //    exp &= Article._.State == state;
        //    //关键字
        //    if (!string.IsNullOrEmpty(info.Keywork))
        //        exp &= Article._.Title.Contains(info.Keywork);             
        //    //标签
        //    if (!string.IsNullOrEmpty(info.TagName))
        //    {
        //        exp &= Article._.Tags.Contains(info.TagName);             
        //    }
        //    //分类
        //    if (!string.IsNullOrEmpty(info.CategoryName))
        //    {
        //        var category = Category.Find(Category._.CategoryName==info.CategoryName);
        //        //var category = _categoryRepository.Table.Where(p => p.CategoryName == info.CategoryName).FirstOrDefault();
        //        if (category != null)
        //            exp &= Article._.CategoryId==category.ID;               
        //    }

        //    //归档
        //    if (!string.IsNullOrEmpty(info.ArchiveName))
        //    {
        //        var date = Convert.ToDateTime(info.ArchiveName);
        //        int days = DateTime.DaysInMonth(date.Year, date.Month);
        //        var maxDate = Convert.ToDateTime(info.ArchiveName + days + "日");
        //        exp&=
        //        query = query.Where(p => p.CreateTime >= date && p.CreateTime <= maxDate);
        //    }

        //    query = query.OrderByDescending(p => p.IsTop)
        //          .ThenByDescending(p => p.Sort)
        //          .ThenByDescending(p => p.CreateTime);
        //    return query.ToPagedList(info.PageIndex, pageSize, true);
        //}
    }
    /// <summary>
    /// 搜索信息类
    /// </summary>
    public class SearchInfo
    {
        public SearchInfo(int pageIndex)
        {
            PageIndex = pageIndex;
        }
        /// <summary>
        /// 页索引值
        /// </summary>
        public int PageIndex { get; private set; }
        /// <summary>
        /// 关键字
        /// </summary>
        public string Keywork { get; set; }
        /// <summary>
        /// 标签名称
        /// </summary>
        public string TagName { get; set; }
        /// <summary>
        /// 分类名称
        /// </summary>
        public string CategoryName { get; set; }
        /// <summary>
        /// 归档日期
        /// </summary>
        public string ArchiveName { get; set; }
    }
}