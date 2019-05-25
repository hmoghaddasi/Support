using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Support.Config;
using Support.Host.Settings;

namespace Support.Host
{
    public class Startup
    {
        private DataSettings settings;
        public Startup(IConfiguration configuration)
        {
            settings = configuration.Get<DataSettings>();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddDbContext<SalesContext>();



            services.AddMvc();
            //services.AddMvc(a =>
            //{
            //    a.Filters.Add(new CustomActionFilter());
            //    a.Filters.Add(new AuthorizeFilter());
            //});
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new SupportModule(this.settings.ConnectionString));
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseCors(a =>
            {
                a.WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });

            app.UseMvcWithDefaultRoute();

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});
        }
    }
}
