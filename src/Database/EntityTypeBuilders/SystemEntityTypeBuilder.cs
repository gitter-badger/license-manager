using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata.Builders;

namespace LicenseManager.Database.EntityTypeBuilders
{
    public class SystemEntityTypeBuilder
    {
        public SystemEntityTypeBuilder(EntityTypeBuilder<Models.System> entityTypeBuilder)
        {
            entityTypeBuilder
                .ToTable("Systems");
            entityTypeBuilder
                .Property(x => x.Deleted)
                .HasDefaultValue(false);
            entityTypeBuilder
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);
            entityTypeBuilder
                .Property(x => x.Description)
                .HasMaxLength(500);
        }
    }
}