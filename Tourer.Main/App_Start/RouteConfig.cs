using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Tourer.Main
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapHttpRoute(
                name: "Default",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { controller = "Default", action = "Index", id = RouteParameter.Optional }
            );

            routes.MapHttpRoute(
                name: "SignUp",
                routeTemplate: "api/user/signup",
                defaults: new { controller = "Default", action = "SignUp" }
            );

            routes.MapHttpRoute(
                name: "SignIn",
                routeTemplate: "api/user/signin",
                defaults: new { controller = "Default", action = "SignIn" }
            );

            routes.MapHttpRoute(
                name: "Home",
                routeTemplate: "api/user",
                defaults: new { controller = "Home", action = "Index" }
            );
        }
    }
}
