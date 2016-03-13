using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata.Builders;

namespace LicenseManager.Database.EntityTypeBuilders
{
    public class LicenseTemplateEntityTypeBuilder
    {
        public LicenseTemplateEntityTypeBuilder(EntityTypeBuilder<Models.LicenseTemplate> entityTypeBuilder)
        {
            entityTypeBuilder
                .ToTable("LicenseTemplates");
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