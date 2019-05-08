using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Support.Domain.Model;

namespace Support.DataAccess.EF.Mapping
{
public class LogMapping : IEntityTypeConfiguration<Log>
{
public LogMapping(EntityTypeBuilder<Log> builder)
{

    builder.ToTable("Log", schemaName: "gen")
        .HasKey(a => a.LogId)
        .Property(a => a.LogId)
        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

    builder.Property(p => p.Description).HasMaxLength(Int32.MaxValue);
    builder.HasRequired(a => a.Person).WithMany(a=>a.Logs).HasForeignKey(a => a.PersonId);
        }
    }
}
