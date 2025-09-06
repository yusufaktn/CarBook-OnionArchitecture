using CarBook.Application.Features.CQRS.Command.TestimonialCommand;
using CarBook.Application.Features.CQRS.Queries.TestimonialQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers.TestimonialController
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TestimonialController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetTestimonial")]
        public async Task<IActionResult> GetListTestimonial()
        {
            var result = await _mediator.Send(new GetTestimonialQuery());
            return Ok(result);
        }

        [HttpGet("GetTestimonialById")]
        public async Task<IActionResult> GetTestimonialById(int id)
        {
            var result = await _mediator.Send(new GetTestimonialByIdQuery(id));
            return Ok(result);
        }

        [HttpPost("CreateTestimonial")]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialCommand command)
        {
            await _mediator.Send(command);
            return Ok("Referans oluþturma iþlemi baþarýlý");
        }

        [HttpDelete("DeleteTestimonial")]
        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            await _mediator.Send(new DeleteTestimonialCommand(id));
            return Ok("Referans silme iþlemi baþarýlý");
        }

        [HttpPut("UpdateTestimonial")]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialCommand command)
        {
            await _mediator.Send(command);
            return Ok("Referans güncelleme iþlemi baþarýlý");
        }
    }
}