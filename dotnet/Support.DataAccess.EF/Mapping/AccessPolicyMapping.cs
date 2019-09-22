using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Support.Domain.Model;

namespace Support.DataAccess.EF.Mapping
{
    public class AccessPolicyMapping : EntityTypeConfiguration<AccessPolicy>
    {
        public AccessPolicyMapping()
        {
            ToTable("AccessPolicy", schemaName: "sec").HasKey(a => a.AccessPolicyId).Property(a => a.AccessPolicyId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(a => a.Access).WithMany(a => a.AccessPolicies).HasForeignKey(a => a.AccessId).WillCascadeOnDelete(false);
            HasRequired(a => a.Person).WithMany(a => a.AccessPolicies).HasForeignKey(a => a.PersonId).WillCascadeOnDelete(false);
        }
    }
}
