using Newtonsoft.Json;

namespace quickhireup_api.Models.Request
{
    /// <summary>
    /// Reprezentuje żądanie wygenerowania opisu stanowiska pracy.
    /// Używane jako model wejściowy w żądaniach HTTP.
    /// </summary>
    public class JobDescriptionRequest
    {
        /// <summary>
        /// Lokalizacja stanowiska (np. "Kraków", "Zdalnie").
        /// </summary>
        [JsonProperty("location")]
        public string Location { get; set; }
        
        /// <summary>
        /// Nazwa stanowiska, dla którego ma zostać wygenerowany opis (np. "Backend Developer").
        /// </summary>
        [JsonProperty("jobTitle")]
        public string JobTitle { get; set; }

        /// <summary>
        /// Rodzaj zatrudnienia (np. "Zdalnie", "Stacjonarnie", "Hybrydowo").
        /// </summary>
        [JsonProperty("employmentType")]
        public string EmploymentType { get; set; }

        /// <summary>
        /// Rodzaj umowy (np. "Umowa o pracę").
        /// </summary>
        [JsonProperty("contractType")]
        public string ContractType { get; set; }

        /// <summary>
        /// Doświadczenie zawodowe (np. "Brak doświadczenia", "1-2 lata", "3+ lat").
        /// </summary>
        [JsonProperty("experience")]
        public string Experience { get; set; }
    }
}