using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Sky.Blog
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "List", id = UrlParameter.Optional }
            );
            //Error pages
            routes.MapRoute("404", "404", new { controller = "ErrorPage", action = "Error404" });
            routes.MapRoute("500", "500", new { controller = "ErrorPage", action = "Error500" });
            routes.MapRoute("illegal", "illegal", new { controller = "ErrorPage", action = "IllegalOperation" });
            routes.MapRoute("lackauthority", "lackauthority", new { controller = "ErrorPage", action = "LackAuthority" });

        }
    }
}
