using System.Collections.Generic;

namespace LicenseManager.ViewModels.Configuration.Systems
{
    /// Model widoku dla tabeli z systemami
    public class SystemsTableViewModel
    {
        /// Wiersze
        public IEnumerable<SystemsTableRowViewModel> Rows { get; set; }
    }
}