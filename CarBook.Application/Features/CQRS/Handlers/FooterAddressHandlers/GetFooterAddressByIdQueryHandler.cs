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
    public class GetFooterAddressByIdQueryHandler : IRequestHandler<GetFooterAddressByIdQuery, GetFooterAddressByIdQueryResult>
    {
        private readonly IFooterAddressRepository _footerAddressRepository;

        public GetFooterAddressByIdQueryHandler(IFooterAddressRepository footerAddressRepository)
        {
            _footerAddressRepository = footerAddressRepository;
        }

        public async Task<GetFooterAddressByIdQueryResult> Handle(GetFooterAddressByIdQuery getFooterAddressByIdQuery, CancellationToken cancellationToken)
        {
            var value = await _footerAddressRepository.GetByIdAsync(getFooterAddressByIdQuery.FooterAddressId);
            return new GetFooterAddressByIdQueryResult
            {
                FooterAddressId = value.FooterAddressId,
                Description = value.Description,
                Address = value.Address,
                Phone = value.Phone,
                Email = value.Email
            };
        }
    }
}