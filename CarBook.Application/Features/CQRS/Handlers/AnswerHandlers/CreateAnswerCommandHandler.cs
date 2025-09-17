using CarBook.Application.Features.CQRS.Command.AnswerCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.AnswerHandlers
{
    public class CreateAnswerCommandHandler : IRequestHandler<CreateAnswerCommand>
    {
        private readonly IAnswerRepository _answerRepository;

        public CreateAnswerCommandHandler(IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }

        public async Task Handle(CreateAnswerCommand createAnswerCommand, CancellationToken cancellationToken)
        {
            await _answerRepository.AddAsync(new Answer
            {
                QuestionId = createAnswerCommand.QuestionId,
                UserId = createAnswerCommand.UserId,
                Content = createAnswerCommand.Content
            });
        }
    }
}