using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Routing;

namespace Forma_Gym
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
			var setting = config.Formatters.JsonFormatter.SerializerSettings; 
			setting.Formatting= Formatting.Indented;
			setting.ContractResolver= new CamelCasePropertyNamesContractResolver();

			// Web API configuration and services

			// Web API routes
			config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
			config.Routes.MapHttpRoute(
				name: "Api_Post",
				routeTemplate: "api/{controller}/{action}/{id}",
				defaults: new { id = RouteParameter.Optional, action = "Post" },
				constraints: new { httpMethod = new HttpMethodConstraint("POST") }
			);
		}
    }
}
