namespace quickhireup_api.Models
{
    /// <summary>
    /// Reprezentuje szablon oferty pracy, który może być używany do tworzenia nowych ogłoszeń.
    /// </summary>
    public class JobTemplate
    {
        /// <summary>
        /// Unikalny identyfikator szablonu oferty pracy.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Tytuł stanowiska w szablonie oferty pracy.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Opis stanowiska zawarty w szablonie oferty pracy.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Lista umiejętności wymaganych w szablonie oferty pracy.
        /// </summary>
        public ICollection<Skill> Skills { get; set; }
    }
}