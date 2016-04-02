using System.Collections.Generic;

namespace LicenseManager.ViewModels.Configuration.SystemVersions
{
    /// Model widoku dla tabeli z wersjami systemów
    public class SystemVersionsTableViewModel
    {
        /// Wiersze
        public IEnumerable<SystemVersionsTableRowViewModel> Rows { get; set; }
    }
}