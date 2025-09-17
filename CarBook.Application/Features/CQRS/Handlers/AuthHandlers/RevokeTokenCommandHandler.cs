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
    /// Handler for revoke token command (logout)
    /// </summary>
    public class RevokeTokenCommandHandler : IRequestHandler<RevokeTokenCommand, RevokeTokenCommandResult>
    {
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public RevokeTokenCommandHandler(IRefreshTokenRepository refreshTokenRepository)
        {
            _refreshTokenRepository = refreshTokenRepository;
        }

        public async Task<RevokeTokenCommandResult> Handle(RevokeTokenCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Find refresh token
                var refreshToken = await _refreshTokenRepository.GetByTokenAsync(request.RefreshToken);

                if (refreshToken == null)
                {
                    return new RevokeTokenCommandResult
                    {
                        Success = false,
                        Message = "Token bulunamadı"
                    };
                }

                if (!refreshToken.IsActive)
                {
                    return new RevokeTokenCommandResult
                    {
                        Success = false,
                        Message = "Token zaten iptal edilmiş veya süresi dolmuş"
                    };
                }

                // Revoke token
                refreshToken.IsRevoked = true;
                refreshToken.RevokedDate = DateTime.UtcNow;
                refreshToken.RevokedByIp = request.IpAddress ?? "unknown";
                await _refreshTokenRepository.UpdateAsync(refreshToken);

                return new RevokeTokenCommandResult
                {
                    Success = true,
                    Message = "Çıkış başarılı"
                };
            }
            catch (Exception ex)
            {
                return new RevokeTokenCommandResult
                {
                    Success = false,
                    Message = $"Çıkış sırasında hata oluştu: {ex.Message}"
                };
            }
        }
    }
}
