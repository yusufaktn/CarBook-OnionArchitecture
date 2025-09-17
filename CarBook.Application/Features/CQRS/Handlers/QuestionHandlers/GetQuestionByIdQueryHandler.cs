using CarBook.Application.Features.CQRS.Queries.QuestionQueries;
using CarBook.Application.Features.CQRS.Results.QuestionResults;
using CarBook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.QuestionHandlers
{
    public class GetQuestionByIdQueryHandler : IRequestHandler<GetQuestionByIdQuery, GetQuestionByIdQueryResult>
    {
        private readonly IQuestionRepository _questionRepository;

        public GetQuestionByIdQueryHandler(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<GetQuestionByIdQueryResult> Handle(GetQuestionByIdQuery getQuestionByIdQuery, CancellationToken cancellationToken)
        {
            var value = await _questionRepository.GetByIdAsync(getQuestionByIdQuery.QuestionId);
            return new GetQuestionByIdQueryResult
            {
                QuestionId = value.QuestionId,
                UserId = value.UserId,
                CategoryId = value.CategoryId,
                BrandId = value.BrandId,
                SubBrandCategory = value.SubBrandCategory,
                Title = value.Title,
                Content = value.Content
            };
        }
    }
}