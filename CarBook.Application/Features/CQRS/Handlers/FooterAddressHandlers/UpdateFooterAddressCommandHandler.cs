using CarBook.Application.Features.CQRS.Command.FooterAddressCommand;
using CarBook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.FooterAddressHandlers
{
    public class UpdateFooterAddressCommandHandler : IRequestHandler<UpdateFooterAddressCommand>
    {
        private readonly IFooterAddressRepository _footerAddressRepository;

        public UpdateFooterAddressCommandHandler(IFooterAddressRepository footerAddressRepository)
        {
            _footerAddressRepository = footerAddressRepository;
        }

        public async Task Handle(UpdateFooterAddressCommand updateFooterAddressCommand, CancellationToken cancellationToken)
        {
            var value = await _footerAddressRepository.GetByIdAsync(updateFooterAddressCommand.FooterAddressId);
            value.Description = updateFooterAddressCommand.Description;
            value.Address = updateFooterAddressCommand.Address;
            value.Phone = updateFooterAddressCommand.Phone;
            value.Email = updateFooterAddressCommand.Email;
            await _footerAddressRepository.UpdateAsync(value);
        }
    }
}