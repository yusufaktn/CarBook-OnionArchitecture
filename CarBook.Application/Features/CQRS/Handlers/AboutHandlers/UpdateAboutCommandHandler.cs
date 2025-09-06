using CarBook.Application.Features.CQRS.Command.AboutCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class UpdateAboutCommandHandler: IRequestHandler<UpdateAboutCommand>
    {
        private readonly IAboutRepository _aboutRepository;

        public UpdateAboutCommandHandler(IAboutRepository aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }

        public async Task Handle(UpdateAboutCommand updateAboutCommand, CancellationToken cancellationToken)
        {
            var value = await _aboutRepository.GetByIdAsync(updateAboutCommand.AboutId);
            value.Title = updateAboutCommand.Title;
            value.Description = updateAboutCommand.Description;
            value.ImageUrl = updateAboutCommand.ImageUrl;
            await _aboutRepository.UpdateAsync(value);
        }
    }
}
