using CarBook.Application.Features.CQRS.Command.TestimonialCommand;
using CarBook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.TestimonialHandlers
{
    public class DeleteTestimonialCommandHandler : IRequestHandler<DeleteTestimonialCommand>
    {
        private readonly ITestimonialRepository _testimonialRepository;

        public DeleteTestimonialCommandHandler(ITestimonialRepository testimonialRepository)
        {
            _testimonialRepository = testimonialRepository;
        }

        public async Task Handle(DeleteTestimonialCommand deleteTestimonialCommand, CancellationToken cancellationToken)
        {
            var value = await _testimonialRepository.GetByIdAsync(deleteTestimonialCommand.TestimonialId);
            await _testimonialRepository.DeleteAsync(value);
        }
    }
}