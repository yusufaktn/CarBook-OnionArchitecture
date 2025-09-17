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
    public class GetAnswerByIdQueryHandler : IRequestHandler<GetAnswerByIdQuery, GetAnswerByIdQueryResult>
    {
        private readonly IAnswerRepository _answerRepository;

        public GetAnswerByIdQueryHandler(IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }

        public async Task<GetAnswerByIdQueryResult> Handle(GetAnswerByIdQuery getAnswerByIdQuery, CancellationToken cancellationToken)
        {
            var value = await _answerRepository.GetByIdAsync(getAnswerByIdQuery.AnswerId);
            return new GetAnswerByIdQueryResult
            {
                AnswerId = value.AnswerId,
                QuestionId = value.QuestionId,
                UserId = value.UserId,
                Content = value.Content
            };
        }
    }
}