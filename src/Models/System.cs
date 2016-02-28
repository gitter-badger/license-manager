using System;
using System.Collections.Generic;

namespace LicenseManager.Models
{
    /// System
    public class System : Entity<Guid>
    {
        /// Nazwa
        public string Name { get; set; }

        /// Opis
        public string Description { get; set; }
        
        /// Wersje systemu
        public List<SystemVersion> SystemVersions { get; set; }
    }
}