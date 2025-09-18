using CarBook.Application.Features.CQRS.Results.AboutResults;
using CarBook.Application.Features.CQRS.Results.AnswerResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Queries.AnswerQueries
{
    public class GetAnswerByQuestionIdQuery:IRequest<List<GetAnswerByQuestionIdResult>>
    {
        public int QuestionId { get; set; }

        public GetAnswerByQuestionIdQuery(int id)
        {
            QuestionId = id;

        }
    }
}
