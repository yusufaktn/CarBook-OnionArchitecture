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
    public class DeleteAnswerCommandHandler : IRequestHandler<DeleteAnswerCommand>
    {
        private readonly IAnswerRepository _answerRepository;

        public DeleteAnswerCommandHandler(IAnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }

        public async Task Handle(DeleteAnswerCommand deleteAnswerCommand, CancellationToken cancellationToken)
        {
            var value = await _answerRepository.GetByIdAsync(deleteAnswerCommand.AnswerId);
            await _answerRepository.DeleteAsync(value);
        }
    }
}