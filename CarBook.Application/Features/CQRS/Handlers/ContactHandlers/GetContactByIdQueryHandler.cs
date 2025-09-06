using CarBook.Application.Features.CQRS.Queries.ContactQueries;
using CarBook.Application.Features.CQRS.Results.ContactResults;
using CarBook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactByIdQueryHandler : IRequestHandler<GetContactByIdQuery, GetContactByIdQueryResult>
    {
        private readonly IContactRepository _contactRepository;

        public GetContactByIdQueryHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery getContactByIdQuery, CancellationToken cancellationToken)
        {
            var value = await _contactRepository.GetByIdAsync(getContactByIdQuery.ContactId);
            return new GetContactByIdQueryResult
            {
                ContactId = value.ContactId,
                Name = value.Name,
                Email = value.Email,
                Subject = value.Subject,
                Message = value.Message,
                SendDate = value.SendDate
            };
        }
    }
}