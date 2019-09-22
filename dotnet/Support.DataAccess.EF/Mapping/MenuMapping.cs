using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Support.Domain.Model;

namespace Support.DataAccess.EF.Mapping
{
    public class MenuMapping : EntityTypeConfiguration<Menu>
    {
        public MenuMapping()
        {
            ToTable("Menu", schemaName: "gen").HasKey(a => a.MenuId).Property(a => a.MenuId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(h => h.MenuHdr).WithMany(w => w.Menus).HasForeignKey(h => h.MenuHdrId);
        }
    }
}
