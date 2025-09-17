using CarBook.Application.Features.CQRS.Command.UserCommand;
using CarBook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.UserHandlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(UpdateUserCommand updateUserCommand, CancellationToken cancellationToken)
        {
            var value = await _userRepository.GetByIdAsync(updateUserCommand.UserId);
            value.UserName = updateUserCommand.UserName;
            value.UserLastName = updateUserCommand.UserLastName;
            value.Email = updateUserCommand.Email;
            value.PasswordHash = updateUserCommand.PasswordHash;
            value.ProfileImageUrl = updateUserCommand.ProfileImageUrl;
            await _userRepository.UpdateAsync(value);
        }
    }
}