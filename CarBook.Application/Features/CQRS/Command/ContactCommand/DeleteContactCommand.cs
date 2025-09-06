using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Command.ContactCommand
{
    public class DeleteContactCommand : IRequest
    {
        public int ContactId { get; set; }

        public DeleteContactCommand(int contactId)
        {
            ContactId = contactId;
        }
    }
}