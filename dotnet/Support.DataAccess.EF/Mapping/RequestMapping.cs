using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Support.Domain.Model;

namespace Support.DataAccess.EF.Mapping
{
    public class RequestMapping : EntityTypeConfiguration<Request>
    {
        public RequestMapping()
        {
            ToTable("Request", schemaName: "gen").HasKey(a => a.RequestId).Property(a => a.RequestId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(h => h.Status).WithMany().HasForeignKey(h => h.StatusId).WillCascadeOnDelete(false);
            HasRequired(h => h.RequestBy).WithMany(a=>a.Requests).HasForeignKey(h => h.RequestById).WillCascadeOnDelete(false);
            HasRequired(h => h.Priority).WithMany().HasForeignKey(h => h.PriorityId).WillCascadeOnDelete(false);
            HasRequired(h => h.Type).WithMany().HasForeignKey(h => h.TypeId).WillCascadeOnDelete(false);
            HasRequired(h => h.Assigned).WithMany(a=>a.AssignResponses).HasForeignKey(h => h.Assigned).WillCascadeOnDelete(false);

        }
    }
}