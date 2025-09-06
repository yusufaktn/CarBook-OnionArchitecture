using CarBook.Application.Features.CQRS.Queries.PricingQueries;
using CarBook.Application.Features.CQRS.Results.PricingResults;
using CarBook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.PricingHandlers
{
    public class GetPricingByIdQueryHandler : IRequestHandler<GetPricingByIdQuery, GetPricingByIdQueryResult>
    {
        private readonly IPricingRepository _pricingRepository;

        public GetPricingByIdQueryHandler(IPricingRepository pricingRepository)
        {
            _pricingRepository = pricingRepository;
        }

        public async Task<GetPricingByIdQueryResult> Handle(GetPricingByIdQuery getPricingByIdQuery, CancellationToken cancellationToken)
        {
            var value = await _pricingRepository.GetByIdAsync(getPricingByIdQuery.PricingId);
            return new GetPricingByIdQueryResult
            {
                PricingId = value.PricingId,
                PricingType = value.PricingType
            };
        }
    }
}