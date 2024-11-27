using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace E_Commerce_Coffee_And_Tea_Client
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Cấu hình Web API để sử dụng JSON formatter
            // Cấu hình JSON formatter
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();

            // Đảm bảo rằng Web API sử dụng JSON làm định dạng mặc định
            config.Formatters.Remove(config.Formatters.XmlFormatter);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            #region

            config.Routes.MapHttpRoute(
                name: "API_AddToCart",
                routeTemplate: "api/cart/add-to-cart",
                defaults: new { id = RouteParameter.Optional }
            );

            #endregion
        }
    }
}