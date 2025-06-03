using System.Text.Json.Serialization;

namespace quickhireup_api.Models
{
    /// <summary>
    /// Reprezentuje powiązanie między ofertą pracy a umiejętnością.
    /// Jest to tabela pośrednia w relacji wiele-do-wielu między JobAd i Skill.
    /// </summary>
    public class JobAdSkill
    {
        /// <summary>
        /// Identyfikator oferty pracy powiązanej z umiejętnością.
        /// </summary>
        public int JobAdId { get; set; }

        /// <summary>
        /// Obiekt oferty pracy. Oznaczony jako ignorowany przy serializacji JSON.
        /// </summary>
        [JsonIgnore]
        public JobAd JobAd { get; set; }

        /// <summary>
        /// Identyfikator umiejętności powiązanej z ofertą pracy.
        /// </summary>
        public int SkillId { get; set; }

        /// <summary>
        /// Obiekt umiejętności. Oznaczony jako ignorowany przy serializacji JSON.
        /// </summary>
        [JsonIgnore]
        public Skill Skill { get; set; }
    }
}