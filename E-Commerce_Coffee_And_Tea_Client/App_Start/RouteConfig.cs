using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace E_Commerce_Coffee_And_Tea_Client
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Bật Attribute Routing
            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "E_Commerce_Coffee_And_Tea_Client.Controllers" }
            );
            routes.MapRoute(
                name: "Home",
                url: "",
                defaults: new { controller = "Home", action = "Index" }
            );
            routes.MapRoute(
                name: "Product",
                url: "product",
                defaults: new { controller = "Product", action = "Index" }
            );
            routes.MapRoute(
                name: "ProductDetail",
                url: "product/detail/{productId}/{sizeId}",
                defaults: new { controller = "Product", action = "Detail" }
            );
            routes.MapRoute(
                name: "SearchProduct",
                url: "product/search",
                defaults: new { controller = "Product", action = "SearchProduct" }
            );
            routes.MapRoute(
                name: "Profile",
                url: "profile",
                defaults: new { controller = "Customer", action = "GetInfo" }
            );
        }
    }
}
