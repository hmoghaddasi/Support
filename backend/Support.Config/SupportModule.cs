using Autofac;
using Microsoft.EntityFrameworkCore;
using Support.Application.Contract.IService;
using Support.Application.Service;
using Support.DataAccess.EF;
using Support.DataAccess.EF.Repository;
using Support.Domain.IRepositories;


namespace Support.Config
{
    public class SupportModule : Module
    {
        private readonly string _connectionString;
        public SupportModule(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register<SupportDbContext>(SupportDbContextFactory).InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(AuthorizationService).Assembly)
                .AssignableTo<IAuthorizationService>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(ConfigService).Assembly)
                .AssignableTo<IApplicationService>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(ConfigRepository).Assembly)
                .AssignableTo<IRepository>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }

        private SupportDbContext SupportDbContextFactory(IComponentContext arg)
        {
            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseSqlServer(this._connectionString);
            return new SupportDbContext(optionsBuilder.Options);
        }
    }
}