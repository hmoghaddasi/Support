using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Support.Domain.Model;

namespace Support.DataAccess.EF.Mapping
{
    public class ConfigMapping : IEntityTypeConfiguration<Config>
    {
        public ConfigMapping(EntityTypeBuilder<Config> builder)
        {
            builder.ToTable("Config", schemaName: "gen").HasKey(a => a.ConfigId).Property(a => a.ConfigId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            builder.HasRequired(a => a.ConfigHdr).WithMany().HasForeignKey(a => a.ConfigHdrId).WillCascadeOnDelete(false);

        }
    }
}


//public class CustomerMapping : IEntityTypeConfiguration<Customer>
//{
//    public void Configure(EntityTypeBuilder<Customer> builder)
//    {
//        builder.ToTable("Customers");
//        builder.Property(a => a.Firstname).HasMaxLength(255);
//        builder.Property(a => a.Lastname).HasMaxLength(255);

//    }
//}