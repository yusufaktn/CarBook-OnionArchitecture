using CarBook.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces
{
    /// <summary>
    /// Interface for JWT token operations
    /// </summary>
    public interface ITokenService
    {
        /// <summary>
        /// Generate JWT access token for user
        /// </summary>
        string GenerateAccessToken(User user);

        /// <summary>
        /// Generate refresh token
        /// </summary>
        RefreshToken GenerateRefreshToken(int userId, string ipAddress);

        /// <summary>
        /// Validate JWT token and extract claims
        /// </summary>
        ClaimsPrincipal? ValidateToken(string token);

        /// <summary>
        /// Get user id from token
        /// </summary>
        int? GetUserIdFromToken(string token);
    }
}
