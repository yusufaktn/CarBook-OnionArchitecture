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
    public class DeleteFooterAddressCommandHandler : IRequestHandler<DeleteFooterAddressCommand>
    {
        private readonly IFooterAddressRepository _footerAddressRepository;

        public DeleteFooterAddressCommandHandler(IFooterAddressRepository footerAddressRepository)
        {
            _footerAddressRepository = footerAddressRepository;
        }

        public async Task Handle(DeleteFooterAddressCommand deleteFooterAddressCommand, CancellationToken cancellationToken)
        {
            var value = await _footerAddressRepository.GetByIdAsync(deleteFooterAddressCommand.FooterAddressId);
            await _footerAddressRepository.DeleteAsync(value);
        }
    }
}