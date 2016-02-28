using System;
using System.Collections.Generic;

namespace LicenseManager.Models
{
    /// Produkt
    public class Product : Entity<Guid>
    {
        /// Klient
        public Client Client { get; set; }
        
        /// Identyfikator klienta
        public Guid ClientId { get; set; }

        /// Wersja systemu
        public SystemVersion SystemVersion { get; set; }

        /// Identyfikator wersji systemu
        public Guid SystemVersionId { get; set; }

        /// Licencje
        public List<License> Licenses { get; set; }
    }
}