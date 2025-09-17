using CarBook.Application.Features.CQRS.Command.AuthCommand;
using CarBook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.AuthHandlers
{
    /// <summary>
    /// Handler for refresh token command
    /// </summary>
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, RefreshTokenCommandResult>
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public RefreshTokenCommandHandler(
            IRefreshTokenRepository refreshTokenRepository,
            IUserRepository userRepository,
            ITokenService tokenService)
        {
            _refreshTokenRepository = refreshTokenRepository;
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        public async Task<RefreshTokenCommandResult> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Find refresh token
                var refreshToken = await _refreshTokenRepository.GetByTokenAsync(request.RefreshToken);

                if (refreshToken == null || !refreshToken.IsActive)
                {
                    return new RefreshTokenCommandResult
                    {
                        Success = false,
                        Message = "Geçersiz veya süresi dolmuş token"
                    };
                }

                // Get user
                var user = await _userRepository.GetByIdAsync(refreshToken.UserId);
                if (user == null)
                {
                    return new RefreshTokenCommandResult
                    {
                        Success = false,
                        Message = "Kullanıcı bulunamadı"
                    };
                }

                // Generate new tokens
                var newAccessToken = _tokenService.GenerateAccessToken(user);
                var newRefreshToken = _tokenService.GenerateRefreshToken(user.UserId, request.IpAddress ?? "unknown");

                // Revoke old refresh token
                refreshToken.IsRevoked = true;
                refreshToken.RevokedDate = DateTime.UtcNow;
                refreshToken.RevokedByIp = request.IpAddress ?? "unknown";
                await _refreshTokenRepository.UpdateAsync(refreshToken);

                // Save new refresh token
                await _refreshTokenRepository.AddAsync(newRefreshToken);

                return new RefreshTokenCommandResult
                {
                    Success = true,
                    Message = "Token yenilendi",
                    AccessToken = newAccessToken,
                    RefreshToken = newRefreshToken.Token,
                    ExpiryDate = newRefreshToken.ExpiryDate
                };
            }
            catch (Exception ex)
            {
                return new RefreshTokenCommandResult
                {
                    Success = false,
                    Message = $"Token yenilenirken hata oluştu: {ex.Message}"
                };
            }
        }
    }
}
