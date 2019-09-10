using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Support.Config;
using Support.Host.Settings;
using Swashbuckle.AspNetCore.Swagger;

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



            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1.0", new Info { Title = "Support API", Version = "1.0" });
            });
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

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1.0/swagger.json", "Support API (V 1.0)");
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
