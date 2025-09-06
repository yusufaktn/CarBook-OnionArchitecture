using CarBook.Application.Features.CQRS.Command.CategoryCommand;
using CarBook.Application.Features.CQRS.Queries.CategoryQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.Api.Controllers.CategoryController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet("GetCategory")]
        public async Task<IActionResult> GetListCategory()
        {
            var result = await _mediator.Send(new GetCategoryQuery());
            return Ok(result);
        }
        [HttpGet("GetCategoryById")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var result = await _mediator.Send(new GetCategoryByIdQuery(id));
            return Ok(result);
        }
        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand createCategoryCommand)
        {
             await _mediator.Send(createCategoryCommand);
            return Ok("Kategori oluşturma işlemi başarılı");
        }
        [HttpDelete("DeleteCategory")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _mediator.Send(new DeleteCategoryCommand(id));
            return Ok("Kategori silme işlemi başarılı");
        }
        [HttpPut("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand updateCategoryCommand)
        {
            await _mediator.Send(updateCategoryCommand);
            return Ok("Kategori güncelleme işlemi başarılı");
        }
    }
}
