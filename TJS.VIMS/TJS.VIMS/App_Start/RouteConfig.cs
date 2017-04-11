using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TJS.VIMS
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //     name: "Route66",
            //     url: "{controller}/{action}/{locationId}/{userId}"
            //  );

            routes.MapRoute(
                  name: "Capture",
                  url: "VolunteerClockTime/Capture/{id}",
                  defaults: new { controller = "VolunteerClockTime", action = "Capture", id = UrlParameter.Optional }
              );

            routes.MapRoute(
                    name: "Default",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "Account", action = "Login", id = UrlParameter.Optional }
            );
        }
    }
}
