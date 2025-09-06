using CarBook.Application.Features.CQRS.Command.PricingCommand;
using CarBook.Application.Features.CQRS.Queries.PricingQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers.PricingController
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PricingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetPricing")]
        public async Task<IActionResult> GetListPricing()
        {
            var result = await _mediator.Send(new GetPricingQuery());
            return Ok(result);
        }

        [HttpGet("GetPricingById")]
        public async Task<IActionResult> GetPricingById(int id)
        {
            var result = await _mediator.Send(new GetPricingByIdQuery(id));
            return Ok(result);
        }

        [HttpPost("CreatePricing")]
        public async Task<IActionResult> CreatePricing(CreatePricingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Fiyatland�rma olu�turma i�lemi ba�ar�l�");
        }

        [HttpDelete("DeletePricing")]
        public async Task<IActionResult> DeletePricing(int id)
        {
            await _mediator.Send(new DeletePricingCommand(id));
            return Ok("Fiyatland�rma silme i�lemi ba�ar�l�");
        }

        [HttpPut("UpdatePricing")]
        public async Task<IActionResult> UpdatePricing(UpdatePricingCommand command)
        {
            await _mediator.Send(command);
            return Ok("Fiyatland�rma g�ncelleme i�lemi ba�ar�l�");
        }
    }
}