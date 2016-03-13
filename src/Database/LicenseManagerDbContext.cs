using System.Linq;
using LicenseManager.Database.EntityTypeBuilders;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;

namespace LicenseManager.Database
{
    /// Kontekst bazy danych
    public sealed class LicenseManagerDbContext : DbContext
    {
        /// Klienci
        public DbSet<Models.Client> Clients { get; set; }

        /// Licencje
        public DbSet<Models.License> Licenses { get; set; }

        /// Szablony licencji
        public DbSet<Models.LicenseTemplate> LicenseTemplates { get; set; }

        /// Elementy szablonu licencji
        public DbSet<Models.LicenseTemplateElement> LicenseTemplateElements { get; set; }

        /// Produkty
        public DbSet<Models.Product> Products { get; set; }

        /// Systemy
        public DbSet<Models.System> Systems { get; set; }

        /// Wersje systemu
        public DbSet<Models.SystemVersion> SystemVersions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (IMutableForeignKey mutableForeignKey in modelBuilder.Model.GetEntityTypes().SelectMany(x => x.GetForeignKeys()))
            {
                mutableForeignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }

            new ClientEntityTypeBuilder(modelBuilder.Entity<Models.Client>());
            new LicenseEntityTypeBuilder(modelBuilder.Entity<Models.License>());
            new LicenseElementEntityTypeBuilder(modelBuilder.Entity<Models.LicenseElement>());
            new LicenseTemplateEntityTypeBuilder(modelBuilder.Entity<Models.LicenseTemplate>());
            new LicenseTemplateElementEntityTypeBuilder(modelBuilder.Entity<Models.LicenseTemplateElement>());
            new ProductEntityTypeBuilder(modelBuilder.Entity<Models.Product>());
            new SystemEntityTypeBuilder(modelBuilder.Entity<Models.System>());
            new SystemVersionEntityTypeBuilder(modelBuilder.Entity<Models.SystemVersion>());
        }
    }
}