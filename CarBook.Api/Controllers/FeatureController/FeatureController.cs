using CarBook.Application.Features.CQRS.Command.FeatureCommand;
using CarBook.Application.Features.CQRS.Queries.FeatureQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers.FeatureController
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FeatureController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetFeature")]
        public async Task<IActionResult> GetListFeature()
        {
            var result = await _mediator.Send(new GetFeatureQuery());
            return Ok(result);
        }

        [HttpGet("GetFeatureById")]
        public async Task<IActionResult> GetFeatureById(int id)
        {
            var result = await _mediator.Send(new GetFeatureByIdQuery(id));
            return Ok(result);
        }

        [HttpPost("CreateFeature")]
        public async Task<IActionResult> CreateFeature(CreateFeatureCommand command)
        {
            await _mediator.Send(command);
            return Ok("Özellik oluþturma iþlemi baþarýlý");
        }

        [HttpDelete("DeleteFeature")]
        public async Task<IActionResult> DeleteFeature(int id)
        {
            await _mediator.Send(new DeleteFeatureCommand(id));
            return Ok("Özellik silme iþlemi baþarýlý");
        }

        [HttpPut("UpdateFeature")]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureCommand command)
        {
            await _mediator.Send(command);
            return Ok("Özellik güncelleme iþlemi baþarýlý");
        }
    }
}