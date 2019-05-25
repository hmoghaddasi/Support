using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Support.Domain.Model;

namespace Support.DataAccess.EF.Mapping
{
    public class ConfigMapping : IEntityTypeConfiguration<Config>
    {
        public void Configure(EntityTypeBuilder<Config> builder)
        {
            builder.ToTable("Config", "gen").HasKey(a => a.ConfigId);
            builder.Property(a => a.ConfigId).ValueGeneratedOnAdd();
            builder.HasOne(a => a.ConfigHdr).WithMany().HasForeignKey(a => a.ConfigHdrId);

        }
    }
}
