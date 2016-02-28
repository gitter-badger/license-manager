using System;

namespace LicenseManager.Models
{
    /// Wersja systemu
    public class SystemVersion : Entity<Guid>
    {
        /// Numer główny
        public int Major { get; set; }

        /// Numer dodatkowy
        public int Minor { get; set; }

        /// Opis
        public string Description { get; set; }

        /// System
        public System System { get; set; }

        /// Identyfikator systemu
        public Guid SystemId { get; set; }
    }
}