using CarBook.Application.Features.CQRS.Command.ServiceCommand;
using CarBook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ServiceHandlers
{
    public class DeleteServiceCommandHandler : IRequestHandler<DeleteServiceCommand>
    {
        private readonly IServiceRepository _serviceRepository;

        public DeleteServiceCommandHandler(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task Handle(DeleteServiceCommand deleteServiceCommand, CancellationToken cancellationToken)
        {
            var value = await _serviceRepository.GetByIdAsync(deleteServiceCommand.ServiceId);
            await _serviceRepository.DeleteAsync(value);
        }
    }
}