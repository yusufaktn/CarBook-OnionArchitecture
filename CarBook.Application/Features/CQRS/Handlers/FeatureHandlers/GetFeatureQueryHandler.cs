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
    public class GetFeatureQueryHandler : IRequestHandler<GetFeatureQuery, List<GetFeatureQueryResult>>
    {
        private readonly IFeatureRepository _featureRepository;

        public GetFeatureQueryHandler(IFeatureRepository featureRepository)
        {
            _featureRepository = featureRepository;
        }

        public async Task<List<GetFeatureQueryResult>> Handle(GetFeatureQuery getFeatureQuery, CancellationToken cancellationToken)
        {
            var values = await _featureRepository.GetAllAsync();
            return values.Select(x => new GetFeatureQueryResult
            {
                FeatureId = x.FeatureId,
                Name = x.Name
            }).ToList();
        }
    }
}