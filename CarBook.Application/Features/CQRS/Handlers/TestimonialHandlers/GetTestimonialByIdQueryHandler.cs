using CarBook.Application.Features.CQRS.Queries.TestimonialQueries;
using CarBook.Application.Features.CQRS.Results.TestimonialResults;
using CarBook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.TestimonialHandlers
{
    public class GetTestimonialByIdQueryHandler : IRequestHandler<GetTestimonialByIdQuery, GetTestimonialByIdQueryResult>
    {
        private readonly ITestimonialRepository _testimonialRepository;

        public GetTestimonialByIdQueryHandler(ITestimonialRepository testimonialRepository)
        {
            _testimonialRepository = testimonialRepository;
        }

        public async Task<GetTestimonialByIdQueryResult> Handle(GetTestimonialByIdQuery getTestimonialByIdQuery, CancellationToken cancellationToken)
        {
            var value = await _testimonialRepository.GetByIdAsync(getTestimonialByIdQuery.TestimonialId);
            return new GetTestimonialByIdQueryResult
            {
                TestimonialId = value.TestimonialId,
                Name = value.Name,
                Title = value.Title,
                Comment = value.Comment,
                ImageUrl = value.ImageUrl
            };
        }
    }
}