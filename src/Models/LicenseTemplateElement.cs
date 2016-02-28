using System;

namespace LicenseManager.Models
{
    /// Element szablonu licencji
    public class LicenseTemplateElement : Entity<Guid>
    {
        /// Nazwa
        public string Name { get; set; }

        /// Mnemonik
        public string Mnemonic { get; set; }

        /// Opis
        public string Description { get; set; }

        /// Poziom
        public int Level { get; set; }

        /// Szablon licencji
        public LicenseTemplate LicenseTemplate { get; set; }

        /// Identyfikator szablonu licencji
        public Guid LicenseTemplateId { get; set; }

        /// Element nadrzędny
        public LicenseTemplateElement Parent { get; set; }

        /// Identyfikator elementu nadrzędnego
        public Guid? ParentId { get; set; }
    }
}