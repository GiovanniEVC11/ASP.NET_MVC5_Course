using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace OdeToFood.Web /*.App_Start <- eliminated */
{

    public class ContainerConfig
    {
        /* The internal statics function is added when put a RegisterContainer function in Global.asax.cs*/
        // Method that invoke from Global.asax.cs 
         internal static void RegisterContainer(HttpConfiguration httpConfiguration)
         {
             /* Autofact API  */
             var builder = new ContainerBuilder(); /*will build an IoC Container */

            /*Invoking a custom extension method specifically designed to Integrate MVC 5*/
            /*scan through my project for the different controller types & register those with Autofact */
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            /* Adding  */
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);

            /*Defining Specific Services*/
            builder.RegisterType<InMemoryRestaurantData>()  /* Register this type InMe */
                .As<IRestaurantData>() /*Use that type when someone needs something that implements IRestaurantData*/
                .SingleInstance();  /* For more consistency but it will not work with multiple users */

            var container = builder.Build(); /*Use container when whenever you need to resolve dependencies */

            /* DependencyResolver: Class defined by MVC5 (System.Web .mvc namespace/ is a class with a couple static members) */
            /* SetResolver: and one of thoses memeber is SetResolver */
            /* Use a WRAPPER provided by Autofac library, which is the AutofacDependencyResolver wrapper
             * that wrap a container for consumption by MVC5*/
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            /* Adding WEP API to depnendency resolver / The class AutofacWebApiDependencyResolver doesn't exists in our project 
             * but exists in another Nuget  package isntalled  */
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);



         }
    }
}