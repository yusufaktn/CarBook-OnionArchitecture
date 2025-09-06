using CarBook.Application.Features.CQRS.Queries.FooterAddressQueries;
using CarBook.Application.Features.CQRS.Results.FooterAddressResults;
using CarBook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.FooterAddressHandlers
{
    public class GetFooterAddressQueryHandler : IRequestHandler<GetFooterAddressQuery, List<GetFooterAddressQueryResult>>
    {
        private readonly IFooterAddressRepository _footerAddressRepository;

        public GetFooterAddressQueryHandler(IFooterAddressRepository footerAddressRepository)
        {
            _footerAddressRepository = footerAddressRepository;
        }

        public async Task<List<GetFooterAddressQueryResult>> Handle(GetFooterAddressQuery getFooterAddressQuery, CancellationToken cancellationToken)
        {
            var values = await _footerAddressRepository.GetAllAsync();
            return values.Select(x => new GetFooterAddressQueryResult
            {
                FooterAddressId = x.FooterAddressId,
                Description = x.Description,
                Address = x.Address,
                Phone = x.Phone,
                Email = x.Email
            }).ToList();
        }
    }
}