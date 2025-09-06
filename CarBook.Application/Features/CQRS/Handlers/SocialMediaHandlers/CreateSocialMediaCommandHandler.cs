using CarBook.Application.Features.CQRS.Command.SocialMediaCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.SocialMediaHandlers
{
    public class CreateSocialMediaCommandHandler : IRequestHandler<CreateSocialMediaCommand>
    {
        private readonly ISocialMediaRepository _socialMediaRepository;

        public CreateSocialMediaCommandHandler(ISocialMediaRepository socialMediaRepository)
        {
            _socialMediaRepository = socialMediaRepository;
        }

        public async Task Handle(CreateSocialMediaCommand createSocialMediaCommand, CancellationToken cancellationToken)
        {
            await _socialMediaRepository.AddAsync(new SocialMedia
            {
                Name = createSocialMediaCommand.Name,
                Url = createSocialMediaCommand.Url,
                Icon = createSocialMediaCommand.Icon
            });
        }
    }
}