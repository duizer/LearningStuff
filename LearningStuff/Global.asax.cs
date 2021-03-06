﻿using System.Diagnostics;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace LearningStuff
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Trace.TraceInformation("Application starting...");

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Trace.TraceInformation("Application started");
        }
    }
}
