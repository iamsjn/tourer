using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Tourer.Main
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "GetSeasonalTouristAttraction",
                routeTemplate: "api/home/seasonal",
                defaults: new { controller = "Default", action = "GetSeasonalTouristAttraction" }
            );

            config.Routes.MapHttpRoute(
                name: "GetLocationalTouristAttraction",
                routeTemplate: "api/home/locational",
                defaults: new { controller = "Default", action = "GetLocationalTouristAttraction" }
            );

            config.Routes.MapHttpRoute(
                name: "SignUp",
                routeTemplate: "api/default/signup",
                defaults: new { controller = "Default", action = "SignUp" }
            );

            config.Routes.MapHttpRoute(
                name: "SignIn",
                routeTemplate: "api/default/signin",
                defaults: new { controller = "Default", action = "SignIn" }
            );
        }
    }
}
