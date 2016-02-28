using System;
using System.Collections.Generic;

namespace LicenseManager.Models
{
    /// Klient
    public class Client : Entity<Guid>
    {
        /// Nazwa
        public string Name { get; set; }

        /// Opis
        public string Description { get; set; }

        /// Produkty
        public List<Product> Products { get; set; }
    }
}