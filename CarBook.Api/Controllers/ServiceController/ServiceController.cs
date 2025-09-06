using CarBook.Application.Features.CQRS.Command.ServiceCommand;
using CarBook.Application.Features.CQRS.Queries.ServiceQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers.ServiceController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ServiceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetService")]
        public async Task<IActionResult> GetListService()
        {
            var result = await _mediator.Send(new GetServiceQuery());
            return Ok(result);
        }

        [HttpGet("GetServiceById")]
        public async Task<IActionResult> GetServiceById(int id)
        {
            var result = await _mediator.Send(new GetServiceByIdQuery(id));
            return Ok(result);
        }

        [HttpPost("CreateService")]
        public async Task<IActionResult> CreateService(CreateServiceCommand command)
        {
            await _mediator.Send(command);
            return Ok("Hizmet oluþturma iþlemi baþarýlý");
        }

        [HttpDelete("DeleteService")]
        public async Task<IActionResult> DeleteService(int id)
        {
            await _mediator.Send(new DeleteServiceCommand(id));
            return Ok("Hizmet silme iþlemi baþarýlý");
        }

        [HttpPut("UpdateService")]
        public async Task<IActionResult> UpdateService(UpdateServiceCommand command)
        {
            await _mediator.Send(command);
            return Ok("Hizmet güncelleme iþlemi baþarýlý");
        }
    }
}