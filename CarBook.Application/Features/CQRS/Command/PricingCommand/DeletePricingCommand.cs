using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Command.PricingCommand
{
    public class DeletePricingCommand : IRequest
    {
        public int PricingId { get; set; }

        public DeletePricingCommand(int pricingId)
        {
            PricingId = pricingId;
        }
    }
}