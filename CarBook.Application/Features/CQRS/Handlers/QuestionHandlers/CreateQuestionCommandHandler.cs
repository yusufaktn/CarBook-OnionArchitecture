using CarBook.Application.Features.CQRS.Command.QuestionCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.QuestionHandlers
{
    public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommand>
    {
        private readonly IQuestionRepository _questionRepository;

        public CreateQuestionCommandHandler(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task Handle(CreateQuestionCommand createQuestionCommand, CancellationToken cancellationToken)
        {
            await _questionRepository.AddAsync(new Question
            {
                UserId = createQuestionCommand.UserId,
                CategoryId = createQuestionCommand.CategoryId,
                BrandId = createQuestionCommand.BrandId,
                SubBrandCategory = createQuestionCommand.SubBrandCategory,
                Title = createQuestionCommand.Title,
                Content = createQuestionCommand.Content
            });
        }
    }
}