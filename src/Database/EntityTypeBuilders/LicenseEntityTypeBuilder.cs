using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata.Builders;

namespace LicenseManager.Database.EntityTypeBuilders
{
    public class LicenseEntityTypeBuilder
    {
        public LicenseEntityTypeBuilder(EntityTypeBuilder<Models.License> entityTypeBuilder)
        {
            entityTypeBuilder
                .ToTable("Licenses");
            entityTypeBuilder
                .Property(x => x.Deleted)
                .HasDefaultValue(false);
            entityTypeBuilder
                .Property(x => x.Description)
                .HasMaxLength(500);
        }
    }
}