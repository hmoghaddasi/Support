using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Support.Domain.Model;

namespace Support.DataAccess.EF.Mapping
{
    public class AccessMapping : IEntityTypeConfiguration<Access>
    {
        public AccessMapping(EntityTypeBuilder<Access> builder)
        {
            builder.ToTable("Access", schemaName: "sec").HasKey(a => a.AccessId).Property(a => a.AccessId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            builder.Property(a => a.HelpDscp).HasColumnType("nvarchar(max)");

        }
    }
}
