using OdeToFood.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    /*Homcontroler will be used in URL */
    public class HomeController : Controller
    {
        /*Adding a private field .... Access to DB through an Interface (IRestaurantData) */
        IRestaurantData db;

        /*Contructor*/
        public HomeController( IRestaurantData db ) {
            /* Calling simulated data */
            //db = new InMemoryRestaurantData();

            /*Inversion of control container: Something that knows how to build objects 
             * and how to analyze objects like HOMECONTROLER to undestand what 
             * debendencies are required, and then, the container that can figure out
             * what to inject when we have a constructor that recives what implement 
             * 
             *  public HomeController( IRestaurantData db )
             *  this.db = db;
             *  
             *  But we are going to need a third-party component. There are many packages out there and open source
             *  linraries that provide inversion of Control containers (like Ninject, StructureMap)
             *  We are going to use Autofact (available as a NuGet package)
             *  
             */
            this.db = db;
        }

        /*Action Result tells to Framework What to do next */
        public ActionResult Index() /* Action Index */
        {
            /**/
            var model = db.GetAll();
            return View(model); /*Presentation*/
        }

        public ActionResult About() /* Action About */
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() /* Action Contact */
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}