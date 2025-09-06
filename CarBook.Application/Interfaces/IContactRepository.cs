using CarBook.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces
{
    public interface IContactRepository : IRepository<Contact>
    {
        // Additional methods specific to Contact entity can be added here
    }
}