using System.Collections.Generic;

namespace LicenseManager.ViewModels
{
    /// Lista rozwijana "Systemy"
    public class SystemDropDownListViewModel
    {
        /// Elementy
        public IEnumerable<SystemDropDownListItemViewModel> Items { get; set; }
    }
}