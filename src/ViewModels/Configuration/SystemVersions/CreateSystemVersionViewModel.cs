using System.ComponentModel.DataAnnotations;

namespace LicenseManager.ViewModels.Configuration.SystemVersions
{
    /// Model widoku dla akcji tworzenia nowej wersji systemu
    public class CreateSystemVersionViewModel
    {
        /// Numer główny
        [Display(Name = "Numer główny")]
        [Required(ErrorMessage = "To pole jest wymagane.")]
        [RegularExpression(@"^([0-9]|[1-9][0-9]|[1-9][0-9][0-9]|1000)$", ErrorMessage = "Wprowadź liczbę całkowitą z przedziału [0, 1000].")]
        public string Major { get; set; }

        /// Numer dodatkowy
        [Display(Name = "Numer dodatkowy")]
        [Required(ErrorMessage = "To pole jest wymagane.")]
        [RegularExpression(@"^([0-9]|[1-9][0-9]|[1-9][0-9][0-9]|1000)$", ErrorMessage = "Wprowadź liczbę całkowitą z przedziału [0, 1000].")]
        public string Minor { get; set; }

        /// Opis
        [Display(Name = "Opis")]
        [StringLength(500, ErrorMessage = "Wprowadź co najwyżej 500 znaków.")]
        public string Description { get; set; }

        /// Identyfikator systemu
        [Display(Name = "Identyfikator systemu")]
        [Required(ErrorMessage = "To pole jest wymagane.")]
        public string SystemId { get; set; }
    }
}