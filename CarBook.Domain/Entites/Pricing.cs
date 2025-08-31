using CarBook.Domain.Entites.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entites
{
    public class Pricing
    {
        public int PricingId { get; set; }
        public PricingType PricingType { get; set; }
        public List<CarPricing> CarPricings { get; set; }

    }
}
