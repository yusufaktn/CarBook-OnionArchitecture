using CarBook.Application.Features.CQRS.Command.AboutCommand;
using CarBook.Application.Features.CQRS.Queries.AboutQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers.AboutController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AboutController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAbout")]
        public async Task<IActionResult> GetListAbout()
        {
            var result = await _mediator.Send(new GetAboutQuery());
            return Ok(result);
        }
        [HttpGet("GetAboutById")]
        public async Task<IActionResult> GetListAboutById(int id)
        {
            var result = await _mediator.Send(new GetAboutByIdQuery(id));
            return Ok(result);
        }
        [HttpPost("CreateAbout")]
        public async Task<IActionResult> CreateAbout(CreateAboutCommand command)
        {
            await _mediator.Send(command);
            return Ok("About oluşturma işlemi başarılı");
        }
        [HttpDelete("DeleteAbout")]
        public async Task<IActionResult> DeleteAbout(int id)
        {
            await _mediator.Send(new DeleteAboutCommand(id));
            return Ok("About silme işlemi başarılı");
        }
        [HttpPut("UpdateAbout")]
        public async Task<IActionResult> UpdateAbout(UpdateAboutCommand command)
        {
            await _mediator.Send(command);
            return Ok("About güncelleme işlemi başarılı");
        }



    }
}
