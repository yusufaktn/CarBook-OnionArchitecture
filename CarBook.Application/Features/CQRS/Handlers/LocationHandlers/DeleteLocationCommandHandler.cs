using CarBook.Application.Features.CQRS.Command.LocationCommand;
using CarBook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.LocationHandlers
{
    public class DeleteLocationCommandHandler : IRequestHandler<DeleteLocationCommand>
    {
        private readonly ILocationRepository _locationRepository;

        public DeleteLocationCommandHandler(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task Handle(DeleteLocationCommand deleteLocationCommand, CancellationToken cancellationToken)
        {
            var value = await _locationRepository.GetByIdAsync(deleteLocationCommand.LocationId);
            await _locationRepository.DeleteAsync(value);
        }
    }
}