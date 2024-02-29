using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todo.Dtos;
using Todo.Services;

namespace Todo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ITodoService service;

        public TodoController(ITodoService service)
        {
            this.service = service;
        }
        [HttpGet("/")]
        public async Task<IActionResult> GetTodosAsnys() 
            => Ok(await service.GetTodosAsync());

        [HttpGet("todo/{id}")]
        public async Task<IActionResult> GetTodoAsync([FromRoute] Guid id)
        {
            var request = await service.GetTodoAsync(id);

            if (request is null) 
                return BadRequest("Todo is null");

            return Ok(request);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTodoAsync([FromBody] CreateTodoDto newTodo)
        {
            try
            {
                var request = await service.CreateTodoAsync(newTodo);
                return Ok(request);
            }
            catch (Exception ex)
            {
                return NotFound($"not found: {ex}");
            }
        }
        [HttpPut("Updated/{id}")]
        public async Task<IActionResult> UpdateTodoAsync(
            [FromRoute] Guid id,
            UpdateTodoDto newTodo)
        {
            return Ok(await service.UpdateTodoAsync(id, newTodo));
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteTodoAsync([FromRoute] Guid id)
            => Ok(await service?.DeleteTodoAsync(id));
    }
}
