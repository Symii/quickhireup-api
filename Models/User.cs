using Microsoft.AspNetCore.Identity;

namespace quickhireup_api.Models
{
    /// <summary>
    /// Reprezentuje użytkownika systemu.
    /// </summary>
    public class User : IdentityUser
    {
        /// <summary>
        /// Rola przypisana użytkownikowi (np. "Admin", "Recruiter", "Candidate").
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Lista CV przypisanych do użytkownika.
        /// </summary>
        public virtual ICollection<CV> CVs { get; set; }

        /// <summary>
        /// Imię użytkownika.
        /// </summary>
        public string FirstName { get; set; }
        
        /// <summary>
        /// Nazwisko użytkownika.
        /// </summary>
        public string SecondName { get; set; }
        
        /// <summary>
        /// Token odświeżający używany do przedłużenia sesji użytkownika.
        /// </summary>
        public string? RefreshToken { get; set; }

        /// <summary>
        /// Data i godzina wygaśnięcia tokena odświeżającego.
        /// </summary>
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}