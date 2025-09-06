using CarBook.Application.Features.CQRS.Command.LocationCommand;
using CarBook.Application.Features.CQRS.Queries.LocationQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers.LocationController
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LocationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetLocation")]
        public async Task<IActionResult> GetListLocation()
        {
            var result = await _mediator.Send(new GetLocationQuery());
            return Ok(result);
        }

        [HttpGet("GetLocationById")]
        public async Task<IActionResult> GetLocationById(int id)
        {
            var result = await _mediator.Send(new GetLocationByIdQuery(id));
            return Ok(result);
        }

        [HttpPost("CreateLocation")]
        public async Task<IActionResult> CreateLocation(CreateLocationCommand command)
        {
            await _mediator.Send(command);
            return Ok("Lokasyon olu�turma i�lemi ba�ar�l�");
        }

        [HttpDelete("DeleteLocation")]
        public async Task<IActionResult> DeleteLocation(int id)
        {
            await _mediator.Send(new DeleteLocationCommand(id));
            return Ok("Lokasyon silme i�lemi ba�ar�l�");
        }

        [HttpPut("UpdateLocation")]
        public async Task<IActionResult> UpdateLocation(UpdateLocationCommand command)
        {
            await _mediator.Send(command);
            return Ok("Lokasyon g�ncelleme i�lemi ba�ar�l�");
        }
    }
}