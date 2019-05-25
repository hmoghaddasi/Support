using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Support.Domain.Model;

namespace Support.DataAccess.EF.Mapping
{
    public class PersonMapping : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
          builder.ToTable("Person", "gen").HasKey(a => a.PersonId);
          builder.Property(a => a.PersonId).ValueGeneratedOnAdd();
          builder.HasOne(a => a.Status).WithMany().HasForeignKey(a => a.StatusId).OnDelete(DeleteBehavior.Cascade);
          //builder.HasOne(a => a.Category).WithMany().HasForeignKey(a => a.CategoryId).WillCascadeOnDelete(false);
            //builder.HasOne(a => a.Group).WithMany().HasForeignKey(a => a.GroupId).WillCascadeOnDelete(false);
            //builder.HasOne(a => a.PersonType).WithMany().HasForeignKey(a => a.PersonTypeId).WillCascadeOnDelete(false);
            //builder.HasOne(a => a.InsuranceType).WithMany().HasForeignKey(a => a.InsuranceTypeId).WillCascadeOnDelete(false);
            //builder.HasOne(a => a.Location).WithMany(a=>a.Persons).HasForeignKey(a => a.LocationId).WillCascadeOnDelete(false);
            //builder.Property(a => a.NationalCode).HasMaxLength(10);
        }

    }
}
