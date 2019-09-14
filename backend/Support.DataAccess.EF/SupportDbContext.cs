using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Support.DataAccess.EF.Mapping;
using Support.Domain.Model;
using System;

namespace Support.DataAccess.EF
{
    public class SupportDbContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Access> Accesses { get; set; }
        public DbSet<AccessPolicy> AccessPolicies { get; set; }
        public DbSet<Config> Configs { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Response> Responses { get; set; }

        public SupportDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var baseUri = new Uri(AppDomain.CurrentDomain.BaseDirectory, UriKind.Absolute);
            var uri = new Uri(baseUri, @"..\..\..\..\Support.Host\appsettings.json").AbsolutePath;

            var builder = new ConfigurationBuilder()
                .AddJsonFile(uri, optional: true, reloadOnChange: true);
            optionsBuilder.UseSqlServer(builder.Build().GetValue<string>("ConnectionString"));
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersonMapping).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}