using CarBook.Application.Features.CQRS.Command.CarCommand;
using CarBook.Application.Features.CQRS.Queries.CarQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers.CarController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CarController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetCar")]
        public async Task<IActionResult> GetListCar()
        {
            var result = await _mediator.Send(new GetCarQuery());
            return Ok(result);
        }
        
        [HttpGet("GetCarById")]
        public async Task<IActionResult> GetCarById(int id)
        {
            var result = await _mediator.Send(new GetCarByIdQuery(id));
            return Ok(result);
        }
        
        [HttpGet("GetCarWithBrand")]
        public async Task<IActionResult> GetCarWithBrand()
        {
            var result = await _mediator.Send(new GetCarWithBrandQuery());
            return Ok(result);
        }
        
        [HttpPost("CreateCar")]
        public async Task<IActionResult> CreateCar(CreateCarCommand command)
        {
            await _mediator.Send(command);
            return Ok("Araç oluþturma iþlemi baþarýlý");
        }
        
        [HttpDelete("DeleteCar")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            await _mediator.Send(new DeleteCarCommand(id));
            return Ok("Araç silme iþlemi baþarýlý");
        }
        
        [HttpPut("UpdateCar")]
        public async Task<IActionResult> UpdateCar(UpdateCarCommand command)
        {
            await _mediator.Send(command);
            return Ok("Araç güncelleme iþlemi baþarýlý");
        }
    }
}