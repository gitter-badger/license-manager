using System.ComponentModel.DataAnnotations;

namespace LicenseManager.ViewModels.Systems
{
    /// Model widoku dla akcji tworzenia nowego systemu
    public class CreateSystemViewModel
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