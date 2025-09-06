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
    public class UpdateTestimonialCommandHandler : IRequestHandler<UpdateTestimonialCommand>
    {
        private readonly ITestimonialRepository _testimonialRepository;

        public UpdateTestimonialCommandHandler(ITestimonialRepository testimonialRepository)
        {
            _testimonialRepository = testimonialRepository;
        }

        public async Task Handle(UpdateTestimonialCommand updateTestimonialCommand, CancellationToken cancellationToken)
        {
            var value = await _testimonialRepository.GetByIdAsync(updateTestimonialCommand.TestimonialId);
            value.Name = updateTestimonialCommand.Name;
            value.Title = updateTestimonialCommand.Title;
            value.Comment = updateTestimonialCommand.Comment;
            value.ImageUrl = updateTestimonialCommand.ImageUrl;
            await _testimonialRepository.UpdateAsync(value);
        }
    }
}