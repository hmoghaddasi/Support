using System.Text;
using Autofac;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Support.Host.Settings;
using Microsoft.AspNetCore.Http;
using Support.Host.Middleware;
using Support.Host.Tools;
using Support.Host.HttpStatus;
using Support.DataAccess.EF;
using System;
using Autofac.Extensions.DependencyInjection;
using Support.Application.Service;
using Support.Application.Contract.IService;
using Support.Domain.IRepositories;
using Support.DataAccess.EF.Repository;
using Framework.Kavenegar;
using Framework.Core.Notification;

namespace Support.Host
{
    public class Startup
    {
        private DataSettings settings;
        private IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            settings = configuration.Get<DataSettings>();
            Configuration = configuration;
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuer = true,
                       ValidateAudience = true,
                       ValidateLifetime = true,
                       ValidateIssuerSigningKey = true,
                       ValidIssuer = Configuration["Jwt:Issuer"],
                       ValidAudience = Configuration["Jwt:Issuer"],
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                   };
               });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<SupportDbContext>(options =>
            {
            });
            services.AddSwaggerDocumentation();

            //Now register our services with Autofac container
            var builder = new ContainerBuilder();
            //add services to autofac container
            builder.RegisterType<AuthorizationService>().As<IAuthorizationService>();
            builder.RegisterType<PersonRepository>().As<IPersonRepository>();
            builder.RegisterType<NotificationService>().As<INotificationService>();
            builder.RegisterType<AccessPolicyService>().As<IAccessPolicyServices>();
            builder.RegisterType<AccessPolicyRepository>().As<IAccessPolicyRepository>();
            builder.RegisterType<AccessRepository>().As<IAccessRepository>();
            builder.RegisterType<ConfigRepository>().As<IConfigRepository>();
            builder.RegisterType<ConfigService>().As<IConfigService>();

            //builder.RegisterType<SiteAnalyticsServices>();
            builder.Populate(services);
            var container = builder.Build();
            //Create the IServiceProvider based on the container.
            return new AutofacServiceProvider(container);
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseCors(a =>
            {
                a.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
            app.UseSwagger();
            app.UseSwaggerDocumentation();
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            app.UseMvcWithDefaultRoute();
            app.UseMiddleware<StatusCodeExceptionHandler>();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
