using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TxtBasedBlog
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "HomePage", // Route name
                "", // URL with parameters
                new { controller = "Home", action = "Index" }
            );

            routes.MapRoute(
                "Error", // Route name
                "Oops", // URL with parameters
                new { controller = "Home", action = "Error" }
            );

            routes.MapRoute(
                "BlogPost", // Route name
                "{postName}", // URL with parameters
                new { controller = "Home", action = "ViewBlogPost", postName = "" }
            );

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);
        }
    }
}