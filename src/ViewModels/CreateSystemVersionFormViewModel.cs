namespace LicenseManager.ViewModels
{
    /// Dane z formularza "Stwórz nową wersję systemu"
    public class CreateSystemVersionFormViewModel
    {
        /// Numer główny
        public int Major { get; set; }

        /// Numer dodatkowy
        public int Minor { get; set; }

        /// Opis
        public string Description { get; set; }

        /// Identyfikator systemu
        public string SystemId { get; set; }
    }
}