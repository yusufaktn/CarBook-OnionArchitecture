using CarBook.Application.Interfaces;
using CarBook.Domain.Entites;
using CarBook.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories
{
    public class CarDescriptionRepository : Repository<CarDescription>, ICarDescriptionRepository
    {
        public CarDescriptionRepository(MyContext myContext) : base(myContext)
        {
        }
    }
}