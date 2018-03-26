using Owin;
using OwinSelfHost.Ioc;
using OwinSelfHost.Middlewares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace OwinSelfHost
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            var service = IoCResolverFactory.GetContainer().Resolve<ICurrentRequestService>(); // in the application scope
            appBuilder.Use<SetupMiddleware>();

            // Configure Web API for self-host. 
            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            appBuilder.UseWebApi(config);
        }
    }
}
