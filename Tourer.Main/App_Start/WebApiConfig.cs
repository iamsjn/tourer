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
                name: "SendPushNotification",
                routeTemplate: "api/gcm/sendnotification",
                defaults: new { controller = "GCM", action = "SendPushNotification" }
            );

            config.Routes.MapHttpRoute(
                name: "GetSeasonalTouristAttraction",
                routeTemplate: "api/default/seasonal",
                defaults: new { controller = "Default", action = "GetSeasonalTouristAttraction" }
            );

            config.Routes.MapHttpRoute(
                name: "GetLocationalTouristAttraction",
                routeTemplate: "api/default/locational",
                defaults: new { controller = "Default", action = "GetLocationalTouristAttraction" }
            );

            config.Routes.MapHttpRoute(
                name: "GetTouristAttractionSuggestion",
                routeTemplate: "api/suggestion/suggestions/{locationID}",
                defaults: new { controller = "Suggestion", action = "GetTouristAttractionSuggestion", locationID = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "SearchTouristAttraction",
                routeTemplate: "api/search/searchta/{searchKeyword}",
                defaults: new { controller = "Search", action = "SearchTouristAttraction", searchKeyword = RouteParameter.Optional }
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
