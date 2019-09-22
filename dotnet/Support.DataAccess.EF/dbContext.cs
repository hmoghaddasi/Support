using System;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Threading;
using Support.Domain.Model;

namespace Support.DataAccess.EF
{
    public class dbContext : DbContext
    {
      
        public DbSet<Access> Accesses { get; set; }
        public DbSet<AccessPolicy> AccessPolicies { get; set; }
        public DbSet<Config> Configs { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<FileLog> FileLogs { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<Request> Requests { get; set; }


        public dbContext(DbConnection connection, bool contextOwnConnection = false)
            : base(connection, contextOwnConnection)
        {
            
            ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = 3600;
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<string>().Configure(c => c.HasMaxLength(255));

            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.AddFromAssembly(typeof(dbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            //var changed = this.ChangeTracker
            //    .Entries().Where(a => a.State == EntityState.Added ||
            //                          a.State == EntityState.Deleted ||
            //                          a.State == EntityState.Modified)
            //    .ToList();
           // this.HandleValueObject<Order, OrderItem>(a => a.Items);
            try
            {
                //SaveDataChangeLog();
                return base.SaveChanges();
            }
            catch (Exception exception)
            {
                
                throw exception;
            }
            
        }


        private void SaveDataChangeLog()
        {
            var modifiedEntities = ChangeTracker.Entries().Where(p => p.State == EntityState.Modified).ToList();

            var currentPersonId = GetCurrentPersonId();

            foreach (var change in modifiedEntities)
            {
                var primaryKey = GetPrimaryKeyValue(change);
                var changeLog = new ChangeLog();
                var log = changeLog.GetDataChangeLogModel(change, primaryKey, currentPersonId);
                if (log != null)
                {
                    Logs.Add(log);
                }

            }
        }

        private int GetCurrentPersonId()
        {
            var currentUser = Thread.CurrentPrincipal.Identity.Name.ToLower();
            var currentPersonId = this.Persons.FirstOrDefault(a => a.LoginName.ToLower() == currentUser)?.PersonId ?? 0;
            return currentPersonId;
        }

        private int GetPrimaryKeyValue(DbEntityEntry entry)
        {
            var objectStateEntry = ((IObjectContextAdapter)this).ObjectContext.ObjectStateManager.GetObjectStateEntry(entry.Entity);
            return Convert.ToInt32(objectStateEntry.EntityKey.EntityKeyValues[0].Value);
        }
    }
}
