using CarBook.Application.Features.CQRS.Command.TestimonialCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.TestimonialHandlers
{
    public class CreateTestimonialCommandHandler : IRequestHandler<CreateTestimonialCommand>
    {
        private readonly ITestimonialRepository _testimonialRepository;

        public CreateTestimonialCommandHandler(ITestimonialRepository testimonialRepository)
        {
            _testimonialRepository = testimonialRepository;
        }

        public async Task Handle(CreateTestimonialCommand createTestimonialCommand, CancellationToken cancellationToken)
        {
            await _testimonialRepository.AddAsync(new Testimonial
            {
                Name = createTestimonialCommand.Name,
                Title = createTestimonialCommand.Title,
                Comment = createTestimonialCommand.Comment,
                ImageUrl = createTestimonialCommand.ImageUrl
            });
        }
    }
}