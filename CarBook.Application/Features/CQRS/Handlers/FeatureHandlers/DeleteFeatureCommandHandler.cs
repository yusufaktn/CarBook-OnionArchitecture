using CarBook.Application.Features.CQRS.Command.FeatureCommand;
using CarBook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.FeatureHandlers
{
    public class DeleteFeatureCommandHandler : IRequestHandler<DeleteFeatureCommand>
    {
        private readonly IFeatureRepository _featureRepository;

        public DeleteFeatureCommandHandler(IFeatureRepository featureRepository)
        {
            _featureRepository = featureRepository;
        }

        public async Task Handle(DeleteFeatureCommand deleteFeatureCommand, CancellationToken cancellationToken)
        {
            var value = await _featureRepository.GetByIdAsync(deleteFeatureCommand.FeatureId);
            await _featureRepository.DeleteAsync(value);
        }
    }
}