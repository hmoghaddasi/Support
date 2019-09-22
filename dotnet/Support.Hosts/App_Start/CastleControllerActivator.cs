using System;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using Castle.Windsor;

namespace Support.Hosts
{
    public class CastleControllerActivator : IHttpControllerActivator
    {
        private IWindsorContainer _container;

        public CastleControllerActivator(IWindsorContainer container)
        {
            _container = container;
        }

        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor,
            Type controllerType)
        {
            return (IHttpController) _container.Resolve(controllerType);
        }
    }
}