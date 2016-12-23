using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SctJSKClient
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Account", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                "GetKeywords",
                "Keywords",
                new { controller = "Search", action = "GetKeywords" }
            );

            routes.MapRoute(
                "Search",
                "search/{term}",
                new { controller = "Search", action = "Index", term = "" }
            );

            routes.MapRoute(
                "ViewProduct",
                "product/{item}",
                new { controller = "Product", action = "ViewProduct", item = "" }
            );
        }
    }
}
