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
    public class DeleteQuestionCommandHandler : IRequestHandler<DeleteQuestionCommand>
    {
        private readonly IQuestionRepository _questionRepository;

        public DeleteQuestionCommandHandler(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task Handle(DeleteQuestionCommand deleteQuestionCommand, CancellationToken cancellationToken)
        {
            var value = await _questionRepository.GetByIdAsync(deleteQuestionCommand.QuestionId);
            await _questionRepository.DeleteAsync(value);
        }
    }
}