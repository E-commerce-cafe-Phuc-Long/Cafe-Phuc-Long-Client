using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Unity;

namespace E_Commerce_Coffee_And_Tea_Client
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            UnityConfig.RegisterComponents();
        }
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            // Thêm header CORS để cho phép truy cập từ bất kỳ domain nào
            HttpContext.Current.Response.AppendHeader("Access-Control-Allow-Origin", "*");

            // (Tuỳ chọn) Cho phép thêm các phương thức khác như POST, GET, OPTIONS
            HttpContext.Current.Response.AppendHeader("Access-Control-Allow-Methods", "GET, POST, OPTIONS");

            // (Tuỳ chọn) Cho phép các header cụ thể
            HttpContext.Current.Response.AppendHeader("Access-Control-Allow-Headers", "Content-Type, Authorization");
        }

    }
}
