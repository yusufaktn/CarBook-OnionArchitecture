using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Command.QuestionCommand
{
    public class DeleteQuestionCommand : IRequest
    {
        public DeleteQuestionCommand(int id)
        {
            QuestionId = id;
        }
        public int QuestionId { get; set; }
    }
}