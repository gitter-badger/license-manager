using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata.Builders;

namespace LicenseManager.Database.EntityTypeBuilders
{
    public class SystemVersionEntityTypeBuilder
    {
        public SystemVersionEntityTypeBuilder(EntityTypeBuilder<Models.SystemVersion> entityTypeBuilder)
        {
            entityTypeBuilder
                .ToTable("SystemVersions");
            entityTypeBuilder
                .Property(x => x.Description)
                .HasMaxLength(500);
        }
    }
}