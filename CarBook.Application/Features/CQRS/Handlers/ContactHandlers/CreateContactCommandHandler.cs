using CarBook.Application.Features.CQRS.Command.ContactCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand>
    {
        private readonly IContactRepository _contactRepository;

        public CreateContactCommandHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task Handle(CreateContactCommand createContactCommand, CancellationToken cancellationToken)
        {
            await _contactRepository.AddAsync(new Contact
            {
                Name = createContactCommand.Name,
                Email = createContactCommand.Email,
                Subject = createContactCommand.Subject,
                Message = createContactCommand.Message,
                SendDate = createContactCommand.SendDate
            });
        }
    }
}