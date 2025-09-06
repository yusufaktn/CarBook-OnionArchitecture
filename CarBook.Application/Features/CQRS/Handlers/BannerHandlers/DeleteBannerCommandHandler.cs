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
    public class DeleteBannerCommandHandler : IRequestHandler<DeleteBannerCommand>
    {
        private readonly IBannerRepository _bannerRepository;
        public DeleteBannerCommandHandler(IBannerRepository bannerRepository)
        {
            _bannerRepository = bannerRepository;
        }

        public async Task Handle(DeleteBannerCommand deleteBannerCommand, CancellationToken cancellationToken)
        {
            var value = await _bannerRepository.GetByIdAsync(deleteBannerCommand.BannerId);
            await _bannerRepository.DeleteAsync(value);
        }
    }
}