using CarBook.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces
{
    public interface ICarFeatureRepository : IRepository<CarFeature>
    {
        // Additional methods specific to CarFeature entity can be added here
    }
}