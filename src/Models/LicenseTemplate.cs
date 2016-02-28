using System;
using System.Collections.Generic;

namespace LicenseManager.Models
{
    /// Szablon licencji
    public class LicenseTemplate : Entity<Guid>
    {
        /// Nazwa
        public string Name { get; set; }

        /// Opis
        public string Description { get; set; }

        /// Wersja systemu
        public SystemVersion SystemVersion { get; set; }

        /// Identyfikator wersji systemu
        public Guid SystemVersionId { get; set; }

        /// Elementy szablonu licencji
        public List<LicenseTemplateElement> LicenseTemplateElements { get; set; }
    }
}