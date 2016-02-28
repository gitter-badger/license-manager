using System;
using System.Collections.Generic;

namespace LicenseManager.Models
{
    /// Licencja
    public class License : Entity<Guid>
    {
        /// Numer
        public int Number { get; set; }

        /// Opis
        public string Description { get; set; }

        /// Ważna "od"
        public DateTime ValidFrom { get; set; }

        /// Ważna "do"
        public DateTime? ValidTo { get; set; }

        /// Produkt
        public Product Product { get; set; }

        /// Identyfikator produktu
        public Guid ProductId { get; set; }
        
        /// Szablon licencji
        public LicenseTemplate LicenseTemplate { get; set; }
        
        /// Identyfikator szablonu licencji
        public Guid LicenseTemplateId { get; set; }
        
        /// Elementy licencji
        public List<LicenseElement> LicenseElements { get; set; }
    }
}