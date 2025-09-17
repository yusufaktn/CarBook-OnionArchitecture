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
    public class GetLastThreeQuestionsQueryHandler : IRequestHandler<GetLastThreeQuestionsQuery, List<GetLastThreeQuestionsQueryResult>>
    {
        private readonly IQuestionRepository _questionRepository;

        public GetLastThreeQuestionsQueryHandler(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<List<GetLastThreeQuestionsQueryResult>> Handle(GetLastThreeQuestionsQuery request, CancellationToken cancellationToken)
        {
            var values = await _questionRepository.GetLastThreeQuestionsAsync();
            return values.Select(x => new GetLastThreeQuestionsQueryResult
            {
                QuestionId = x.QuestionId,
                UserId = x.UserId,
                UserName = x.User.UserName,
                UserLastName = x.User.UserLastName,
                CategoryId = x.CategoryId,
                CategoryName = x.Category.Name,
                BrandId = x.BrandId,
                BrandName = x.Brand.Name,
                SubBrandCategory = x.SubBrandCategory,
                Title = x.Title,
                Content = x.Content
            }).ToList();
        }
    }
}