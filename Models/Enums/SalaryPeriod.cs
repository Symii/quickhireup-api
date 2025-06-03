namespace quickhireup_api.Models.Enums
{
    /// <summary>
    /// Okres, za który wypłacane jest wynagrodzenie.
    /// </summary>
    public enum SalaryPeriod
    {
        /// <summary>
        /// Roczne wynagrodzenie.
        /// </summary>
        Yearly,

        /// <summary>
        /// Miesięczne wynagrodzenie.
        /// </summary>
        Monthly,

        /// <summary>
        /// Tygodniowe wynagrodzenie.
        /// </summary>
        Weekly,

        /// <summary>
        /// Dziennie wynagrodzenie.
        /// </summary>
        Daily,

        /// <summary>
        /// Godzinowe wynagrodzenie.
        /// </summary>
        Hourly
    }
}