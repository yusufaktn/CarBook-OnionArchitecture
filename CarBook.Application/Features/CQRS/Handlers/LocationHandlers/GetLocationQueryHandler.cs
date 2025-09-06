using CarBook.Application.Features.CQRS.Queries.LocationQueries;
using CarBook.Application.Features.CQRS.Results.LocationResults;
using CarBook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.LocationHandlers
{
    public class GetLocationQueryHandler : IRequestHandler<GetLocationQuery, List<GetLocationQueryResult>>
    {
        private readonly ILocationRepository _locationRepository;

        public GetLocationQueryHandler(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<List<GetLocationQueryResult>> Handle(GetLocationQuery getLocationQuery, CancellationToken cancellationToken)
        {
            var values = await _locationRepository.GetAllAsync();
            return values.Select(x => new GetLocationQueryResult
            {
                LocationId = x.LocationId,
                Name = x.Name
            }).ToList();
        }
    }
}