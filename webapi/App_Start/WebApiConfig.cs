using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using DependencyInjection.Services;
using System.Web.Http.Cors;

namespace webapi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            EnableCrossSiteRequests(config);
            AddRoutes(config);
            IocContainer.RegisterService();
            ModelMapper.ModelMapper.MapModels();
        }
        private static void AddRoutes(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                   name: "ActionApi",
                   routeTemplate: "api/{controller}/{action}/{id}",
                   defaults: new { id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
               name: "DefaultApi",
               routeTemplate: "api/{controller}/{id}",
               defaults: new { id = RouteParameter.Optional, controller = "Register" }
           );

        }
        private static void EnableCrossSiteRequests(HttpConfiguration config)
        {
            var cors = new EnableCorsAttribute(
                origins: "*",
                headers: "*",
                methods: "*");
            config.EnableCors(cors);
        }
    }
}
