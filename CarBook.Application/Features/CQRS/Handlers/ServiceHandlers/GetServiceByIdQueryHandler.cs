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
    public class GetServiceByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, GetServiceByIdQueryResult>
    {
        private readonly IServiceRepository _serviceRepository;

        public GetServiceByIdQueryHandler(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<GetServiceByIdQueryResult> Handle(GetServiceByIdQuery getServiceByIdQuery, CancellationToken cancellationToken)
        {
            var value = await _serviceRepository.GetByIdAsync(getServiceByIdQuery.ServiceId);
            return new GetServiceByIdQueryResult
            {
                ServiceId = value.ServiceId,
                Title = value.Title,
                Description = value.Description,
                IconUrl = value.IconUrl
            };
        }
    }
}