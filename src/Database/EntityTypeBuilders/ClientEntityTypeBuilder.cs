using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata.Builders;

namespace LicenseManager.Database.EntityTypeBuilders
{
    public class ClientEntityTypeBuilder
    {
        public ClientEntityTypeBuilder(EntityTypeBuilder<Models.Client> entityTypeBuilder)
        {
            entityTypeBuilder
                .ToTable("Clients");
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