using CarBook.Application.Features.CQRS.Command.BannerCommand;
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
    public class UpdateBannerCommandHandler : IRequestHandler<UpdateBannerCommand>
    {
        private readonly IBannerRepository _bannerRepository;

        public UpdateBannerCommandHandler(IBannerRepository bannerRepository)
        {
            _bannerRepository = bannerRepository;
        }

        public async Task Handle(UpdateBannerCommand updateBannerCommand, CancellationToken cancellationToken)
        {
            var value = await _bannerRepository.GetByIdAsync(updateBannerCommand.BannerId);
            value.Title = updateBannerCommand.Title;
            value.Description = updateBannerCommand.Description;
            value.VideoDescription = updateBannerCommand.VideoDescription;
            await _bannerRepository.UpdateAsync(value);
        }
    }
}