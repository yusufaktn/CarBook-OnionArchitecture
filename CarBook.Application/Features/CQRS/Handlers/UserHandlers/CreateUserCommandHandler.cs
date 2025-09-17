using CarBook.Application.Features.CQRS.Command.UserCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.UserHandlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(CreateUserCommand createUserCommand, CancellationToken cancellationToken)
        {
            createUserCommand.PasswordHash = HashPassword(createUserCommand.PasswordHash);
            await _userRepository.AddAsync(new User
            {
                UserName = createUserCommand.UserName,
                UserLastName = createUserCommand.UserLastName,
                Email = createUserCommand.Email,
                PasswordHash = createUserCommand.PasswordHash,
                ProfileImageUrl = createUserCommand.ProfileImageUrl
            });
        }

        private string HashPassword(string password)
        {
            
            using (var sha256 = SHA256.Create())
            {
                var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }

    }
}