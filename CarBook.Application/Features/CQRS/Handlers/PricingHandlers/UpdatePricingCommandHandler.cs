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
    public class UpdatePricingCommandHandler : IRequestHandler<UpdatePricingCommand>
    {
        private readonly IPricingRepository _pricingRepository;

        public UpdatePricingCommandHandler(IPricingRepository pricingRepository)
        {
            _pricingRepository = pricingRepository;
        }

        public async Task Handle(UpdatePricingCommand updatePricingCommand, CancellationToken cancellationToken)
        {
            var value = await _pricingRepository.GetByIdAsync(updatePricingCommand.PricingId);
            value.PricingType = updatePricingCommand.PricingType;
            await _pricingRepository.UpdateAsync(value);
        }
    }
}