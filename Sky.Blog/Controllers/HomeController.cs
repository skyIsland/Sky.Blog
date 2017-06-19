using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sky.Models;
using Sky.Blog.Core;
using Sky.Blog.Core.Email;
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
        public ActionResult List()
        {
            var totalRows = GetList(new SearchInfo(1));
            var count = totalRows.Count;
            var pageSize = Sky.Blog.Configs.ConfigHelper.GetBasicConfig().WebsitePageSize;
            ViewBag.TotalPages =(count % pageSize) == 0 ? (count / pageSize) : (count / pageSize) + 1;
            return View(totalRows);
        }
        //加载数据列表
        [HttpGet]
        public ActionResult AJaxLoadList()
        {
            //获取页码
            var page = Request["page"];
            var searchInfo = new SearchInfo(Convert.ToInt32(page));
            //获取查询条件
            var url = Request["p"];
            var pIndex = url.LastIndexOf('/');
            if (pIndex > 0)
            {
                var arr = url.TrimStart('/').Split('/');
                if (arr.Length == 2)
                {
                    if (arr[0] == "categories")
                        searchInfo.CategoryName = arr[1];
                    if (arr[0] == "archive")
                        searchInfo.ArchiveName = arr[1];
                    if (arr[0] == "tag")
                        searchInfo.TagName = arr[1];
                }
            }
            else
            {
                if (url.IndexOf('?') >= 0)
                {
                    var arr = url.TrimStart('?').Split('=');
                    if (arr.Length == 2)
                    {
                        searchInfo.Keywork = arr[1];
                    }
                }
            }

            var pages = GetList(searchInfo, false);
            var pageSize = Sky.Blog.Configs.ConfigHelper.GetBasicConfig().WebsitePageSize;
            var totalRows = pages.Count;
            //var list = items.Select(p => { return new { p.Title, p.IsTop, CreateTime = p.CreateTime.ToString("yyyy-MM-dd HH:mm"), p.Id }; });
            var totalPages= (totalRows % pageSize) == 0 ? (totalRows / pageSize) : (totalRows / pageSize) + 1;
            return Json(new { data = pages, page = totalPages }, JsonRequestBehavior.AllowGet);
        }
        //关键字搜索
        public ActionResult Search(string keywork)
        {
            var pages = GetList(new SearchInfo(1) { Keywork = keywork });

            ViewBag.Highlight = keywork;
            return View("List", pages);
        }
        //文章详情
        public ActionResult Detail(string articleId)
        {
            int id;
            if (int.TryParse(articleId, out id))
            {
                var article = Article.FindByID(id);
                if (article != null)
                {
                    ViewBag.CommentList = Sky.Models.Comment.FindAll(Sky.Models.Comment._.ArticleId==id,Sky.Models.Comment._.CreateTime+" desc",null,0,0);

                    //浏览量+1
                    article.Hits += 1;
                    article.Save();
                    var cookie = Request.Cookies["CommentInfo"];
                    if (cookie != null)
                    {
                        ViewBag.NickName = cookie.Values["NickName"];
                        ViewBag.Email = cookie.Values["Email"];
                    }
                    return View(article);
                }
            }
            return RedirectToAction("Error500", "ErrorPage");
        }
        //关于
        public ActionResult About()
        {
            return View();
        }
        //标签
        public ActionResult Tag(string tagName)
        {
            var pages = GetList(new SearchInfo(1) { TagName = tagName });

            if (pages.Count > 0)
                ViewBag.Highlight = tagName;
            return View("List", pages);
        }
        //分类
        public ActionResult CategorySearch(string categoryName)
        {
            var pages = GetList(new SearchInfo(1) { CategoryName = categoryName });
            if (pages.Count > 0)
                ViewBag.Highlight = categoryName;
            return View("List", pages);
        }
        //文章评论
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Comment(Comment model)
        {
            model.Save();
            HttpCookie cookie = new HttpCookie("CommentInfo");
            cookie.Values["NickName"] = model.NickName;
            cookie.Values["Email"] = model.Email;
            cookie.Expires = DateTime.Now.AddDays(7);
            Response.Cookies.Set(cookie);

            //发送邮件通知
            var subject = model.NickName + "评论了你的文章";
            //暂时取消评论邮箱工厂设计模式发送邮件功能
            var smtpService = new SmtpService();
            smtpService.SendMail(model.Email, subject, model.CommentText.Length > 5 ? model.CommentText.Substring(0, 4) + "..." : "请打开博客查看详情");
            //Core.Email.EmailServiceFactory.GetEmailService().SendMail(model.Email, subject, model.CommentText.Length>5?model.CommentText.Substring(0,4)+"...":"请打开博客查看详情");

            return RedirectToAction("Detail", new { articleId = model.ArticleId });
        }
        /// <summary>
        /// 加载侧边数据
        /// </summary>
        private void LoadSideInfo()
        {
            var state = (int)ArticleStatus.Normal;
            //获取分类信息
            ViewBag.Categories = Category.FindAll("", Category._.IsTop + " desc," + Category._.Sort, null, 0, 0);
            //获取归档信息
            //ViewBag.Archives = _archiveRepository.Table.OrderByDescending(p => p.Id).ToList();

            var topQuery = Article.FindAll(Article._.State == state, "Hits desc,IsTop", "ID,Title,Hits,IsTop", 0, 7);
          
            //获取阅读排行榜TOP7
            ViewBag.Top = topQuery;
        }
        /// <summary>
        /// 获取文章列表
        /// </summary>
        /// <param name="info">查询条件</param>
        /// <param name="isLoadSideInfo">是否加载侧边数据</param>
        /// <returns></returns>
        private List<Article> GetList(SearchInfo info, bool isLoadSideInfo = true)
        {
            var pageSize = 15;//默认
            var setting = Configs.ConfigHelper.GetBasicConfig();
            if (setting != null)
                pageSize = setting.WebsitePageSize;

            if (isLoadSideInfo)
                LoadSideInfo();
            var state = (int)ArticleStatus.Normal;
           
            var exp = new WhereExpression();
            exp &= Article._.State == state;
            //关键字
            if (!string.IsNullOrEmpty(info.Keywork))
                exp &= Article._.Title.Contains(info.Keywork);
            //标签
            if (!string.IsNullOrEmpty(info.TagName))
            {
                exp &= Article._.Tags.Contains(info.TagName);
            }
            //分类
            if (!string.IsNullOrEmpty(info.CategoryName))
            {
                var category = Category.Find(Category._.CategoryName == info.CategoryName);              
                if (category != null)
                    exp &= Article._.CategoryId == category.ID;
            }

            ////归档
            //if (!string.IsNullOrEmpty(info.ArchiveName))
            //{
            //    var date = Convert.ToDateTime(info.ArchiveName);
            //    int days = DateTime.DaysInMonth(date.Year, date.Month);
            //    var maxDate = Convert.ToDateTime(info.ArchiveName + days + "日");
            //    exp &=
            //    query = query.Where(p => p.CreateTime >= date && p.CreateTime <= maxDate);
            //}
            return Article.FindAll(exp,Article._.IsTop+" desc,"+Article._.Sort+","+Article._.CreateTime+" desc",null,(info.PageIndex-1)* pageSize,pageSize);
        }
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