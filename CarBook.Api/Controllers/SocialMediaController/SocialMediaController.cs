using CarBook.Application.Features.CQRS.Command.SocialMediaCommand;
using CarBook.Application.Features.CQRS.Queries.SocialMediaQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers.SocialMediaController
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SocialMediaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetSocialMedia")]
        public async Task<IActionResult> GetListSocialMedia()
        {
            var result = await _mediator.Send(new GetSocialMediaQuery());
            return Ok(result);
        }

        [HttpGet("GetSocialMediaById")]
        public async Task<IActionResult> GetSocialMediaById(int id)
        {
            var result = await _mediator.Send(new GetSocialMediaByIdQuery(id));
            return Ok(result);
        }

        [HttpPost("CreateSocialMedia")]
        public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaCommand command)
        {
            await _mediator.Send(command);
            return Ok("Sosyal medya oluþturma iþlemi baþarýlý");
        }

        [HttpDelete("DeleteSocialMedia")]
        public async Task<IActionResult> DeleteSocialMedia(int id)
        {
            await _mediator.Send(new DeleteSocialMediaCommand(id));
            return Ok("Sosyal medya silme iþlemi baþarýlý");
        }

        [HttpPut("UpdateSocialMedia")]
        public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaCommand command)
        {
            await _mediator.Send(command);
            return Ok("Sosyal medya güncelleme iþlemi baþarýlý");
        }
    }
}