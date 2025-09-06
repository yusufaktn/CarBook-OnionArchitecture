using CarBook.Application.Features.CQRS.Command.SocialMediaCommand;
using CarBook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.SocialMediaHandlers
{
    public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommand>
    {
        private readonly ISocialMediaRepository _socialMediaRepository;

        public UpdateSocialMediaCommandHandler(ISocialMediaRepository socialMediaRepository)
        {
            _socialMediaRepository = socialMediaRepository;
        }

        public async Task Handle(UpdateSocialMediaCommand updateSocialMediaCommand, CancellationToken cancellationToken)
        {
            var value = await _socialMediaRepository.GetByIdAsync(updateSocialMediaCommand.SocialMediaId);
            value.Name = updateSocialMediaCommand.Name;
            value.Url = updateSocialMediaCommand.Url;
            value.Icon = updateSocialMediaCommand.Icon;
            await _socialMediaRepository.UpdateAsync(value);
        }
    }
}