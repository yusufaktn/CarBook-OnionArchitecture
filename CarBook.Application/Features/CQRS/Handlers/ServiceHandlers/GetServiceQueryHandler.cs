using CarBook.Application.Features.CQRS.Queries.ServiceQueries;
using CarBook.Application.Features.CQRS.Results.ServiceResults;
using CarBook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ServiceHandlers
{
    public class GetServiceQueryHandler : IRequestHandler<GetServiceQuery, List<GetServiceQueryResult>>
    {
        private readonly IServiceRepository _serviceRepository;

        public GetServiceQueryHandler(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<List<GetServiceQueryResult>> Handle(GetServiceQuery getServiceQuery, CancellationToken cancellationToken)
        {
            var values = await _serviceRepository.GetAllAsync();
            return values.Select(x => new GetServiceQueryResult
            {
                ServiceId = x.ServiceId,
                Title = x.Title,
                Description = x.Description,
                IconUrl = x.IconUrl
            }).ToList();
        }
    }
}