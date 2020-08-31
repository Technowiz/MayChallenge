using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebAPiDemoProj
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            /*Area allows us to partition large application into smaller units where each unit contains separate MVC folder structure
             AreaRegistration class overrides RegisterArea method to map the routes for the area. 
             In the above example, any URL that starts with admin will be handled by the controllers included in the admin folder structure under Area folder. 
             For example, http://localhost/admin/profile will be handled by profile controller included in Areas/admin/controller/ProfileController folder.
            Finally, all the area must be registered in Application_Start event in Global.asax.cs as AreaRegistration.RegisterAllAreas();*/
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);//To Add additional logic before and after your action method
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
