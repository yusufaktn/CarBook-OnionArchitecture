using CarBook.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces
{
    public interface IBrandRepository : IRepository<Brand>
    {
        // Additional methods specific to Brand entity can be added here
    }
}