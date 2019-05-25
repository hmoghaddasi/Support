using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Support.Domain.Model;

namespace Support.DataAccess.EF.Mapping
{
    public class AccessPolicyMapping : IEntityTypeConfiguration<AccessPolicy>
    {
        public void Configure(EntityTypeBuilder<AccessPolicy> builder)
        {
            builder.ToTable("AccessPolicy", "sec").HasKey(a => a.AccessPolicyId);
            builder.Property(a => a.AccessPolicyId).ValueGeneratedOnAdd();

            builder.HasOne(a => a.Access).WithMany(a => a.AccessPolicies)
                .HasForeignKey(a => a.AccessId).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(a => a.Person).WithMany(a => a.AccessPolicies)
                .HasForeignKey(a => a.PersonId).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
