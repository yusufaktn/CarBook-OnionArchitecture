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
    public class DeleteBrandCommandHandler : IRequestHandler<DeleteBrandCommand>
    {
        private readonly IBrandRepository _brandRepository;
        public DeleteBrandCommandHandler(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task Handle(DeleteBrandCommand deleteBrandCommand, CancellationToken cancellationToken)
        {
            var value = await _brandRepository.GetByIdAsync(deleteBrandCommand.BrandId);
            await _brandRepository.DeleteAsync(value);
        }
    }
}