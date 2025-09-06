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
    public class UpdateFeatureCommandHandler : IRequestHandler<UpdateFeatureCommand>
    {
        private readonly IFeatureRepository _featureRepository;

        public UpdateFeatureCommandHandler(IFeatureRepository featureRepository)
        {
            _featureRepository = featureRepository;
        }

        public async Task Handle(UpdateFeatureCommand updateFeatureCommand, CancellationToken cancellationToken)
        {
            var value = await _featureRepository.GetByIdAsync(updateFeatureCommand.FeatureId);
            value.Name = updateFeatureCommand.Name;
            await _featureRepository.UpdateAsync(value);
        }
    }
}