using CarBook.Application.Features.CQRS.Queries.SocialMediaQueries;
using CarBook.Application.Features.CQRS.Results.SocialMediaResults;
using CarBook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.SocialMediaHandlers
{
    public class GetSocialMediaQueryHandler : IRequestHandler<GetSocialMediaQuery, List<GetSocialMediaQueryResult>>
    {
        private readonly ISocialMediaRepository _socialMediaRepository;

        public GetSocialMediaQueryHandler(ISocialMediaRepository socialMediaRepository)
        {
            _socialMediaRepository = socialMediaRepository;
        }

        public async Task<List<GetSocialMediaQueryResult>> Handle(GetSocialMediaQuery getSocialMediaQuery, CancellationToken cancellationToken)
        {
            var values = await _socialMediaRepository.GetAllAsync();
            return values.Select(x => new GetSocialMediaQueryResult
            {
                SocialMediaId = x.SocialMediaId,
                Name = x.Name,
                Url = x.Url,
                Icon = x.Icon
            }).ToList();
        }
    }
}