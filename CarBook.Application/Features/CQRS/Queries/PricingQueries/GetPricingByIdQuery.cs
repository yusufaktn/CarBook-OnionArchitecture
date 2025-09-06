using CarBook.Application.Features.CQRS.Results.PricingResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Queries.PricingQueries
{
    public class GetPricingByIdQuery : IRequest<GetPricingByIdQueryResult>
    {
        public GetPricingByIdQuery(int id)
        {
            PricingId = id;
        }

        public int PricingId { get; set; }
    }
}