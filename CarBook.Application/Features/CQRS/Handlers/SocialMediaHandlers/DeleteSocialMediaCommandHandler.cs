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
    public class DeleteSocialMediaCommandHandler : IRequestHandler<DeleteSocialMediaCommand>
    {
        private readonly ISocialMediaRepository _socialMediaRepository;

        public DeleteSocialMediaCommandHandler(ISocialMediaRepository socialMediaRepository)
        {
            _socialMediaRepository = socialMediaRepository;
        }

        public async Task Handle(DeleteSocialMediaCommand deleteSocialMediaCommand, CancellationToken cancellationToken)
        {
            var value = await _socialMediaRepository.GetByIdAsync(deleteSocialMediaCommand.SocialMediaId);
            await _socialMediaRepository.DeleteAsync(value);
        }
    }
}