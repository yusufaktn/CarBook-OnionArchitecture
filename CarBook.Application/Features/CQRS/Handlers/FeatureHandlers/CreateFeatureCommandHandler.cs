using CarBook.Application.Features.CQRS.Command.FeatureCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.FeatureHandlers
{
    public class CreateFeatureCommandHandler : IRequestHandler<CreateFeatureCommand>
    {
        private readonly IFeatureRepository _featureRepository;

        public CreateFeatureCommandHandler(IFeatureRepository featureRepository)
        {
            _featureRepository = featureRepository;
        }

        public async Task Handle(CreateFeatureCommand createFeatureCommand, CancellationToken cancellationToken)
        {
            await _featureRepository.AddAsync(new Feature
            {
                Name = createFeatureCommand.Name
            });
        }
    }
}