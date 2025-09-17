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
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, GetUserByIdQueryResult>
    {
        private readonly IUserRepository _userRepository;

        public GetUserByIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GetUserByIdQueryResult> Handle(GetUserByIdQuery getUserByIdQuery, CancellationToken cancellationToken)
        {
            var value = await _userRepository.GetByIdAsync(getUserByIdQuery.UserId);
            return new GetUserByIdQueryResult
            {
                UserId = value.UserId,
                UserName = value.UserName,
                UserLastName = value.UserLastName,
                Email = value.Email,
                ProfileImageUrl = value.ProfileImageUrl
            };
        }
    }
}