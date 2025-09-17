using CarBook.Application.Features.CQRS.Command.AnswerCommand;
using CarBook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.AnswerHandlers
{
    public class UpdateAnswerCommandHandler : IRequestHandler<UpdateAnswerCommand>
    {
        private readonly IAnswerRepository _answerRepository;

        public UpdateAnswerCommandHandler(IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }

        public async Task Handle(UpdateAnswerCommand updateAnswerCommand, CancellationToken cancellationToken)
        {
            var value = await _answerRepository.GetByIdAsync(updateAnswerCommand.AnswerId);
            value.QuestionId = updateAnswerCommand.QuestionId;
            value.UserId = updateAnswerCommand.UserId;
            value.Content = updateAnswerCommand.Content;
            await _answerRepository.UpdateAsync(value);
        }
    }
}