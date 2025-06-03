namespace quickhireup_api.Models
{
    /// <summary>
    /// Reprezentuje użytkownika systemu.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Unikalny identyfikator użytkownika.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Adres e-mail użytkownika, wykorzystywany do logowania.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Zahasłowany ciąg znaków reprezentujący hasło użytkownika.
        /// </summary>
        public string PasswordHash { get; set; }

        /// <summary>
        /// Rola przypisana użytkownikowi (np. "Admin", "Recruiter", "Candidate").
        /// </summary>
        public string Role { get; set; }

        /// <summary>
        /// Lista CV przypisanych do użytkownika.
        /// </summary>
        public virtual ICollection<CV> CVs { get; set; }
    }
}