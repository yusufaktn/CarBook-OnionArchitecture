using CarBook.Application.Features.CQRS.Command.CarCommand;
using CarBook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand>
    {
        private readonly ICarRepository _carRepository;

        public UpdateCarCommandHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task Handle(UpdateCarCommand updateCarCommand, CancellationToken cancellationToken)
        {
            var value = await _carRepository.GetByIdAsync(updateCarCommand.CarId);
            value.BrandId = updateCarCommand.BrandId;
            value.Model = updateCarCommand.Model;
            value.CoverImageUrl = updateCarCommand.CoverImageUrl;
            value.BigImageUrl = updateCarCommand.BigImageUrl;
            value.Km = updateCarCommand.Km;
            value.Transmission = updateCarCommand.Transmission;
            value.Seat = updateCarCommand.Seat;
            value.Luggage = updateCarCommand.Luggage;
            value.Fuel = updateCarCommand.Fuel;
            await _carRepository.UpdateAsync(value);
        }
    }
}