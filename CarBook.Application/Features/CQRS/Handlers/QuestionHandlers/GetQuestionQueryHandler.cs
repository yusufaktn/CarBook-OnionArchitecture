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
    public class GetQuestionQueryHandler : IRequestHandler<GetQuestionQuery, List<GetQuestionQueryResult>>
    {
        private readonly IQuestionRepository _questionRepository;

        public GetQuestionQueryHandler(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<List<GetQuestionQueryResult>> Handle(GetQuestionQuery getQuestionQuery, CancellationToken cancellationToken)
        {
            var values = await _questionRepository.GetAllAsync();
            return values.Select(x => new GetQuestionQueryResult
            {
                QuestionId = x.QuestionId,
                UserId = x.UserId,
                CategoryId = x.CategoryId,
                BrandId = x.BrandId,
                SubBrandCategory = x.SubBrandCategory,
                Title = x.Title,
                Content = x.Content
            }).ToList();
        }
    }
}