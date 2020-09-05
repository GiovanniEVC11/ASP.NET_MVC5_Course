Visual Studio has added the full set of dependencies for ASP.NET Web API 2 to project 'OdeToFood.Web'. 

The Global.asax.cs file in the project may require additional changes to enable ASP.NET Web API.

1. Add the following namespace references in Global.axas.cs:

    using System.Web.Http;
    using System.Web.Routing;

2. If the code does not already define an Application_Start method, add the following method:

    protected void Application_Start()
    {
    }

3. Add the following lines to the beginning of the Application_Start method:

    GlobalConfiguration.Configure(WebApiConfig.Register);