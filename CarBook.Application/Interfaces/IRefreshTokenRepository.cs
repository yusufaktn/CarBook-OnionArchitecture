using CarBook.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces
{
    /// <summary>
    /// Repository interface for RefreshToken entity
    /// </summary>
    public interface IRefreshTokenRepository : IRepository<RefreshToken>
    {
        /// <summary>
        /// Get active refresh token by token string
        /// </summary>
        Task<RefreshToken?> GetByTokenAsync(string token);

        /// <summary>
        /// Get all active refresh tokens for a user
        /// </summary>
        Task<List<RefreshToken>> GetActiveTokensByUserIdAsync(int userId);

        /// <summary>
        /// Revoke all refresh tokens for a user
        /// </summary>
        Task RevokeAllUserTokensAsync(int userId, string ipAddress);
    }
}
