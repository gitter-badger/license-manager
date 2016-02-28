using System.Linq;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;

namespace LicenseManager.Models
{
    /// Kontekst bazy danych
    public sealed class DatabaseContext : DbContext
    {
        /// Klienci
        public DbSet<Client> Clients { get; set; }

        /// Licencje
        public DbSet<License> Licenses { get; set; }

        /// Szablony licencji
        public DbSet<LicenseTemplate> LicenseTemplates { get; set; }

        /// Elementy szablonu licencji
        public DbSet<LicenseTemplateElement> LicenseTemplateElements { get; set; }

        /// Produkty
        public DbSet<Product> Products { get; set; }

        /// Systemy
        public DbSet<System> Systems { get; set; }

        /// Wersje systemu
        public DbSet<SystemVersion> SystemVersions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (IMutableForeignKey mutableForeignKey in modelBuilder.Model.GetEntityTypes().SelectMany(x => x.GetForeignKeys()))
            {
                mutableForeignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<Client>()
                .ToTable("Clients");
            modelBuilder.Entity<Client>().Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Client>().Property(x => x.Description)
                .HasMaxLength(500);

            modelBuilder.Entity<License>()
                .ToTable("Licenses");
            modelBuilder.Entity<License>().Property(x => x.Description)
                .HasMaxLength(500);
            
            modelBuilder.Entity<LicenseElement>()
                .ToTable("LicenseElements");
            
            modelBuilder.Entity<LicenseTemplate>()
                .ToTable("LicenseTemplates");
            modelBuilder.Entity<LicenseTemplate>().Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<LicenseTemplate>().Property(x => x.Description)
                .HasMaxLength(500);

            modelBuilder.Entity<LicenseTemplateElement>()
                .ToTable("LicenseTemplateElements");
            modelBuilder.Entity<LicenseTemplateElement>().Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<LicenseTemplateElement>().Property(x => x.Mnemonic)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<LicenseTemplateElement>().Property(x => x.Description)
                .HasMaxLength(500);

            modelBuilder.Entity<Product>()
                .ToTable("Products");

            modelBuilder.Entity<System>()
                .ToTable("Systems");
            modelBuilder.Entity<System>().Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<System>().Property(x => x.Description)
                .HasMaxLength(500);

            modelBuilder.Entity<SystemVersion>()
                .ToTable("SystemVersions");
            modelBuilder.Entity<SystemVersion>().Property(x => x.Description)
                .HasMaxLength(500);
        }
    }
}