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
    /// Handler for login command
    /// </summary>
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginCommandResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenService _tokenService;
        private readonly IRefreshTokenRepository _refreshTokenRepository;

        public LoginCommandHandler(
            IUserRepository userRepository,
            IPasswordHasher passwordHasher,
            ITokenService tokenService,
            IRefreshTokenRepository refreshTokenRepository)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
            _refreshTokenRepository = refreshTokenRepository;
        }

        public async Task<LoginCommandResult> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Find user by email
                var users = await _userRepository.GetAllAsync();
                var user = users.FirstOrDefault(u => u.Email.ToLower() == request.Email.ToLower());

                if (user == null)
                {
                    return new LoginCommandResult
                    {
                        Success = false,
                        Message = "Email veya şifre hatalı"
                    };
                }

                // Verify password
                if (!_passwordHasher.VerifyPassword(request.Password, user.PasswordHash))
                {
                    return new LoginCommandResult
                    {
                        Success = false,
                        Message = "Email veya şifre hatalı"
                    };
                }

                // Generate tokens
                var accessToken = _tokenService.GenerateAccessToken(user);
                var refreshToken = _tokenService.GenerateRefreshToken(user.UserId, request.IpAddress ?? "unknown");

                // Save refresh token to database
                await _refreshTokenRepository.AddAsync(refreshToken);

                return new LoginCommandResult
                {
                    Success = true,
                    Message = "Giriş başarılı",
                    AccessToken = accessToken,
                    RefreshToken = refreshToken.Token,
                    ExpiryDate = refreshToken.ExpiryDate,
                    UserId = user.UserId,
                    Email = user.Email,
                    UserName = user.UserName,
                    UserLastName = user.UserLastName
                };
            }
            catch (Exception ex)
            {
                return new LoginCommandResult
                {
                    Success = false,
                    Message = $"Giriş sırasında bir hata oluştu: {ex.Message}"
                };
            }
        }
    }
}
