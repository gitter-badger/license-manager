using System.Collections.Generic;

namespace LicenseManager.ViewModels.Configuration.SystemVersions
{
    /// Model widoku dla tabeli z wersjami systemów
    public class SystemVersionsTableViewModel
    {
        /// Wiersze
        public List<SystemVersionsTableRowViewModel> Rows { get; set; }
    }
}