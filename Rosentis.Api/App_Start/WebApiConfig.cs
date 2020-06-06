using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Dispatcher;
using System.Web.Http.Filters;
using System.Web.Http.Tracing;
using Rosentis.Api.Helpers;
using Rosentis.Api.IoCConfig;
using Rosentis.Api.Models;

namespace Rosentis.Api
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
			name: "DefaultApi",
			routeTemplate: "{controller}/{action}/{id}",
			defaults: new { id = RouteParameter.Optional }
		);
			var cors = new EnableCorsAttribute("*", "*", "*");
			config.EnableCors(cors);
			var container = SmObjectFactory.Container;
			GlobalConfiguration.Configuration.Services.Replace(
				typeof(IHttpControllerActivator), new SmWebApiControllerActivator(container));
			GlobalConfiguration.Configuration.Services.Replace(typeof(System.Web.Http.Tracing.ITraceWriter), new NLogger());
			var json = config.Formatters.JsonFormatter;
			json.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Local;
			config.Services.Replace(typeof(IFilterProvider), new SmWebApiFilterProvider(container));
			// Web API routes

		
		}
	}
}
