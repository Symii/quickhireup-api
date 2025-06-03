namespace quickhireup_api.Models.Enums
{
    /// <summary>
    /// Typ zatrudnienia oferowanego na stanowisku pracy.
    /// </summary>
    public enum EmploymentType
    {
        /// <summary>
        /// Pełny etat.
        /// </summary>
        FullTime,

        /// <summary>
        /// Część etatu.
        /// </summary>
        PartTime,

        /// <summary>
        /// Umowa zlecenie lub kontrakt.
        /// </summary>
        Contract,

        /// <summary>
        /// Zatrudnienie tymczasowe.
        /// </summary>
        Temporary,

        /// <summary>
        /// Staż lub praktyka.
        /// </summary>
        Intern,

        /// <summary>
        /// Wolontariat.
        /// </summary>
        Volunteer
    }
}