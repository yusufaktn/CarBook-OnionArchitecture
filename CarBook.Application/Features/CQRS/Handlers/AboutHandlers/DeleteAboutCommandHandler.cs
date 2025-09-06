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
    public class DeleteAboutCommandHandler: IRequestHandler<DeleteAboutCommand>
    {
        private readonly IAboutRepository _aboutRepository;
        public DeleteAboutCommandHandler(IAboutRepository aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }

        public async Task Handle(DeleteAboutCommand deleteAboutCommand, CancellationToken cancellationToken)
        {
            var value = await _aboutRepository.GetByIdAsync(deleteAboutCommand.AboutId);
            await _aboutRepository.DeleteAsync(value);
        }
    }
}
