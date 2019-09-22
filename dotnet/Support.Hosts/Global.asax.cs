using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;

namespace Support.Hosts
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static IWindsorContainer container;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            
 
        }
    }
}
