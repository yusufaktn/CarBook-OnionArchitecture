using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Command.AnswerCommand
{
    public class DeleteAnswerCommand : IRequest
    {
        public DeleteAnswerCommand(int id)
        {
            AnswerId = id;
        }
        public int AnswerId { get; set; }
    }
}