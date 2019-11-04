using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Support.Domain.Model;

namespace Support.DataAccess.EF.Mapping
{
    public class ConfigMapping : EntityTypeConfiguration<Config>
    {
        public ConfigMapping()
        {
            ToTable("Config", schemaName: "gen").HasKey(a => a.ConfigId).Property(a => a.ConfigId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            
            HasRequired(a => a.ConfigHdr).WithMany().HasForeignKey(a => a.ConfigHdrId).WillCascadeOnDelete(false);
        }
    }
}
