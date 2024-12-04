using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Services.Description;

namespace E_Commerce_Coffee_And_Tea_Client
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Bật Attribute Routing
            routes.MapMvcAttributeRoutes();

            #region Home Routes

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

            #endregion

            #region Product Routes

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

            #endregion

            #region Authentication Routes

            routes.MapRoute(
                name: "Profile",
                url: "profile",
                defaults: new { controller = "Customer", action = "GetInfo" }
            );

            routes.MapRoute(
                name: "Update Information",
                url: "profile/update-information",
                defaults: new { controller = "Customer", action = "UpdateInformation" }
            );
            routes.MapRoute(
                name: "Change Password",
                url: "profile/change-password",
                defaults: new { controller = "Customer", action = "UpdateAccount" }
            );

            routes.MapRoute(
                name: "Login",
                url: "auth/login",
                defaults: new { controller = "Auth", action = "Login" }
            );

            routes.MapRoute(
                name: "Register",
                url: "auth/register",
                defaults: new { controller = "Auth", action = "Register" }
            );

            routes.MapRoute(
                name: "Logout",
                url: "auth/logout",
                defaults: new { controller = "Auth", action = "Logout" }
            );

            #endregion

            #region Order Routes

            routes.MapRoute(
                name: "Order",
                url: "order",
                defaults: new { controller = "Order", action = "Order" }
            );
            routes.MapRoute(
                name: "Create Order",
                url: "order/create-order",
                defaults: new { controller = "Order", action = "CreateOrder" }
            );
            routes.MapRoute(
                name: "Pending Orders",
                url: "order/pending",
                defaults: new { controller = "Order", action = "PendingOrders" }
            );
            routes.MapRoute(
                name: "Preparing Orders",
                url: "order/preparing",
                defaults: new { controller = "Order", action = "PreparingOrders" }
            );
            routes.MapRoute(
                name: "Completed Orders",
                url: "order/completed",
                defaults: new { controller = "Order", action = "CompletedOrders" }
            );
            routes.MapRoute(
                name: "Canceled Orders",
                url: "order/canceled",
                defaults: new { controller = "Order", action = "CanceledOrders" }
            );
            #endregion
        }
    }
}
