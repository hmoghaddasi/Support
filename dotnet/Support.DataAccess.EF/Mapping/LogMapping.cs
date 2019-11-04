using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Support.Domain.Model;

namespace Support.DataAccess.EF.Mapping
{
    public class LogMapping : EntityTypeConfiguration<Log>
    {
        public LogMapping()
        {

            ToTable("Log", schemaName: "gen")
                .HasKey(a => a.LogId)
                .Property(a => a.LogId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(p => p.Description).HasMaxLength(Int32.MaxValue);
            HasRequired(a => a.Person).WithMany(a => a.Logs).HasForeignKey(a => a.PersonId);
        }
    }
}
