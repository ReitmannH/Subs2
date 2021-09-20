using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using Subs.Data;

namespace Subs.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            string lConnectionString = global::Subs.WebApi.Properties.Settings.Default.ConnectionString;

            if (lConnectionString == "")
            {
                throw new Exception("No connection string has been set.");
            }
            else
            {
                Settings.ConnectionString = lConnectionString;
            }

            // Web API configuration and services

            // Web API routes
            //config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
        }
    }
}
