using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

/*API 2 ASP.NET*/
using System.Web.Http;
//using System.Web.Routing;

namespace OdeToFood.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            /* Adding API 2 to MVC */
            GlobalConfiguration.Configure(WebApiConfig.Register);

            RouteConfig.RegisterRoutes(RouteTable.Routes); /* Tell to MVC waht rules aply to map an incoming URL*/
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            /*Adding ContainerConfig to configuration AUTOFACT.MVC5 envolving GlobalConfiguration WebAPI*/
            ContainerConfig.RegisterContainer(GlobalConfiguration.Configuration);
        }
    }
}
