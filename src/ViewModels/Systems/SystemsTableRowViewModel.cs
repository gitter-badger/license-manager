using System;

namespace LicenseManager.ViewModels.Systems
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