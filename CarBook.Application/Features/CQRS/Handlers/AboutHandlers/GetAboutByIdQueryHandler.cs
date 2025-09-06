using CarBook.Application.Features.CQRS.Queries.AboutQueries;
using CarBook.Application.Features.CQRS.Results.AboutResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class GetAboutByIdQueryHandler: IRequestHandler<GetAboutByIdQuery, GetAboutByIdQueryResult>
    {
        private readonly IAboutRepository _aboutRepository;
        public GetAboutByIdQueryHandler(IAboutRepository aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }


        public async Task<GetAboutByIdQueryResult> Handle(GetAboutByIdQuery getAboutByIdQuery, CancellationToken cancellationToken)
        {
            var value = await _aboutRepository.GetByIdAsync(getAboutByIdQuery.AboutId);
            return new GetAboutByIdQueryResult
            {
                AboutId = value.AboutId,
                Title = value.Title,
                Description = value.Description,
                ImageUrl = value.ImageUrl
            };
        }
    }
}
