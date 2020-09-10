using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace IssueTrackingApplication1
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
            name: "UserInbox",
            url: "Inbox{Id}",
            defaults: new { controller = "Users", action = "Inbox" }
            );

            routes.MapRoute(
            name: "Update",
            url: "adminProfile/update/{id}",
            defaults: new { controller = "AdminProfile", action = "Update" }
           );

            routes.MapRoute(
           name: "DevUpdate",
           url: "DevUsers/update/{id}",
           defaults: new { controller = "DevUsers", action = "Update" }
          );

            routes.MapRoute(
            name: "DevInbox",
            url: "Inbox{Id}",
            defaults: new { controller = "DevUsers", action = "Inbox" }
            );

            routes.MapRoute(
            name: "Inbox",
            url: "Inbox{Id}",
            defaults: new { controller = "AdminProfile", action = "Inbox"}
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
