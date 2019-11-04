using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Support.Domain.Model;

namespace Support.DataAccess.EF.Mapping
{
    public class PersonMapping : EntityTypeConfiguration<Person>
    {
        public PersonMapping()
        {
            ToTable("Person", schemaName: "gen").HasKey(a => a.PersonId).Property(a => a.PersonId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(h => h.Status).WithMany().HasForeignKey(h => h.StatusId);

        }

    }
}
