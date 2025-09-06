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
    public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand>
    {
        private readonly ILocationRepository _locationRepository;

        public UpdateLocationCommandHandler(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task Handle(UpdateLocationCommand updateLocationCommand, CancellationToken cancellationToken)
        {
            var value = await _locationRepository.GetByIdAsync(updateLocationCommand.LocationId);
            value.Name = updateLocationCommand.Name;
            await _locationRepository.UpdateAsync(value);
        }
    }
}