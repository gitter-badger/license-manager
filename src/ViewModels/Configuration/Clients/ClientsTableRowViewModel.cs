using System;

namespace LicenseManager.ViewModels.Configuration.Clients
{
    /// Model widoku dla wiersza tabeli z klientami
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