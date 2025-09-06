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
    public class GetAboutQueryHandler:IRequestHandler<GetAboutQuery, List<GetAboutQueryResult>>
    {
        private readonly IAboutRepository _aboutRepository;

        public GetAboutQueryHandler(IAboutRepository aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }

        public async Task<List<GetAboutQueryResult>> Handle(GetAboutQuery getAboutQuery, CancellationToken cancellationToken)
        {
            var values = await _aboutRepository.GetAllAsync();
            return values.Select(x=> new GetAboutQueryResult
            {
                AboutId = x.AboutId,
                Title = x.Title,
                Description = x.Description,
                ImageUrl = x.ImageUrl
            }).ToList();
        }
    }
}
