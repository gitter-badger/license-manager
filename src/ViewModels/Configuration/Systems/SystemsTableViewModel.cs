using System.Collections.Generic;

namespace LicenseManager.ViewModels.Configuration.Systems
{
    /// Model widoku dla tabeli z systemami
    public class SystemsTableViewModel
    {
        /// Wiersze
        public List<SystemsTableRowViewModel> Rows { get; set; }
    }
}