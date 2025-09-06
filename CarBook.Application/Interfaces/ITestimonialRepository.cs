using CarBook.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces
{
    public interface ITestimonialRepository : IRepository<Testimonial>
    {
        // Additional methods specific to Testimonial entity can be added here
    }
}