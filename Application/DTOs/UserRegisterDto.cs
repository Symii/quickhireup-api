using System.ComponentModel.DataAnnotations;

namespace quickhireup_api.Application.DTOs
{
    /// <summary>
    /// DTO służący do rejestracji nowego użytkownika.
    /// </summary>
    public class UserRegisterDto
    {
        /// <summary>
        /// Nazwa użytkownika. Pole wymagane.
        /// </summary>
        [Required]
        public string UserName { get; set; }

        /// <summary>
        /// Adres e-mail użytkownika. Pole wymagane i musi być poprawnym adresem e-mail.
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Hasło użytkownika. Pole wymagane, minimalna długość to 6 znaków.
        /// </summary>
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}