using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Command.UserCommand
{
    public class DeleteUserCommand : IRequest
    {
        public DeleteUserCommand(int id)
        {
            UserId = id;
        }
        public int UserId { get; set; }
    }
}