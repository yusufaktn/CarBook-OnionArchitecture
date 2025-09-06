using CarBook.Application.Features.CQRS.Command.BannerCommand;
using CarBook.Application.Features.CQRS.Queries.BannerQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers.BannerController
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BannerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetBanner")]
        public async Task<IActionResult> GetListBanner()
        {
            var result = await _mediator.Send(new GetBannerQuery());
            return Ok(result);
        }
        
        [HttpGet("GetBannerById")]
        public async Task<IActionResult> GetListBannerById(int id)
        {
            var result = await _mediator.Send(new GetBannerByIdQuery(id));
            return Ok(result);
        }
        
        [HttpPost("CreateBanner")]
        public async Task<IActionResult> CreateBanner(CreateBannerCommand command)
        {
            await _mediator.Send(command);
            return Ok("Banner oluþturma iþlemi baþarýlý");
        }
        
        [HttpDelete("DeleteBanner")]
        public async Task<IActionResult> DeleteBanner(int id)
        {
            await _mediator.Send(new DeleteBannerCommand(id));
            return Ok("Banner silme iþlemi baþarýlý");
        }
        
        [HttpPut("UpdateBanner")]
        public async Task<IActionResult> UpdateBanner(UpdateBannerCommand command)
        {
            await _mediator.Send(command);
            return Ok("Banner güncelleme iþlemi baþarýlý");
        }
    }
}