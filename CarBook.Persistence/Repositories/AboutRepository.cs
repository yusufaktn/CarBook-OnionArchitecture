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
    public class AboutRepository : Repository<About>, IAboutRepository
    {
        public AboutRepository(MyContext myContext) : base(myContext)
        {
        }
    }
}