using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata.Builders;

namespace LicenseManager.Database.EntityTypeBuilders
{
    public class LicenseTemplateElementEntityTypeBuilder
    {
        public LicenseTemplateElementEntityTypeBuilder(EntityTypeBuilder<Models.LicenseTemplateElement> entityTypeBuilder)
        {
            entityTypeBuilder
                .ToTable("LicenseTemplateElements");
            entityTypeBuilder
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);
            entityTypeBuilder
                .Property(x => x.Mnemonic)
                .IsRequired()
                .HasMaxLength(100);
            entityTypeBuilder
                .Property(x => x.Description)
                .HasMaxLength(500);
        }
    }
}