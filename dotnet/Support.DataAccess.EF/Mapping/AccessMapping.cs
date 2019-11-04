using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Support.Domain.Model;

namespace Support.DataAccess.EF.Mapping
{
    public class AccessMapping : EntityTypeConfiguration<Access>
    {
        public AccessMapping()
        {
            ToTable("Access", schemaName: "sec").HasKey(a => a.AccessId).Property(a => a.AccessId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

        }
    }
}
