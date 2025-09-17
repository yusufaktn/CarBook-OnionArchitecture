using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Command.AnswerCommand
{
    public class CreateAnswerCommand : IRequest
    {
        public int QuestionId { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
    }
}