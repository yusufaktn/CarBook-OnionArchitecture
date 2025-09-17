using CarBook.Application.Features.CQRS.Command.QuestionCommand;
using CarBook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.QuestionHandlers
{
    public class UpdateQuestionCommandHandler : IRequestHandler<UpdateQuestionCommand>
    {
        private readonly IQuestionRepository _questionRepository;

        public UpdateQuestionCommandHandler(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task Handle(UpdateQuestionCommand updateQuestionCommand, CancellationToken cancellationToken)
        {
            var value = await _questionRepository.GetByIdAsync(updateQuestionCommand.QuestionId);
            value.UserId = updateQuestionCommand.UserId;
            value.CategoryId = updateQuestionCommand.CategoryId;
            value.BrandId = updateQuestionCommand.BrandId;
            value.SubBrandCategory = updateQuestionCommand.SubBrandCategory;
            value.Title = updateQuestionCommand.Title;
            value.Content = updateQuestionCommand.Content;
            await _questionRepository.UpdateAsync(value);
        }
    }
}