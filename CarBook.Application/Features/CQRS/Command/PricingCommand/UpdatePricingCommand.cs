using CarBook.Domain.Entites.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Command.PricingCommand
{
    public class UpdatePricingCommand : IRequest
    {
        public int PricingId { get; set; }
        public PricingType PricingType { get; set; }
    }
}