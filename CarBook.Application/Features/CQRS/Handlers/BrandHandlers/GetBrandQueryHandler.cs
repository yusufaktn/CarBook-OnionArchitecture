using CarBook.Application.Features.CQRS.Queries.BrandQueries;
using CarBook.Application.Features.CQRS.Results.BrandResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class GetBrandQueryHandler : IRequestHandler<GetBrandQuery, List<GetBrandQueryResult>>
    {
        private readonly IBrandRepository _brandRepository;

        public GetBrandQueryHandler(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<List<GetBrandQueryResult>> Handle(GetBrandQuery getBrandQuery, CancellationToken cancellationToken)
        {
            var values = await _brandRepository.GetAllAsync();
            return values.Select(x => new GetBrandQueryResult
            {
                BrandId = x.BrandId,
                Name = x.Name
            }).ToList();
        }
    }
}