namespace quickhireup_api.Models
{
    /// <summary>
    /// Ustawienia konfiguracyjne dla generowania i weryfikacji tokenów JWT.
    /// </summary>
    public class JwtSettings
    {
        /// <summary>
        /// Sekretny klucz używany do podpisywania tokenów JWT.
        /// </summary>
        public string SecretKey { get; set; } = string.Empty;

        /// <summary>
        /// Czas ważności tokena JWT w minutach.
        /// </summary>
        public int ExpiryMinutes { get; set; } = 15;

        /// <summary>
        /// Nazwa wystawcy (issuer) tokena JWT.
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// Nazwa odbiorcy (audience) tokena JWT.
        /// </summary>
        public string Audience { get; set; }
    }
}