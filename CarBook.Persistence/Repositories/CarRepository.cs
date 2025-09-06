using CarBook.Application.Interfaces;
using CarBook.Domain.Entites;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories
{
    public class CarRepository : Repository<Car>, ICarRepository
    {
        private readonly MyContext _myContext;

        public CarRepository(MyContext myContext) : base(myContext)
        {
            _myContext = myContext;
        }

        public async Task<List<Car>> GetCarsWithBrands()
        {
            var values = await _myContext.Cars.Include(x => x.Brand).ToListAsync();
            return values;
        }
    }
}