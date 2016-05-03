using System.ComponentModel.DataAnnotations;

namespace LicenseManager.ViewModels.Configuration.Systems
{
    /// Model widoku dla akcji modyfikacji istniejącego systemu
    public class ModifySystemViewModel
    {
        /// Nazwa
        [Display(Name = "Nazwa")]
        [Required(ErrorMessage = "To pole jest wymagane.")]
        [StringLength(100, ErrorMessage = "Wprowadź co najwyżej 100 znaków.")]
        public string Name { get; set; }

        /// Opis
        [Display(Name = "Opis")]
        [StringLength(500, ErrorMessage = "Wprowadź co najwyżej 500 znaków.")]
        public string Description { get; set; }
    }
}