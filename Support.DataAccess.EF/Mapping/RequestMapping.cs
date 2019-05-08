using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Support.Domain.Model;

namespace Support.DataAccess.EF.Mapping
{
    public class RequestMapping : IEntityTypeConfiguration<Request>
    {
        public RequestMapping(EntityTypeBuilder<Request> builder)
        {
            builder.ToTable("Request", schemaName: "gen").HasKey(a => a.RequestId).Property(a => a.RequestId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

           builder.HasRequired(a => a.RequestBy).WithMany(a => a.Requests).HasForeignKey(a => a.RequestById).WillCascadeOnDelete(false);
           builder.HasRequired(a => a.Status).WithMany().HasForeignKey(a => a.StatusId).WillCascadeOnDelete(false);
           builder.HasRequired(a => a.Priority).WithMany().HasForeignKey(a => a.PriorityId).WillCascadeOnDelete(false);
           builder.HasRequired(a => a.Type).WithMany().HasForeignKey(a => a.TypeId).WillCascadeOnDelete(false);
            builder.HasRequired(a => a.Assigned).WithMany(a => a.AssignResponses).HasForeignKey(a => a.AssignedId).WillCascadeOnDelete(false);

        }
    }
}