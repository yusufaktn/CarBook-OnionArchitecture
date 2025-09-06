using CarBook.Application.Features.CQRS.Command.PricingCommand;
using CarBook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.PricingHandlers
{
    public class DeletePricingCommandHandler : IRequestHandler<DeletePricingCommand>
    {
        private readonly IPricingRepository _pricingRepository;

        public DeletePricingCommandHandler(IPricingRepository pricingRepository)
        {
            _pricingRepository = pricingRepository;
        }

        public async Task Handle(DeletePricingCommand deletePricingCommand, CancellationToken cancellationToken)
        {
            var value = await _pricingRepository.GetByIdAsync(deletePricingCommand.PricingId);
            await _pricingRepository.DeleteAsync(value);
        }
    }
}