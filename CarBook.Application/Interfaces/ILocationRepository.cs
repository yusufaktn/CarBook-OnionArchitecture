using CarBook.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces
{
    public interface ILocationRepository : IRepository<Location>
    {
        // Additional methods specific to Location entity can be added here
    }
}