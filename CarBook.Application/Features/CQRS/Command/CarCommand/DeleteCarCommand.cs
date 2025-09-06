using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Command.CarCommand
{
    public class DeleteCarCommand:IRequest
    {
        public int CarId { get; set; }

        public DeleteCarCommand(int carId)
        {
            CarId = carId;
        }
    }
}