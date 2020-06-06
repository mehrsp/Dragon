using System.Web.Http;
using System.Web.Http.Dispatcher;
using Rosentis.Api;
using Rosentis.Api.IoCConfig;
using Rosentis.Api.JsonWebTokenConfig;
using Microsoft.Owin;
using Owin;
using StructureMap;

[assembly: OwinStartup(typeof(Rosentis.Api.App_Start.OwinStartup))]
namespace Rosentis.Api.App_Start
{
    public class OwinStartup
    {

        public void Configuration(IAppBuilder app)
        {
            app.UseOAuthAuthorizationServer(SmObjectFactory.Container.GetInstance<AppOAuthOptions>());
            app.UseJwtBearerAuthentication(SmObjectFactory.Container.GetInstance<AppJwtOptions>());
			HttpConfiguration config = new HttpConfiguration();
			WebApiConfig.Register(config);
            InitializeContainer(config);
		}
        public void InitializeContainer(HttpConfiguration config)
        {
            // STRUCTURE MAP
            Container container = new Container();
            config.Services.Replace(typeof(IHttpControllerActivator), new SmWebApiControllerActivator(container));
        }
        public void ConfigureOAuth(IAppBuilder app)
        {

        }
    }
}