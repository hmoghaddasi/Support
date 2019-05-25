using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Support.DataAccess.EF
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SupportDbContext>
    {
        public SupportDbContext CreateDbContext(string[] args)
        {
            var connectionString = GetConnectionString();

            var optionsBuilder = new DbContextOptionsBuilder();
            optionsBuilder.UseSqlServer(connectionString);
            return new SupportDbContext(optionsBuilder.Options);
        }

        private static string GetConnectionString()
        {
            var baseUri = new Uri(AppDomain.CurrentDomain.BaseDirectory, UriKind.Absolute);
            var uri = new Uri(baseUri, @"..\..\..\..\Support.Host\appsettings.json").AbsolutePath;

            var builder = new ConfigurationBuilder()
                .AddJsonFile(uri, optional: true, reloadOnChange: true);

            return builder.Build().GetValue<string>("ConnectionString");
        }
    }
}