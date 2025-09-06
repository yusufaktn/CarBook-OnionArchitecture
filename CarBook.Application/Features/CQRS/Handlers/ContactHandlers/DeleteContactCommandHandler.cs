using CarBook.Application.Features.CQRS.Command.ContactCommand;
using CarBook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand>
    {
        private readonly IContactRepository _contactRepository;

        public DeleteContactCommandHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task Handle(DeleteContactCommand deleteContactCommand, CancellationToken cancellationToken)
        {
            var value = await _contactRepository.GetByIdAsync(deleteContactCommand.ContactId);
            await _contactRepository.DeleteAsync(value);
        }
    }
}