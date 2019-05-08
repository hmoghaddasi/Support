using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Support.Domain.Model;

namespace Support.DataAccess.EF.Mapping
{
    public class ResponseMapping : IEntityTypeConfiguration<Response>
    {
        public ResponseMapping(EntityTypeBuilder<Response> builder)
        {
           builder.ToTable("Response", schemaName: "gen").HasKey(a => a.ResponseId).Property(a => a.ResponseId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
           builder.HasRequired(a => a.CreateBy).WithMany(a => a.CreateResponses).HasForeignKey(a => a.CreateById).WillCascadeOnDelete(false);
            builder.HasRequired(a => a.Request).WithMany(a => a.Responses).HasForeignKey(a => a.RequestId).WillCascadeOnDelete(false);
        }
    }
}