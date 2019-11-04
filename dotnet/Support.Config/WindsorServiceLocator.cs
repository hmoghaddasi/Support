using Castle.Windsor;
using Framework.Core.ServiceLocator;

namespace Support.Config
{
    public class WindsorServiceLocator : IServiveLocator
    {
        private readonly IWindsorContainer _container;

        public WindsorServiceLocator(IWindsorContainer container)
        {
            _container = container;
        }

        public T GetInstance<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
