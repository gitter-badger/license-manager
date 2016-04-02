using System;

namespace LicenseManager.ViewModels.Configuration.Systems
{
    /// Model widoku dla wiersza tabeli z systemami
    public class SystemsTableRowViewModel
    {
        /// Identyfikator
        public Guid Id { get; set; }

        /// Nazwa
        public string Name { get; set; }

        /// Opis
        public string Description { get; set; }
    }
}