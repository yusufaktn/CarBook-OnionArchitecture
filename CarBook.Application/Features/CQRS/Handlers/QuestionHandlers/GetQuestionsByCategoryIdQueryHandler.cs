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
    public class GetQuestionsByCategoryIdQueryHandler : IRequestHandler<GetQuestionsByCategoryIdQuery, List<GetQuestionsByCategoryIdQueryResult>>
    {
        private readonly IQuestionRepository _questionRepository;
        public GetQuestionsByCategoryIdQueryHandler(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }
        public async Task<List<GetQuestionsByCategoryIdQueryResult>> Handle(GetQuestionsByCategoryIdQuery request, CancellationToken cancellationToken)
        {
            var questions = await _questionRepository.GetQuestionsByCategoryIdAsync(request.CategoryId);
            return questions.Select(q => new GetQuestionsByCategoryIdQueryResult
            {
                QuestionId = q.QuestionId,
                UserName = q.User.UserName,
                BrandName = q.Brand.Name,
                CategoryName = q.Category.Name,
                Title = q.Title,
                Content = q.Content,
                BrandId = q.BrandId,
                CategoryId = q.CategoryId,
                SubBrandCategory = q.SubBrandCategory,
                UserId = q.UserId

            }).ToList();
        }
    }
}
