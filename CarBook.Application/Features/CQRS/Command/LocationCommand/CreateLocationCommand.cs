using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Command.LocationCommand
{
    public class CreateLocationCommand : IRequest
    {
        public string Name { get; set; }
    }
}