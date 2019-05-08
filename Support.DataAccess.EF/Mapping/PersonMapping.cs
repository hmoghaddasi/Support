using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Support.Domain.Model;

namespace Support.DataAccess.EF.Mapping
{
    public class PersonMapping : IEntityTypeConfiguration<Person>
    {
        public PersonMapping(EntityTypeBuilder<Person> builder)
        {
          builder.ToTable("Person", schemaName: "gen").HasKey(a => a.PersonId).Property(a => a.PersonId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
          builder.HasRequired(a => a.Category).WithMany().HasForeignKey(a => a.CategoryId).WillCascadeOnDelete(false);
          builder.HasRequired(a => a.Group).WithMany().HasForeignKey(a => a.GroupId).WillCascadeOnDelete(false);
          builder.HasRequired(a => a.Status).WithMany().HasForeignKey(a => a.StatusId).WillCascadeOnDelete(false);
          builder.HasRequired(a => a.PersonType).WithMany().HasForeignKey(a => a.PersonTypeId).WillCascadeOnDelete(false);
          builder.HasRequired(a => a.InsuranceType).WithMany().HasForeignKey(a => a.InsuranceTypeId).WillCascadeOnDelete(false);
          builder.HasRequired(a => a.Location).WithMany(a=>a.Persons).HasForeignKey(a => a.LocationId).WillCascadeOnDelete(false);
            builder.Property(a => a.NationalCode).HasMaxLength(10);
        }
    }
}
