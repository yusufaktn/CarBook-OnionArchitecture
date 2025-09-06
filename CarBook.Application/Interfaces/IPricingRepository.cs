using CarBook.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces
{
    public interface IPricingRepository : IRepository<Pricing>
    {
        // Additional methods specific to Pricing entity can be added here
    }
}