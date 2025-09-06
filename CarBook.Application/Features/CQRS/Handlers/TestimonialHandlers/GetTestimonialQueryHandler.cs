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
    public class GetTestimonialQueryHandler : IRequestHandler<GetTestimonialQuery, List<GetTestimonialQueryResult>>
    {
        private readonly ITestimonialRepository _testimonialRepository;

        public GetTestimonialQueryHandler(ITestimonialRepository testimonialRepository)
        {
            _testimonialRepository = testimonialRepository;
        }

        public async Task<List<GetTestimonialQueryResult>> Handle(GetTestimonialQuery getTestimonialQuery, CancellationToken cancellationToken)
        {
            var values = await _testimonialRepository.GetAllAsync();
            return values.Select(x => new GetTestimonialQueryResult
            {
                TestimonialId = x.TestimonialId,
                Name = x.Name,
                Title = x.Title,
                Comment = x.Comment,
                ImageUrl = x.ImageUrl
            }).ToList();
        }
    }
}