namespace quickhireup_api.Application.DTOs
{
    /// <summary>
    /// DTO reprezentujący żądanie zawierające token uwierzytelniający i token odświeżający.
    /// </summary>
    public class TokenRequestDto
    {
        /// <summary>
        /// Token dostępu do uwierzytelniania użytkownika.
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Token służący do odświeżenia tokena dostępu po jego wygaśnięciu.
        /// </summary>
        public string RefreshToken { get; set; }
    }
}