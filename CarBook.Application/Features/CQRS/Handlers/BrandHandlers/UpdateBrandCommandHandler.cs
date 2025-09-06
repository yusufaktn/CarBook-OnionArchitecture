using CarBook.Application.Features.CQRS.Command.BrandCommand;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.BrandHandlers
{
    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand>
    {
        private readonly IBrandRepository _brandRepository;

        public UpdateBrandCommandHandler(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task Handle(UpdateBrandCommand updateBrandCommand, CancellationToken cancellationToken)
        {
            var value = await _brandRepository.GetByIdAsync(updateBrandCommand.BrandId);
            value.Name = updateBrandCommand.Name;
            await _brandRepository.UpdateAsync(value);
        }
    }
}