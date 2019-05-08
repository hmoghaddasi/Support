using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Support.Host
{
    public class Startup
    {
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
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDefaultFiles();
            app.UseStaticFiles();

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
