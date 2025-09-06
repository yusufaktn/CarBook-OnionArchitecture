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
    public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand>
    {
        private readonly ICarRepository _carRepository;
        public DeleteCarCommandHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task Handle(DeleteCarCommand deleteCarCommand, CancellationToken cancellationToken)
        {
            var value = await _carRepository.GetByIdAsync(deleteCarCommand.CarId);
            await _carRepository.DeleteAsync(value);
        }
    }
}