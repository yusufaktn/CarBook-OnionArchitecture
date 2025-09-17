using CarBook.Application.Features.CQRS.Command.QuestionCommand;
using CarBook.Application.Features.CQRS.Queries.QuestionQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers.QuestionController
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IMediator _mediator;
        public QuestionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetQuestion")]
        public async Task<IActionResult> GetListQuestion()
        {
            var result = await _mediator.Send(new GetQuestionQuery());
            return Ok(result);
        }
        [HttpGet("GetQuestionById")]
        public async Task<IActionResult> GetListQuestionById(int id)
        {
            var result = await _mediator.Send(new GetQuestionByIdQuery(id));
            return Ok(result);
        }
        [HttpGet("GetLastThreeQuestions")]
        public async Task<IActionResult> GetLastThreeQuestions()
        {
            var result = await _mediator.Send(new GetLastThreeQuestionsQuery());
            return Ok(result);
        }
        [HttpPost("CreateQuestion")]
        public async Task<IActionResult> CreateQuestion(CreateQuestionCommand command)
        {
            await _mediator.Send(command);
            return Ok("Question oluşturma işlemi başarılı");
        }
        [HttpDelete("DeleteQuestion")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            await _mediator.Send(new DeleteQuestionCommand(id));
            return Ok("Question silme işlemi başarılı");
        }
        [HttpPut("UpdateQuestion")]
        public async Task<IActionResult> UpdateQuestion(UpdateQuestionCommand command)
        {
            await _mediator.Send(command);
            return Ok("Question güncelleme işlemi başarılı");
        }
    }
}