using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Beginner.Blog
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute("wangEditor", "wangEditor", new { controller = "Upload", action = "WangEditor" });

            //Error pages
            routes.MapRoute("404", "404", new { controller = "ErrorPage", action = "Error404" });
            routes.MapRoute("500", "500", new { controller = "ErrorPage", action = "Error500" });
            routes.MapRoute("illegal", "illegal", new { controller = "ErrorPage", action = "IllegalOperation" });
            routes.MapRoute("lackauthority", "lackauthority", new { controller = "ErrorPage", action = "LackAuthority" });

            //Login
            routes.MapRoute("Login2", "manage/login", new { controller = "Account", action = "Login" });
            routes.MapRoute("Login1", "manage/login.html", new { controller = "Account", action = "Login" });
            //SignOut
            routes.MapRoute("SignOut1", "manage/signout", new { controller = "Account", action = "SignOut" });

            //validate code
            routes.MapRoute("ValidateCode1", "manage/validatecode", new { controller = "ValidateCode", action = "GetValidateCode" });


            //Detail
            routes.MapRoute("ArticleDetail2", "detail-{articleId}", new { controller = "Home", action = "Detail" });
            routes.MapRoute("ArticleDetail1", "detail-{articleId}.html", new { controller = "Home", action = "Detail" });
            routes.MapRoute("ArticleDetail4", "detail/{articleId}", new { controller = "Home", action = "Detail" });
            routes.MapRoute("ArticleDetail3", "detail/{articleId}.html", new { controller = "Home", action = "Detail" });

            //About
            routes.MapRoute("About2", "about", new { controller = "Home", action = "About" });
            routes.MapRoute("About1", "about.html", new { controller = "Home", action = "About" });

            //Archive
            routes.MapRoute("Archive1", "archive/{keywork}", new { controller = "Home", action = "Archive" });
            routes.MapRoute("Archive2", "archive/{keywork}.html", new { controller = "Home", action = "Archive" });

            //Tag
            routes.MapRoute("Tag2", "tag/{tagName}", new { controller = "Home", action = "Tag" });
            routes.MapRoute("Tag1", "tag/{tagName}.html", new { controller = "Home", action = "Tag" });

            //List
            routes.MapRoute("List2", "all", new { controller = "Home", action = "List" });
            routes.MapRoute("List1", "all.html", new { controller = "Home", action = "List" });


            //404
            routes.MapRoute("404-1", "404", new { controller = "Message", action = "NotFound" });
            routes.MapRoute("404-2", "404.html", new { controller = "Message", action = "NotFound" });

            //Category
            routes.MapRoute("cagegory1", "categories/{categoryName}", new { controller = "Home", action = "CategorySearch" });
            routes.MapRoute("cagegory2", "categories/{categoryName}.html", new { controller = "Home", action = "CategorySearch" });

            //Search
            routes.MapRoute("search1", "search/t={keywork}", new { controller = "Home", action = "Search" });
            routes.MapRoute("search2", "search/t={keywork}.html", new { controller = "Home", action = "Search" });

            routes.MapRoute(
                name: "Home",
                url: "",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            #region Manage

            //basic setting
            routes.MapRoute("manage_setting", "manage/setting", new { controller = "Setting", action = "BasicSetting" });

            routes.MapRoute("manage_index", "manage", new { controller = "Article", action = "List" });

            //article
            routes.MapRoute("manage_article_list", "manage/article_list_{pageIndex}_{pageSize}", new { controller = "Article", action = "List" });
            routes.MapRoute("manage_article_create", "manage/article_create", new { controller = "Article", action = "Create" });
            routes.MapRoute("manage_article_edit", "manage/article_edit_{articleId}", new { controller = "Article", action = "Edit" });

            //Category
            routes.MapRoute("manage_category_list", "manage/category_list", new { controller = "Category", action = "List" });
            routes.MapRoute("manage_category_create", "manage/category_create", new { controller = "Category", action = "Create" });
            routes.MapRoute("manage_category_edit", "manage/category_edit", new { controller = "Category", action = "Edit" });

            //Log
            routes.MapRoute("manage_log_list1", "manage/log_list", new { controller = "Log", action = "List" });
            routes.MapRoute("manage_log_list2", "manage/log_list_{pageIndex}_{pageSize}", new { controller = "Log", action = "List" });

            #endregion

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
