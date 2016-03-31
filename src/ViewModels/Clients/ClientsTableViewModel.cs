using System.Collections.Generic;

namespace LicenseManager.ViewModels.Clients
{
    /// Model widoku dla tabeli z klientami
    public class ClientsTableViewModel
    {
        /// Wiersze
        public IEnumerable<ClientsTableRowViewModel> Rows { get; set; }
    }
}