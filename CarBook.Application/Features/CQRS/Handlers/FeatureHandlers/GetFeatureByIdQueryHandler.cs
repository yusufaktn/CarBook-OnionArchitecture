using CarBook.Application.Features.CQRS.Queries.FeatureQueries;
using CarBook.Application.Features.CQRS.Results.FeatureResults;
using CarBook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.FeatureHandlers
{
    public class GetFeatureByIdQueryHandler : IRequestHandler<GetFeatureByIdQuery, GetFeatureByIdQueryResult>
    {
        private readonly IFeatureRepository _featureRepository;

        public GetFeatureByIdQueryHandler(IFeatureRepository featureRepository)
        {
            _featureRepository = featureRepository;
        }

        public async Task<GetFeatureByIdQueryResult> Handle(GetFeatureByIdQuery getFeatureByIdQuery, CancellationToken cancellationToken)
        {
            var value = await _featureRepository.GetByIdAsync(getFeatureByIdQuery.FeatureId);
            return new GetFeatureByIdQueryResult
            {
                FeatureId = value.FeatureId,
                Name = value.Name
            };
        }
    }
}