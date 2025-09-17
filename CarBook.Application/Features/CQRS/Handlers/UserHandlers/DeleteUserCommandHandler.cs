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
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(DeleteUserCommand deleteUserCommand, CancellationToken cancellationToken)
        {
            var value = await _userRepository.GetByIdAsync(deleteUserCommand.UserId);
            await _userRepository.DeleteAsync(value);
        }
    }
}