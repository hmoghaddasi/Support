using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Support.Domain.Model;

namespace Support.DataAccess.EF.Mapping
{
    public class LogMapping : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.ToTable("Log", "gen").HasKey(a => a.LogId);
            builder.Property(a => a.LogId).ValueGeneratedOnAdd();

            builder.Property(p => p.Description).HasMaxLength(int.MaxValue);
            builder.HasOne(a => a.Person).WithMany(a => a.Logs).HasForeignKey(a => a.PersonId);
        }
       
    }
}
