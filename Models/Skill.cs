namespace quickhireup_api.Models
{
    /// <summary>
    /// Reprezentuje umiejętność, która może być przypisana do ofert pracy lub szablonów.
    /// </summary>
    public class Skill
    {
        /// <summary>
        /// Unikalny identyfikator umiejętności.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nazwa umiejętności (np. "C#", "Zarządzanie projektami").
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Lista szablonów ofert pracy, które zawierają tę umiejętność.
        /// </summary>
        public virtual ICollection<JobTemplate> Templates { get; set; }

        /// <summary>
        /// Lista powiązań między umiejętnościami a konkretnymi ofertami pracy.
        /// </summary>
        public List<JobAdSkill> JobAdSkills { get; set; }
    }
}