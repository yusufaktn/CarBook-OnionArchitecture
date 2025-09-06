using CarBook.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        // Additional methods specific to Category entity can be added here
    }
}