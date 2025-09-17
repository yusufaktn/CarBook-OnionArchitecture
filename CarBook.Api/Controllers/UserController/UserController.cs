using CarBook.Application.Features.CQRS.Command.UserCommand;
using CarBook.Application.Features.CQRS.Queries.UserQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers.UserController
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetUser")]
        public async Task<IActionResult> GetListUser()
        {
            var result = await _mediator.Send(new GetUserQuery());
            return Ok(result);
        }
        [HttpGet("GetUserById")]
        public async Task<IActionResult> GetListUserById(int id)
        {
            var result = await _mediator.Send(new GetUserByIdQuery(id));
            return Ok(result);
        }
        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser(CreateUserCommand command)
        {
            await _mediator.Send(command);
            return Ok("User oluşturma işlemi başarılı");
        }
        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _mediator.Send(new DeleteUserCommand(id));
            return Ok("User silme işlemi başarılı");
        }
        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UpdateUserCommand command)
        {
            await _mediator.Send(command);
            return Ok("User güncelleme işlemi başarılı");
        }
    }
}