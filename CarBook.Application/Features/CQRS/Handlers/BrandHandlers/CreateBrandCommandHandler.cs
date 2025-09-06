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
    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand>
    {
        private readonly IBrandRepository _brandRepository;

        public CreateBrandCommandHandler(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task Handle(CreateBrandCommand createBrandCommand, CancellationToken cancellationToken)
        {
            await _brandRepository.AddAsync(new Brand
            {
                Name = createBrandCommand.Name
            });
        }
    }
}