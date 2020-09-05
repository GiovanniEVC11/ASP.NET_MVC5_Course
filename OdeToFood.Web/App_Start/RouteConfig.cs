using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OdeToFood.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {

            // /trace.axd/1/2/3/4  --- 
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");  /* IMPORTANT */
            /*
                don't exist physically. 
                ASP.NET uses URLs with .axd extensions 
                (ScriptResource.axd and WebResource.axd) internally,
                and they are handled by an HttpHandler.
             */


            routes.MapRoute(
                name: "Default",
                //  Example: /home/contact/3
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
