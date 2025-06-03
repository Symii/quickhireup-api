namespace quickhireup_api.Application.DTOs
{
    /// <summary>
    /// Data Transfer Object (DTO) reprezentujący ogłoszenie o pracę.
    /// </summary>
    public class JobAdDto
    {
        /// <summary>
        /// Unikalny identyfikator ogłoszenia o pracę.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Tytuł oferty pracy.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Opis stanowiska i zakres obowiązków.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Data wygaśnięcia ogłoszenia.
        /// </summary>
        public DateTime ExpirationDate { get; set; }

        /// <summary>
        /// Identyfikator firmy publikującej ogłoszenie.
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// Lista identyfikatorów umiejętności wymaganych na stanowisku.
        /// </summary>
        public List<int> SkillIds { get; set; }
    }
}