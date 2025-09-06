using CarBook.Application.Features.CQRS.Results.CarResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Queries.CarQueries
{
    public class GetCarByIdQuery: IRequest<GetCarByIdQueryResult>
    {
        public GetCarByIdQuery(int id)
        {
            CarId = id;
        }

        public int CarId { get; set; }
    }
}