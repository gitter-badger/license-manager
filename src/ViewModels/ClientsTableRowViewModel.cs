using System;

namespace LicenseManager.ViewModels
{
    /// Wiersz tabeli "Klienci"
    public class ClientsTableRowViewModel
    {
        /// Identyfikator
        public Guid Id { get; set; }

        /// Nazwa
        public string Name { get; set; }

        /// Opis
        public string Description { get; set; }
    }
}