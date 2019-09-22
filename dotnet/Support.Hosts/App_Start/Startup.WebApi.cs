using System.Configuration;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using FiveLevelsOfMediaType;
using Owin;
using Support.Config;
using Support.Hosts.Factory;
using Support.Hosts.Filters;

namespace Support.Hosts
{
    public partial class Startup
    {
        public void ConfigureWebApi(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            EnableCors(config);
            config.AddFiveLevelsOfMediaType();
            config.Filters.Add(new System.Web.Http.AuthorizeAttribute());
            SwaggerConfig.Configure(config);
            config.Filters.Add(new CustomExceptionFilter());
            //  config.Filters.Add(new JwtAuthenticationAttribute());
            ConfigRouting(config);
            ConfigControllerActivator(config);

            app.UseWebApi(config);
        }

        private static void ConfigRouting(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

        }

        private static void EnableCors(HttpConfiguration config)
        {
            var origin = ConfigurationManager.AppSettings["TrustedOrigin"];
            var publishCors = new EnableCorsAttribute(origin, "*", "*");
            config.EnableCors(publishCors);
            
        }

        private static void ConfigControllerActivator(HttpConfiguration config)
        {
            var container = Bootstrapper.WireUp<ApiController,IController>(typeof(Startup).Assembly);

            var contollerActivator = new CastleControllerActivator(container);
            config.Services.Replace(typeof(IHttpControllerActivator), contollerActivator);

            ControllerBuilder.Current.SetControllerFactory(new WindsorControllerFactory(container));

        }
    }
}