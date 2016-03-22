using System.Collections.Generic;

namespace LicenseManager.ViewModels
{
    /// Tabela "Klienci"
    public class ClientsTableViewModel
    {
        /// Wiersze
        public IEnumerable<ClientsTableRowViewModel> Rows { get; set; }
    }
}