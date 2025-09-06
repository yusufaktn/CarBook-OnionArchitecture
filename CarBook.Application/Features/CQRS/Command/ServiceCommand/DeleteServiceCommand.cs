using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Command.ServiceCommand
{
    public class DeleteServiceCommand : IRequest
    {
        public int ServiceId { get; set; }

        public DeleteServiceCommand(int serviceId)
        {
            ServiceId = serviceId;
        }
    }
}