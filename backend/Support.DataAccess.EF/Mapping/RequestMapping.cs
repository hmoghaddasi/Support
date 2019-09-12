using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Support.Domain.Model;

namespace Support.DataAccess.EF.Mapping
{
    public class RequestMapping : IEntityTypeConfiguration<Request>
    {
        public void Configure(EntityTypeBuilder<Request> builder)
        {
            builder.ToTable("Request", "gen").HasKey(a => a.RequestId);
            builder.Property(a => a.RequestId).ValueGeneratedOnAdd();

            builder.HasOne(a => a.RequestBy).WithMany(a => a.Requests).HasForeignKey(a => a.RequestById).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(a => a.Status).WithMany().HasForeignKey(a => a.StatusId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(a => a.Priority).WithMany().HasForeignKey(a => a.PriorityId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(a => a.Type).WithMany().HasForeignKey(a => a.TypeId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(a => a.Assigned).WithMany(a => a.AssignResponses).HasForeignKey(a => a.AssignedId).OnDelete(DeleteBehavior.Restrict);

        }
    }
}