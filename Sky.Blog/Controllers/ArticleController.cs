using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sky.Models;
using Sky.Blog.Core;

namespace Sky.Blog.Controllers
{
    public class ArticleController : BaseController
    {
        // GET: Article
        public ActionResult List(int pageIndex = 1, int pageSize = 15)
        {
            var allArticle = Article.FindAll(Article._.IsDel+"=0","Sort",null,(pageIndex - 1)* pageSize, pageSize);
            int count = Article.FindCount(Article._.IsDel == 0);
            ViewBag.Categories = Category.FindAll();
            ViewBag.PageNo = pageIndex;
            ViewBag.TotalPage = count/2==0?count:count+1;           
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
            return RedirectToAction("NotFound", "Message");
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
    }
}