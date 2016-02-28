using System;

namespace LicenseManager.Models
{
    /// Element licencji
    public class LicenseElement : Entity<Guid>
    {
        /// Czy jest aktywny?
        public bool Active { get; set; }
        
        /// Element szablonu licencji
        public LicenseTemplateElement LicenseTemplateElement { get; set; }
        
        /// Identyfikator elementu szablonu licencji
        public Guid LicenseTemplateElementId { get; set; }
        
        /// Element nadrzędny
        public LicenseElement Parent { get; set; }

        /// Identyfikator elementu nadrzędnego
        public Guid? ParentId { get; set; }
    }
}