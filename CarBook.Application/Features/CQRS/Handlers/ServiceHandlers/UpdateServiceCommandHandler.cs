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
    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand>
    {
        private readonly IServiceRepository _serviceRepository;

        public UpdateServiceCommandHandler(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task Handle(UpdateServiceCommand updateServiceCommand, CancellationToken cancellationToken)
        {
            var value = await _serviceRepository.GetByIdAsync(updateServiceCommand.ServiceId);
            value.Title = updateServiceCommand.Title;
            value.Description = updateServiceCommand.Description;
            value.IconUrl = updateServiceCommand.IconUrl;
            await _serviceRepository.UpdateAsync(value);
        }
    }
}