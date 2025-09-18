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
    public class GetAnswerByQuestionIdQueryHandler: IRequestHandler<GetAnswerByQuestionIdQuery, List<GetAnswerByQuestionIdResult>>
    {
        private readonly IAnswerRepository _answerRepository;

        public GetAnswerByQuestionIdQueryHandler(IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }

        public async Task<List<GetAnswerByQuestionIdResult>> Handle(GetAnswerByQuestionIdQuery request, CancellationToken cancellationToken)
        {
            var answers =  await _answerRepository.GetAnswersByQuestionIdAsync(request.QuestionId);
            return answers.Select(a => new GetAnswerByQuestionIdResult
            {
                AnswerId = a.AnswerId,
                QuestionId = a.QuestionId,
                UserId = a.UserId,
                Content = a.Content,
                UserName = a.User.UserName,
                UserLastName = a.User.UserLastName,
                ProfileImageUrl = a.User.ProfileImageUrl,
            }).ToList();
        }
    }
}
