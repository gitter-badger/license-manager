using System.Collections.Generic;

namespace LicenseManager.ViewModels.Configuration.Clients
{
    /// Model widoku dla tabeli z klientami
    public class ClientsTableViewModel
    {
        /// Wiersze
        public List<ClientsTableRowViewModel> Rows { get; set; }
    }
}