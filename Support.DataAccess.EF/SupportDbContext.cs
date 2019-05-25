using Microsoft.EntityFrameworkCore;
using Support.DataAccess.EF.Mapping;
using Support.Domain.Model;

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
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("data source=.;initial catalog=SupportDB;Integrated security=true");
        //    base.OnConfiguring(optionsBuilder);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersonMapping).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}