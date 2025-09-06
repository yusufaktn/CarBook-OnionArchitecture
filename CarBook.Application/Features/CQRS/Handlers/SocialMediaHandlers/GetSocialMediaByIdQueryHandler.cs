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
    public class GetSocialMediaByIdQueryHandler : IRequestHandler<GetSocialMediaByIdQuery, GetSocialMediaByIdQueryResult>
    {
        private readonly ISocialMediaRepository _socialMediaRepository;

        public GetSocialMediaByIdQueryHandler(ISocialMediaRepository socialMediaRepository)
        {
            _socialMediaRepository = socialMediaRepository;
        }

        public async Task<GetSocialMediaByIdQueryResult> Handle(GetSocialMediaByIdQuery getSocialMediaByIdQuery, CancellationToken cancellationToken)
        {
            var value = await _socialMediaRepository.GetByIdAsync(getSocialMediaByIdQuery.SocialMediaId);
            return new GetSocialMediaByIdQueryResult
            {
                SocialMediaId = value.SocialMediaId,
                Name = value.Name,
                Url = value.Url,
                Icon = value.Icon
            };
        }
    }
}