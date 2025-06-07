using System.ComponentModel.DataAnnotations;

namespace quickhireup_api.Application.DTOs
{
    /// <summary>
    /// DTO służący do przesyłania danych logowania użytkownika.
    /// </summary>
    public class UserLoginDto
    {
        /// <summary>
        /// Email użytkownika. Pole wymagane i musi mieć poprawny format adresu e-mail.
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        /// <summary>
        /// Hasło użytkownika. Pole wymagane.
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}