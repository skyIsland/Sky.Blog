using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sky.Models;
using Sky.Blog.Core;
using Sky.Blog.Helper;
using XCode;

namespace Sky.Blog.Controllers
{
    public class ArticleController : BaseController
    {
        /// <summary>
        /// 文章列表页(带上搜索功能)
        /// </summary>
        /// <param name="category"></param>
        /// <param name="state"></param>
        /// <param name="title"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public ActionResult List(int? category,int? state,string title = "", int pageIndex = 1, int pageSize = 15)
        {
            #region 构造查询表达式
            var exp = new WhereExpression();
            exp &= Article._.IsDel == 0;
            if (category.HasValue&category!=0)
            {
                exp &= Article._.CategoryId == category;
                ViewBag.CagegotyId = category;
            }
            if (!title.IsNullOrEmpty())
            {
                exp &= Article._.Title.Contains(title);
                ViewBag.ArticleTitle = title;
            }
            if (state.HasValue&state!=0)
            {
                exp &= Article._.State==state;
                ViewBag.State = state;
            }
            #endregion
            var allArticle = Article.FindAll(exp, Article._.IsTop+" desc,Sort",null,(pageIndex - 1)* pageSize, pageSize);
            int count = Article.FindCount(exp);
            ViewBag.Categories = Category.FindAll();
            ViewBag.PageNo = pageIndex;
            ViewBag.TotalPage = count% pageSize == 0?count:count+1;           
            return View(allArticle);
        }
        /// <summary>
        /// 添加文章
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            var p = new Article();
            ViewBag.Categories = Category.FindAll();
            return View("Edit", p);
        }
        /// <summary>
        /// 编辑文章
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult Edit(Article model)
        {
            if (model!=null)
            {
                ViewBag.Categories = Category.FindAll();             
                return View(model);
            }
            return RedirectToAction("Error500", "ErrorPage");
        }
        /// <summary>
        /// 保存文章
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [ValidateInputAttribute(false)]
        public ActionResult Save(Article model)
        {
            if (model.ID == 0)
            {
                model.CreateTime=DateTime.Now;
            }
            model.Save();
            return RedirectToAction("List");
        }
        /// <summary>
        /// 删除文章
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Delete(Article model)
        {
            model.Delete();
            return Json(new AjaxResult{Msg="删除成功"});
        }
    }
}