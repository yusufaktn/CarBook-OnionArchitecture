using CarBook.Application.Features.CQRS.Command.LocationCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.LocationHandlers
{
    public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand>
    {
        private readonly ILocationRepository _locationRepository;

        public CreateLocationCommandHandler(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task Handle(CreateLocationCommand createLocationCommand, CancellationToken cancellationToken)
        {
            await _locationRepository.AddAsync(new Location
            {
                Name = createLocationCommand.Name
            });
        }
    }
}