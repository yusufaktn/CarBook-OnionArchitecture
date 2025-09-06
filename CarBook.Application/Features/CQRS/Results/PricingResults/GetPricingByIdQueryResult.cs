using CarBook.Domain.Entites.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Results.PricingResults
{
    public class GetPricingByIdQueryResult
    {
        public int PricingId { get; set; }
        public PricingType PricingType { get; set; }
    }
}