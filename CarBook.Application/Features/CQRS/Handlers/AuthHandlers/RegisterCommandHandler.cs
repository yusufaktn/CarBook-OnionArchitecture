using CarBook.Application.Features.CQRS.Command.AuthCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.AuthHandlers
{
    /// <summary>
    /// Handler for user registration
    /// </summary>
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterCommandResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public RegisterCommandHandler(
            IUserRepository userRepository,
            IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<RegisterCommandResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                // Check if email already exists
                var users = await _userRepository.GetAllAsync();
                var existingUser = users.FirstOrDefault(u => u.Email.ToLower() == request.Email.ToLower());

                if (existingUser != null)
                {
                    return new RegisterCommandResult
                    {
                        Success = false,
                        Message = "Bu email adresi zaten kullanılıyor"
                    };
                }

                // Hash password
                var passwordHash = _passwordHasher.HashPassword(request.Password);

                // Create user
                var user = new User
                {
                    UserName = request.UserName,
                    UserLastName = request.UserLastName,
                    Email = request.Email,
                    PasswordHash = passwordHash,
                    ProfileImageUrl = null
                };

                await _userRepository.AddAsync(user);

                return new RegisterCommandResult
                {
                    Success = true,
                    Message = "Kayıt başarılı",
                    UserId = user.UserId
                };
            }
            catch (Exception ex)
            {
                return new RegisterCommandResult
                {
                    Success = false,
                    Message = $"Kayıt sırasında hata oluştu: {ex.Message}"
                };
            }
        }
    }
}
