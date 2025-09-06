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
    public class GetLocationByIdQueryHandler : IRequestHandler<GetLocationByIdQuery, GetLocationByIdQueryResult>
    {
        private readonly ILocationRepository _locationRepository;

        public GetLocationByIdQueryHandler(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<GetLocationByIdQueryResult> Handle(GetLocationByIdQuery getLocationByIdQuery, CancellationToken cancellationToken)
        {
            var value = await _locationRepository.GetByIdAsync(getLocationByIdQuery.LocationId);
            return new GetLocationByIdQueryResult
            {
                LocationId = value.LocationId,
                Name = value.Name
            };
        }
    }
}