using System;

namespace LicenseManager.Models
{
    /// Klient
    public abstract class Entity<T>
    {
        /// Identyfikator
        public T Id { get; set; }

        /// Data utworzenia
        public DateTime CreationDate { get; set; }

        /// Data ostatniej modyfikacji
        public DateTime? LastModificationDate { get; set; }
    }
}