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
    public class GetBannerQueryHandler : IRequestHandler<GetBannerQuery, List<GetBannerQueryResult>>
    {
        private readonly IBannerRepository _bannerRepository;

        public GetBannerQueryHandler(IBannerRepository bannerRepository)
        {
            _bannerRepository = bannerRepository;
        }

        public async Task<List<GetBannerQueryResult>> Handle(GetBannerQuery getBannerQuery, CancellationToken cancellationToken)
        {
            var values = await _bannerRepository.GetAllAsync();
            return values.Select(x => new GetBannerQueryResult
            {
                BannerId = x.BannerId,
                Title = x.Title,
                Description = x.Description,
                VideoDescription = x.VideoDescription
            }).ToList();
        }
    }
}