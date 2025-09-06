using CarBook.Application.Features.CQRS.Command.FooterAddressCommand;
using CarBook.Application.Features.CQRS.Queries.FooterAddressQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers.FooterAddressController
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterAddressController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FooterAddressController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetFooterAddress")]
        public async Task<IActionResult> GetListFooterAddress()
        {
            var result = await _mediator.Send(new GetFooterAddressQuery());
            return Ok(result);
        }

        [HttpGet("GetFooterAddressById")]
        public async Task<IActionResult> GetFooterAddressById(int id)
        {
            var result = await _mediator.Send(new GetFooterAddressByIdQuery(id));
            return Ok(result);
        }

        [HttpPost("CreateFooterAddress")]
        public async Task<IActionResult> CreateFooterAddress(CreateFooterAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok("Footer adres oluþturma iþlemi baþarýlý");
        }

        [HttpDelete("DeleteFooterAddress")]
        public async Task<IActionResult> DeleteFooterAddress(int id)
        {
            await _mediator.Send(new DeleteFooterAddressCommand(id));
            return Ok("Footer adres silme iþlemi baþarýlý");
        }

        [HttpPut("UpdateFooterAddress")]
        public async Task<IActionResult> UpdateFooterAddress(UpdateFooterAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok("Footer adres güncelleme iþlemi baþarýlý");
        }
    }
}