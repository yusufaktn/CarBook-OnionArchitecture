using CarBook.Application.Features.CQRS.Queries.AnswerQueries;
using CarBook.Application.Features.CQRS.Results.AnswerResults;
using CarBook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.AnswerHandlers
{
    public class GetAnswerQueryHandler : IRequestHandler<GetAnswerQuery, List<GetAnswerQueryResult>>
    {
        private readonly IAnswerRepository _answerRepository;

        public GetAnswerQueryHandler(IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }

        public async Task<List<GetAnswerQueryResult>> Handle(GetAnswerQuery getAnswerQuery, CancellationToken cancellationToken)
        {
            var values = await _answerRepository.GetAllAsync();
            return values.Select(x => new GetAnswerQueryResult
            {
                AnswerId = x.AnswerId,
                QuestionId = x.QuestionId,
                UserId = x.UserId,
                Content = x.Content
            }).ToList();
        }
    }
}