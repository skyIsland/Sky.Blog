﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Beginner.Blog.Core;
using Beginner.Blog.Models;
using Beginner.Blog.Core.Extension;
using Beginner.Blog.ViewModels;
using Beginner.Blog.Helper;

namespace Beginner.Blog.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IRepository<Article> _articleRepository;

        public CategoryController(IRepository<Category> categoryRepository, IRepository<Article> articleRepository)
        {
            _categoryRepository = categoryRepository;
            _articleRepository = articleRepository;
        }


        // GET: Category
        public ActionResult List(int pageIndex = 1, int pageSize = 15)
        {
            var setting = GetSetting();
            if (setting != null)
                pageSize = setting.ManagePageSize;

            var query = _categoryRepository.Table;

            var list = query.OrderByDescending(p => p.IsTop)
                .ThenByDescending(p => p.Sort)
                .ToPagedList(pageIndex, pageSize, true);

            return View(list);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CategoryModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            if (model.CategoryName.Length > 15)
            {
                ViewBag.IsError = true;
                return View();
            }

            var entity = new Category
            {
                CategoryName = model.CategoryName,
                IsTop = model.IsTop,
                Sort = model.Sort,
                CreateTime = DateTime.Now
            };

            _categoryRepository.Insert(entity);

            return RedirectToAction("List");
        }

        public ActionResult Edit()
        {
            var id = Request["id"];
            int cId = 0;
            if (string.IsNullOrEmpty(id))
                return RedirectToAction("List");
            if (!int.TryParse(id, out cId))
                return RedirectToAction("List");
            var entity = _categoryRepository.FindById(cId);

            return View(entity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");
            if (model.CategoryName.Length > 15)
            {
                ViewBag.IsError = true;
                return View();
            }

            var entity = _categoryRepository.FindById(model.Id);
            entity.CategoryName = model.CategoryName;
            entity.IsTop = model.IsTop;
            entity.Sort = model.Sort;

            _categoryRepository.Update(entity);

            return RedirectToAction("List");

        }
        [HttpPost]
        public ActionResult Delete()
        {
            var id = Request["id"];
            if (string.IsNullOrEmpty(id))
                return Json(new { success = false, message = "删除失败，请刷新页面重试！" });
            int cId;
            if (!int.TryParse(id, out cId))
                return Json(new { success = false, message = "非法参数，请刷新页面重试！" });

            var exists = _articleRepository.Table.Any(p => p.CategoryId == cId);
            if (exists)
                return Json(new { success = false, message = "该分类下存在文章，请先删除文章！" });

            _categoryRepository.Delete(p => p.Id == cId);

            return Json(new { success = true, message = "删除成功!" });
        }

        [HttpGet]
        public ActionResult CheckName()
        {
            var value = Request["name"];
            if (string.IsNullOrEmpty(value))
                return Json(new { success = false, message = "名称可用！" }, JsonRequestBehavior.AllowGet);
            var flag = false;
            var query = _categoryRepository.Table;
            var id = Request["id"];
            if (!string.IsNullOrEmpty(id))
            {
                var cId = Convert.ToInt32(id);
                if (query.Any(p => p.Id == cId && p.CategoryName == value.Trim()))
                    flag = false;
                else
                    flag = query.Any(p => p.CategoryName == value.Trim());
            }
            else
            {
                flag = query.Any(p => p.CategoryName == value.Trim());
            }
            return Json(new { success = flag, message = flag ? "分类名称已存在" : "名称可用！" }, JsonRequestBehavior.AllowGet);
        }
    }
}