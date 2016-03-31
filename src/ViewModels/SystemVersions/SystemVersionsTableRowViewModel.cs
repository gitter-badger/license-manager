using System;

namespace LicenseManager.ViewModels.SystemVersions
{
    /// Model widoku dla wiersza tabeli z wersjami systemów
    public class SystemVersionsTableRowViewModel
    {
        /// Identyfikator
        public Guid Id { get; set; }

        /// Numer główny
        public int Major { get; set; }

        /// Numer dodatkowy
        public int Minor { get; set; }

        /// Opis
        public string Description { get; set; }

        /// Nazwa systemu
        public string SystemName { get; set; }
    }
}