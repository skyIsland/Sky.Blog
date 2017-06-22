using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sky.Blog.Helper;
using Sky.Models;
namespace Sky.Blog.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Category
        public ActionResult List(int pageNo = 1, int pageSize = 15)
        {
            var setting = GetSetting();
            if (setting != null)
                pageSize = setting.ManagePageSize;
            var totalRows = Category.FindAll("1=1",Category._.IsTop+" desc,"+Category._.Sort,null,(pageNo-1)*pageSize,pageSize);
            return View(totalRows);
        }

        public ActionResult Create()
        {
            return View("Edit",new Category());
        }

        public ActionResult Edit(Category model)
        {
            return View(model);
        }

        public ActionResult Save(Category model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));          
            if(model.ID==0)model.CreateTime=DateTime.Now;
            model.Save();
            return RedirectToAction("List");
        }
        [HttpPost]
        public ActionResult Delete(Category model)
        {          
            var exists = model.Articles.Count>0;
            if (exists)
                return Json(new { success = false, message = "该分类下存在文章，请先删除文章！" });
            model.Delete();
            return Json(new AjaxResult { Msg = "删除成功" });
        }

        [HttpGet]
        public ActionResult CheckName()
        {
            var value = Request["name"];           
            var flag = Category.FindCount(Category._.CategoryName==value.Trim()) > 0;          
            return Json(new { success = flag, message = flag ? "分类名称已存在" : "名称可用！" }, JsonRequestBehavior.AllowGet);
        }
    }
}