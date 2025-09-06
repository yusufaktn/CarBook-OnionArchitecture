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
    public class CreateAboutCommandHandler:IRequestHandler<CreateAboutCommand>
    {
        private readonly IAboutRepository _aboutRepository;

        public CreateAboutCommandHandler(IAboutRepository aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }

        public async Task Handle(CreateAboutCommand createAboutCommand,CancellationToken cancellationToken)
        {

            await _aboutRepository.AddAsync(new About
            {
                Title = createAboutCommand.Title,
                Description = createAboutCommand.Description,
                ImageUrl = createAboutCommand.ImageUrl
            });
        }
    }
}
