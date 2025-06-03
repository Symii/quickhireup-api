namespace quickhireup_api.Models
{
    /// <summary>
    /// Reprezentuje firmę publikującą oferty pracy w systemie.
    /// </summary>
    public class Company
    {
        /// <summary>
        /// Unikalny identyfikator firmy.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nazwa firmy.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Opis działalności firmy.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Oficjalna strona internetowa firmy.
        /// </summary>
        public string Website { get; set; }

        /// <summary>
        /// Lista ofert pracy opublikowanych przez firmę.
        /// </summary>
        public virtual ICollection<JobAd> JobAds { get; set; }
    }
}