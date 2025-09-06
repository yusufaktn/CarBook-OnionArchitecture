using CarBook.Application.Features.CQRS.Command.ContactCommand;
using CarBook.Application.Features.CQRS.Queries.ContactQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers.ContactController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContactController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetContact")]
        public async Task<IActionResult> GetListContact()
        {
            var result = await _mediator.Send(new GetContactQuery());
            return Ok(result);
        }

        [HttpGet("GetContactById")]
        public async Task<IActionResult> GetContactById(int id)
        {
            var result = await _mediator.Send(new GetContactByIdQuery(id));
            return Ok(result);
        }

        [HttpPost("CreateContact")]
        public async Task<IActionResult> CreateContact(CreateContactCommand command)
        {
            await _mediator.Send(command);
            return Ok("�leti�im olu�turma i�lemi ba�ar�l�");
        }

        [HttpDelete("DeleteContact")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            await _mediator.Send(new DeleteContactCommand(id));
            return Ok("�leti�im silme i�lemi ba�ar�l�");
        }

        [HttpPut("UpdateContact")]
        public async Task<IActionResult> UpdateContact(UpdateContactCommand command)
        {
            await _mediator.Send(command);
            return Ok("�leti�im g�ncelleme i�lemi ba�ar�l�");
        }
    }
}