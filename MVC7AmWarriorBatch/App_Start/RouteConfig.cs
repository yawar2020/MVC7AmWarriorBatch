using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC7AmWarriorBatch
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //routes.IgnoreRoute("Default/AboutUS");

            

            routes.MapRoute(
               name: "Default1",
               url: "Toys/Gun",
               defaults: new { controller = "Default", action = "Jerry", id = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{Empid}",
                defaults: new { controller = "Default", action = "AboutUS", Empid = UrlParameter.Optional }
            );

        }
    }
}
