using CarBook.Application.Features.CQRS.Command.CarCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand>
    {
        private readonly ICarRepository _carRepository;

        public CreateCarCommandHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task Handle(CreateCarCommand createCarCommand, CancellationToken cancellationToken)
        {
            await _carRepository.AddAsync(new Car
            {
                BrandId = createCarCommand.BrandId,
                Model = createCarCommand.Model,
                CoverImageUrl = createCarCommand.CoverImageUrl,
                BigImageUrl = createCarCommand.BigImageUrl,
                Km = createCarCommand.Km,
                Transmission = createCarCommand.Transmission,
                Seat = createCarCommand.Seat,
                Luggage = createCarCommand.Luggage,
                Fuel = createCarCommand.Fuel
            });
        }
    }
}