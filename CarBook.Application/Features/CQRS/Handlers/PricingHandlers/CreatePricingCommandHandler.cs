using CarBook.Application.Features.CQRS.Command.PricingCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.PricingHandlers
{
    public class CreatePricingCommandHandler : IRequestHandler<CreatePricingCommand>
    {
        private readonly IPricingRepository _pricingRepository;

        public CreatePricingCommandHandler(IPricingRepository pricingRepository)
        {
            _pricingRepository = pricingRepository;
        }

        public async Task Handle(CreatePricingCommand createPricingCommand, CancellationToken cancellationToken)
        {
            await _pricingRepository.AddAsync(new Pricing
            {
                PricingType = createPricingCommand.PricingType
            });
        }
    }
}