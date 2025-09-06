using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Command.LocationCommand
{
    public class DeleteLocationCommand : IRequest
    {
        public int LocationId { get; set; }

        public DeleteLocationCommand(int locationId)
        {
            LocationId = locationId;
        }
    }
}