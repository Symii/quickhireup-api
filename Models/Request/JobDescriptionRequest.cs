namespace quickhireup_api.Models.Request
{
    /// <summary>
    /// Reprezentuje żądanie wygenerowania opisu stanowiska pracy.
    /// Używane jako model wejściowy w żądaniach HTTP.
    /// </summary>
    public class JobDescriptionRequest
    {
        /// <summary>
        /// Nazwa stanowiska, dla którego ma zostać wygenerowany opis (np. "Backend Developer").
        /// </summary>
        public string Position { get; set; }

        /// <summary>
        /// Lokalizacja stanowiska (np. "Kraków", "Zdalnie").
        /// </summary>
        public string Location { get; set; }
    }
}