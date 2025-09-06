using CarBook.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces
{
    public interface IFooterAddressRepository : IRepository<FooterAddress>
    {
        // Additional methods specific to FooterAddress entity can be added here
    }
}