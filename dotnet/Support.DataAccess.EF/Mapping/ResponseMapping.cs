using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Support.Domain.Model;

namespace Support.DataAccess.EF.Mapping
{
    public class ResponseMapping : EntityTypeConfiguration<Response>
    {
        public ResponseMapping()
        {
            ToTable("Response", schemaName: "gen").HasKey(a => a.ResponseId).Property(a => a.ResponseId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(h => h.CreateBy).WithMany(a=>a.CreateResponses).HasForeignKey(h => h.CreateById).WillCascadeOnDelete(false);
            HasRequired(h => h.Request).WithMany(a=>a.Responses).HasForeignKey(h => h.RequestId).WillCascadeOnDelete(false);

        }

    }
}