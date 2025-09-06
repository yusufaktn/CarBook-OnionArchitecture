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
    public class GetPricingQueryHandler : IRequestHandler<GetPricingQuery, List<GetPricingQueryResult>>
    {
        private readonly IPricingRepository _pricingRepository;

        public GetPricingQueryHandler(IPricingRepository pricingRepository)
        {
            _pricingRepository = pricingRepository;
        }

        public async Task<List<GetPricingQueryResult>> Handle(GetPricingQuery getPricingQuery, CancellationToken cancellationToken)
        {
            var values = await _pricingRepository.GetAllAsync();
            return values.Select(x => new GetPricingQueryResult
            {
                PricingId = x.PricingId,
                PricingType = x.PricingType
            }).ToList();
        }
    }
}