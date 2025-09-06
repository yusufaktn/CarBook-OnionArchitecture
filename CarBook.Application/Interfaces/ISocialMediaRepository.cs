using CarBook.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces
{
    public interface ISocialMediaRepository : IRepository<SocialMedia>
    {
        // Additional methods specific to SocialMedia entity can be added here
    }
}