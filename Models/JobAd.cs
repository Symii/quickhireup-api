using System.Text.Json.Serialization;
using quickhireup_api.Models.Enums;

namespace quickhireup_api.Models
{
    /// <summary>
    /// Reprezentuje ogłoszenie o pracę opublikowane przez firmę.
    /// </summary>
    public class JobAd
    {
        /// <summary>
        /// Unikalny identyfikator ogłoszenia o pracę.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Tytuł oferty pracy (np. "Programista .NET").
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Szczegółowy opis stanowiska i obowiązków.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Data publikacji ogłoszenia. Domyślnie ustawiona na bieżącą datę.
        /// </summary>
        public DateTime PostedAt { get; set; } = DateTime.Now;

        /// <summary>
        /// Data wygaśnięcia ogłoszenia.
        /// </summary>
        public DateTime ExpirationDate { get; set; }

        /// <summary>
        /// Rodzaj zatrudnienia (np. Pełny etat, Umowa o dzieło).
        /// </summary>
        public EmploymentType EmploymentType { get; set; }

        /// <summary>
        /// Wymagany poziom doświadczenia (np. Junior, Mid, Senior).
        /// </summary>
        public ExperienceLevel ExperienceLevel { get; set; }

        /// <summary>
        /// Lokalizacja miejsca pracy (np. "Warszawa, Polska").
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Typ miejsca pracy (np. zdalna, hybrydowa, stacjonarna).
        /// </summary>
        public WorkplaceType WorkplaceType { get; set; }

        /// <summary>
        /// Wynagrodzenie oferowane na stanowisku (opcjonalne).
        /// </summary>
        public decimal? Salary { get; set; }

        /// <summary>
        /// Waluta wynagrodzenia (np. "PLN", "EUR").
        /// </summary>
        public string Currency { get; set; }

        /// <summary>
        /// Okres wynagrodzenia (np. miesięcznie, rocznie, godzinowo).
        /// </summary>
        public SalaryPeriod? SalaryPeriod { get; set; }

        /// <summary>
        /// Branża, w której działa firma oferująca stanowisko.
        /// </summary>
        public string Industry { get; set; }

        /// <summary>
        /// Dodatkowe benefity oferowane w ramach stanowiska.
        /// </summary>
        public string JobBenefits { get; set; }

        /// <summary>
        /// Instrukcje dotyczące aplikowania na ofertę.
        /// </summary>
        public string ApplicationInstructions { get; set; }

        /// <summary>
        /// Identyfikator firmy publikującej ogłoszenie.
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// Firma publikująca ofertę pracy. Ignorowana podczas serializacji JSON.
        /// </summary>
        [JsonIgnore]
        public virtual Company Company { get; set; }

        /// <summary>
        /// Lista powiązanych umiejętności wymaganych w ogłoszeniu.
        /// </summary>
        public List<JobAdSkill> JobAdSkills { get; set; }
    }
}
