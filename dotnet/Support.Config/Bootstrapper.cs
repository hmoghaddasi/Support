using System.Data.Common;
using System.Data.Entity;
using System.Reflection;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Framework.Core.Data;
using Framework.Core.Notification;
using Framework.Core.OnionClass;
using Framework.Core.ServiceLocator;
using Framework.Core.SQLAction;
using Framework.Core.UnitOfWork;
using Framework.EF;
using Framework.Kavenegar;
using Support.Application.Service;
using Support.DataAccess.EF;
using Support.DataAccess.EF.Repository;

namespace Support.Config
{
    public static class Bootstrapper
    {

        public static IWindsorContainer WireUp<T>(Assembly presentationAssembly)
        {
            var container = new WindsorContainer();

            ServiveLocator.SetCurrent(new WindsorServiceLocator(container));
            container.Register(
               Classes.FromAssembly(presentationAssembly)
                   .BasedOn<T>()
                   .LifestyleTransient());

            ServiveLocator.SetCurrent(new WindsorServiceLocator(container));
            //container.Register(
            //   Classes.FromAssembly(presentationAssembly)
            //       .BasedOn<U>()
            //       .LifestyleTransient());

            container.Register(Component.For<TransactionInterceptor>()
                .LifestylePerWebRequest());

            container.Register(Component.For<INotificationHelper>()
                .ImplementedBy<NotificationHelper>().LifestylePerWebRequest());

            container.Register(Classes.FromAssemblyContaining<AccessServices>()
                .BasedOn<IApplicationService>()
                .WithServiceFromInterface()
                .Configure(a=>a.Interceptors<TransactionInterceptor>())
                .LifestylePerWebRequest());

            container.Register(Classes.FromAssemblyContaining<AccessRepository>()
                .BasedOn<IRepository>()
                .WithServiceFromInterface()
                .LifestylePerWebRequest());

            container.Register(Component.For(typeof(IGenericSQLAction<>))
             .ImplementedBy(typeof(GenericSQLAction<>)).LifestylePerWebRequest());

            

            container.Register(Component.For<IUnitOfWork>()
                .ImplementedBy<EfUnitOfWork>().LifestylePerWebRequest());

            container.Register(Component.For<dbContext>()
                .Forward<DbContext>()
                .LifestylePerWebRequest());

            container.Register(Component.For<DbConnection>()
                .UsingFactoryMethod(a =>
                {
                    var connection = ConnectionFactory.Create("DBConnection");
                    connection.Open();
                    //        Logger.Current.Write("Connection Opened",LogLevel.Debug);
                    return connection;

                })
                .LifestylePerWebRequest()
                .OnDestroy(a =>
                {
                    a.Close();
                    //  Logger.Current.Write("Connection Closed",LogLevel.Debug);
                }));

            //  Logger.Current = new Log4NetLogger();
            //  Logger.Current.Write("System is running...",LogLevel.Debug);

            return container;
        }
        
      
    }
}