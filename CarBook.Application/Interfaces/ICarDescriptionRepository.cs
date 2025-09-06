using CarBook.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces
{
    public interface ICarDescriptionRepository : IRepository<CarDescription>
    {
        // Additional methods specific to CarDescription entity can be added here
    }
}