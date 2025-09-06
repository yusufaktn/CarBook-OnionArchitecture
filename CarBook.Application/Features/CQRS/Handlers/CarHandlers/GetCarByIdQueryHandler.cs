using CarBook.Application.Features.CQRS.Queries.CarQueries;
using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarByIdQueryHandler : IRequestHandler<GetCarByIdQuery, GetCarByIdQueryResult>
    {
        private readonly ICarRepository _carRepository;
        public GetCarByIdQueryHandler(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery getCarByIdQuery, CancellationToken cancellationToken)
        {
            var value = await _carRepository.GetByIdAsync(getCarByIdQuery.CarId);
            return new GetCarByIdQueryResult
            {
                CarId = value.CarId,
                BrandId = value.BrandId,
                Model = value.Model,
                CoverImageUrl = value.CoverImageUrl,
                BigImageUrl = value.BigImageUrl,
                Km = value.Km,
                Transmission = value.Transmission,
                Seat = value.Seat,
                Luggage = value.Luggage,
                Fuel = value.Fuel
            };
        }
    }
}