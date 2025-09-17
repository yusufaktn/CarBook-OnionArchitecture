using CarBook.Application.Features.CQRS.Results.QuestionResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Queries.QuestionQueries
{
    public class GetQuestionQuery : IRequest<List<GetQuestionQueryResult>>
    {
    }
}