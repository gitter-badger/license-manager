using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata.Builders;

namespace LicenseManager.Database.EntityTypeBuilders
{
    public class ProductEntityTypeBuilder
    {
        public ProductEntityTypeBuilder(EntityTypeBuilder<Models.Product> entityTypeBuilder)
        {
            entityTypeBuilder
                .ToTable("Products");
        }
    }
}