using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Support.Domain.Model;

namespace Support.DataAccess.EF.Mapping
{
    public class ResponseMapping : IEntityTypeConfiguration<Response>
    {
        public void Configure(EntityTypeBuilder<Response> builder)
        {
            builder.ToTable("Response",  "gen").HasKey(a => a.ResponseId);
            builder.Property(a => a.ResponseId).ValueGeneratedOnAdd();
            builder.HasOne(a => a.CreateBy).WithMany(a => a.CreateResponses).HasForeignKey(a => a.CreateById).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(a => a.Request).WithMany(a => a.Responses).HasForeignKey(a => a.RequestId).OnDelete(DeleteBehavior.Cascade);
        }

    }
}