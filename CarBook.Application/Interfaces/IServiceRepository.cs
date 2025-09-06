using CarBook.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces
{
    public interface IServiceRepository : IRepository<Service>
    {
        // Additional methods specific to Service entity can be added here
    }
}