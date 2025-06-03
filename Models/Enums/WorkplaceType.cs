namespace quickhireup_api.Models.Enums
{
    /// <summary>
    /// Typ miejsca wykonywania pracy.
    /// </summary>
    public enum WorkplaceType
    {
        /// <summary>
        /// Praca w siedzibie firmy (stacjonarna).
        /// </summary>
        OnSite,

        /// <summary>
        /// Praca zdalna.
        /// </summary>
        Remote,

        /// <summary>
        /// Praca hybrydowa (częściowo zdalna, częściowo w biurze).
        /// </summary>
        Hybrid
    }
}