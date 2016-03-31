using System.Collections.Generic;

namespace LicenseManager.ViewModels.Systems
{
    /// Model widoku dla tabeli z systemami
    public class SystemsTableViewModel
    {
        /// Wiersze
        public IEnumerable<SystemsTableRowViewModel> Rows { get; set; }
    }
}