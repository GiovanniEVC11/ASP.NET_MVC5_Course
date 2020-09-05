using OdeToFood.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Web.Controllers
{
    public class GreetingController : Controller        /*Controller is designed to responde to an HTTP request by building a model and returning*/ 
    {
       
        // GET: Greeting
        public ActionResult Index(string name)
        {
            var model = new GreetingViewModel();
           
            model.Name = name ?? "no name"; 
            // Intead of: var name = HttpContext.Request.QueryString["name"];
     
            /* Obtain a static value from web config / JoinWebConfig.SelectAppSettings["Key"] */
            model.Message = ConfigurationManager.AppSettings["message"];
            return View(model);  /* right clic on View() to create a new View */
        }
    }
}