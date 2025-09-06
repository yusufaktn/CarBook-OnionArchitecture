using CarBook.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces
{
    public interface ICarPricingRepository : IRepository<CarPricing>
    {
        // Additional methods specific to CarPricing entity can be added here
    }
}