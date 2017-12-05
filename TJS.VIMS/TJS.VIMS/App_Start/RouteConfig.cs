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

            //TMP TESTING
            //routes.MapRoute(
            //     name: "Route66",
            //     url: "{controller}/{action}/{locationId}/{userId}"
            //  );

            routes.MapRoute(
                  name: "Capture",
                  url: "VolunteerClockTime/Capture/{userId}",
                  defaults: new { controller = "VolunteerClockTime", action = "Capture", userId = UrlParameter.Optional }
              );

            // //TMP TESTING
            // routes.MapRoute(
            //     name: "Test1",
            //     url: "VolunteerClockTime/Test1/{x}/{s}",
            //     defaults: new { controller = "VolunteerClockTime", action = "Test1", x = UrlParameter.Optional, s = UrlParameter.Optional}
            // );

            // //TMP TESTING
            // routes.MapRoute(
            //    name: "Test2",
            //    url: "VolunteerClockTime/Test2/{x}",
            //    defaults: new { controller = "VolunteerClockTime", action = "Test2", x = UrlParameter.Optional }
            //);

            routes.MapRoute(
                   name: "Login",
                   url: "Account/Login/{organizationId}",
                   defaults: new { controller = "Account", action = "Login" }
           );

          //  routes.MapRoute(
          //      name: "HACK",
          //      url: "Administration/CreateEmployee/{admin_id}",
          //      defaults: new { controller = "Administration", action = "CreateEmployee" }
          //);

            routes.MapRoute(
                  name: "Admin",
                  url: "Administration/{action}/{admin_id}/{id}",
                  defaults: new { controller = "Administration" } 
            );

            routes.MapRoute(
                name: "Admin2",
                url: "Administration/{action}/{admin_id}",
                defaults: new { controller = "Administration" }
          );

            routes.MapRoute(
                    name: "Default",
                    url: "{controller}/{action}/{id}",
                    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


        }
    }
}
