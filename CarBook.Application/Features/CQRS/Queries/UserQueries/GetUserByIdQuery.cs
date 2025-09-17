using CarBook.Application.Features.CQRS.Results.UserResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Queries.UserQueries
{
    public class GetUserByIdQuery : IRequest<GetUserByIdQueryResult>
    {
        public GetUserByIdQuery(int id)
        {
            UserId = id;
        }
        public int UserId { get; set; }
    }
}