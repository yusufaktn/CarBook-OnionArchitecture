using CarBook.Application.Features.CQRS.Command.ServiceCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.ServiceHandlers
{
    public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand>
    {
        private readonly IServiceRepository _serviceRepository;

        public CreateServiceCommandHandler(IServiceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task Handle(CreateServiceCommand createServiceCommand, CancellationToken cancellationToken)
        {
            await _serviceRepository.AddAsync(new Service
            {
                Title = createServiceCommand.Title,
                Description = createServiceCommand.Description,
                IconUrl = createServiceCommand.IconUrl
            });
        }
    }
}