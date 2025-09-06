using CarBook.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces
{
    public interface IAboutRepository : IRepository<About>
    {
        // Additional methods specific to About entity can be added here
    }
} 