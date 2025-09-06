using CarBook.Domain.Entites.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Command.CarCommand
{
    public class CreateCarCommand: IRequest
    {
        public int BrandId { get; set; }
        public string Model { get; set; }
        public string CoverImageUrl { get; set; }
        public string BigImageUrl { get; set; }
        public int Km { get; set; }
        public TransmissionType Transmission { get; set; }
        public byte Seat { get; set; }
        public string Luggage { get; set; }
        public FuelType Fuel { get; set; }
    }
}