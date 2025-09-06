using CarBook.Application.Features.CQRS.Queries.BannerQueries;
using CarBook.Application.Features.CQRS.Results.BannerResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class GetBannerByIdQueryHandler : IRequestHandler<GetBannerByIdQuery, GetBannerByIdQueryResult>
    {
        private readonly IBannerRepository _bannerRepository;
        public GetBannerByIdQueryHandler(IBannerRepository bannerRepository)
        {
            _bannerRepository = bannerRepository;
        }

        public async Task<GetBannerByIdQueryResult> Handle(GetBannerByIdQuery getBannerByIdQuery, CancellationToken cancellationToken)
        {
            var value = await _bannerRepository.GetByIdAsync(getBannerByIdQuery.BannerId);
            return new GetBannerByIdQueryResult
            {
                BannerId = value.BannerId,
                Title = value.Title,
                Description = value.Description,
                VideoDescription = value.VideoDescription
            };
        }
    }
}