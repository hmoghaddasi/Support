using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Support.Domain.Model;

namespace Support.DataAccess.EF.Mapping
{
    public class AccessPolicyMapping : IEntityTypeConfiguration<AccessPolicy>
    {
        public AccessPolicyMapping(EntityTypeBuilder<AccessPolicy> builder)
        {
            builder.ToTable("AccessPolicy", schemaName: "sec").HasKey(a => a.AccessPolicyId).Property(a => a.AccessPolicyId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);


           builder.HasRequired(a => a.Access).WithMany(a => a.AccessPolicies).HasForeignKey(a => a.AccessId).WillCascadeOnDelete(false);
            builder.HasRequired(a => a.Person).WithMany(a => a.AccessPolicies).HasForeignKey(a => a.PersonId).WillCascadeOnDelete(false);
            

        }
    }
}
