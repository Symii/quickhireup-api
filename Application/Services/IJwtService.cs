using System.Security.Claims;
using quickhireup_api.Models;

namespace quickhireup_api.Application.Services
{
    /// <summary>
    /// Interfejs serwisu odpowiedzialnego za generowanie i obsługę tokenów JWT.
    /// </summary>
    public interface IJwtService
    {
        /// <summary>
        /// Generuje token JWT dla podanego użytkownika.
        /// </summary>
        /// <param name="user">Obiekt użytkownika, na podstawie którego generowany jest token.</param>
        /// <returns>Token JWT jako ciąg znaków.</returns>
        string GenerateToken(User user);

        /// <summary>
        /// Generuje token odświeżający (refresh token).
        /// </summary>
        /// <returns>Token odświeżający jako ciąg znaków.</returns>
        string GenerateRefreshToken();

        /// <summary>
        /// Pobiera ClaimsPrincipal na podstawie wygasłego tokena JWT.
        /// </summary>
        /// <param name="token">Wygasły token JWT.</param>
        /// <returns>ClaimsPrincipal z danymi użytkownika zawartymi w tokenie.</returns>
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}