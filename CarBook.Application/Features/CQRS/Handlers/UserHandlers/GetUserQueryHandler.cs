using CarBook.Application.Features.CQRS.Queries.UserQueries;
using CarBook.Application.Features.CQRS.Results.UserResults;
using CarBook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.UserHandlers
{
    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, List<GetUserQueryResult>>
    {
        private readonly IUserRepository _userRepository;

        public GetUserQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<GetUserQueryResult>> Handle(GetUserQuery getUserQuery, CancellationToken cancellationToken)
        {
            var values = await _userRepository.GetAllAsync();
            return values.Select(x => new GetUserQueryResult
            {
                UserId = x.UserId,
                UserName = x.UserName,
                UserLastName = x.UserLastName,
                Email = x.Email,
                ProfileImageUrl = x.ProfileImageUrl
            }).ToList();
        }
    }
}