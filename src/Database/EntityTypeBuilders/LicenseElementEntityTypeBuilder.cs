using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata.Builders;

namespace LicenseManager.Database.EntityTypeBuilders
{
    public class LicenseElementEntityTypeBuilder
    {
        public LicenseElementEntityTypeBuilder(EntityTypeBuilder<Models.LicenseElement> entityTypeBuilder)
        {
            entityTypeBuilder
                .ToTable("LicenseElements");
            entityTypeBuilder
                .Property(x => x.Deleted)
                .HasDefaultValue(false);
        }
    }
}