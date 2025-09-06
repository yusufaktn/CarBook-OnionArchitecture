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
    public class CreateBannerCommandHandler : IRequestHandler<CreateBannerCommand>
    {
        private readonly IBannerRepository _bannerRepository;

        public CreateBannerCommandHandler(IBannerRepository bannerRepository)
        {
            _bannerRepository = bannerRepository;
        }

        public async Task Handle(CreateBannerCommand createBannerCommand, CancellationToken cancellationToken)
        {
            await _bannerRepository.AddAsync(new Banner
            {
                Title = createBannerCommand.Title,
                Description = createBannerCommand.Description,
                VideoDescription = createBannerCommand.VideoDescription
            });
        }
    }
}