using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Command.TestimonialCommand
{
    public class DeleteTestimonialCommand : IRequest
    {
        public int TestimonialId { get; set; }

        public DeleteTestimonialCommand(int testimonialId)
        {
            TestimonialId = testimonialId;
        }
    }
}