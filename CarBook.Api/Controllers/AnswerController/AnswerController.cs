using CarBook.Application.Features.CQRS.Command.AnswerCommand;
using CarBook.Application.Features.CQRS.Queries.AnswerQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers.AnswerController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AnswerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAnswer")]
        public async Task<IActionResult> GetListAnswer()
        {
            var result = await _mediator.Send(new GetAnswerQuery());
            return Ok(result);
        }
        [HttpGet("GetAnswerById")]
        public async Task<IActionResult> GetListAnswerById(int id)
        {
            var result = await _mediator.Send(new GetAnswerByIdQuery(id));
            return Ok(result);
        }

        [HttpGet("GetAnswerByQuestionId")]
        public async Task<IActionResult> GetListAnswerByQuestionId(int questionId)
        {
            var result = await _mediator.Send(new GetAnswerByQuestionIdQuery(questionId));
            return Ok(result);
        }

        [HttpPost("CreateAnswer")]
        public async Task<IActionResult> CreateAnswer(CreateAnswerCommand command)
        {
            await _mediator.Send(command);
            return Ok("Answer oluşturma işlemi başarılı");
        }
        [HttpDelete("DeleteAnswer")]
        public async Task<IActionResult> DeleteAnswer(int id)
        {
            await _mediator.Send(new DeleteAnswerCommand(id));
            return Ok("Answer silme işlemi başarılı");
        }
        [HttpPut("UpdateAnswer")]
        public async Task<IActionResult> UpdateAnswer(UpdateAnswerCommand command)
        {
            await _mediator.Send(command);
            return Ok("Answer güncelleme işlemi başarılı");
        }
    }
}