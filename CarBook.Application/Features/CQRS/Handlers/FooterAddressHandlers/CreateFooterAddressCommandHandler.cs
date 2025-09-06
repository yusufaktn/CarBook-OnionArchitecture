using CarBook.Application.Features.CQRS.Command.FooterAddressCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.FooterAddressHandlers
{
    public class CreateFooterAddressCommandHandler : IRequestHandler<CreateFooterAddressCommand>
    {
        private readonly IFooterAddressRepository _footerAddressRepository;

        public CreateFooterAddressCommandHandler(IFooterAddressRepository footerAddressRepository)
        {
            _footerAddressRepository = footerAddressRepository;
        }

        public async Task Handle(CreateFooterAddressCommand createFooterAddressCommand, CancellationToken cancellationToken)
        {
            await _footerAddressRepository.AddAsync(new FooterAddress
            {
                Description = createFooterAddressCommand.Description,
                Address = createFooterAddressCommand.Address,
                Phone = createFooterAddressCommand.Phone,
                Email = createFooterAddressCommand.Email
            });
        }
    }
}