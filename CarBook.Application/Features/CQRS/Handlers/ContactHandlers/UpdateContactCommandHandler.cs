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
    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand>
    {
        private readonly IContactRepository _contactRepository;

        public UpdateContactCommandHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task Handle(UpdateContactCommand updateContactCommand, CancellationToken cancellationToken)
        {
            var value = await _contactRepository.GetByIdAsync(updateContactCommand.ContactId);
            value.Name = updateContactCommand.Name;
            value.Email = updateContactCommand.Email;
            value.Subject = updateContactCommand.Subject;
            value.Message = updateContactCommand.Message;
            value.SendDate = updateContactCommand.SendDate;
            await _contactRepository.UpdateAsync(value);
        }
    }
}