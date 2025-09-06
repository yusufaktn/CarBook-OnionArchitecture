using CarBook.Application.Features.CQRS.Command.BrandCommand;
using CarBook.Application.Features.CQRS.Queries.BrandQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers.BrandController
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BrandController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetBrand")]
        public async Task<IActionResult> GetListBrand()
        {
            var result = await _mediator.Send(new GetBrandQuery());
            return Ok(result);
        }
        
        [HttpGet("GetBrandById")]
        public async Task<IActionResult> GetBrandById(int id)
        {
            var result = await _mediator.Send(new GetBrandByIdQuery(id));
            return Ok(result);
        }
        
        [HttpPost("CreateBrand")]
        public async Task<IActionResult> CreateBrand(CreateBrandCommand command)
        {
            await _mediator.Send(command);
            return Ok("Marka oluþturma iþlemi baþarýlý");
        }
        
        [HttpDelete("DeleteBrand")]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            await _mediator.Send(new DeleteBrandCommand(id));
            return Ok("Marka silme iþlemi baþarýlý");
        }
        
        [HttpPut("UpdateBrand")]
        public async Task<IActionResult> UpdateBrand(UpdateBrandCommand command)
        {
            await _mediator.Send(command);
            return Ok("Marka güncelleme iþlemi baþarýlý");
        }
    }
}