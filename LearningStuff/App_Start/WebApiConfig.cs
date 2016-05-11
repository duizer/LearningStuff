using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using Microsoft.ApplicationInsights;

namespace LearningStuff
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Services.Add(typeof(IExceptionLogger), new TelemetryExceptionLogger());
        }

        public class TelemetryExceptionLogger : ExceptionLogger
        {
            public override void Log(ExceptionLoggerContext context)
            {
                if (context != null && context.Exception != null)
                { 
                    var tc = new TelemetryClient();
                    tc.TrackException(context.Exception);
                }
                base.Log(context);
            }
        }
    }
}
