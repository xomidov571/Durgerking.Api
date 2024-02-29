using FluentValidation;
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
        private readonly IValidator<CreateTodoDto> createValidator;
        private readonly IValidator<UpdateTodoDto> updateValidator;

        public TodoController(
            ITodoService service,
            IValidator<CreateTodoDto> createValidator, 
            IValidator<UpdateTodoDto> updateValidator)
        {
            this.service = service;
            this.createValidator = createValidator;
            this.updateValidator = updateValidator;
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

        [HttpPost("Created")]
        public async Task<IActionResult> CreateTodoAsync([FromBody] CreateTodoDto newTodo)
        {
            try
            {
                var validationResult = await createValidator.ValidateAsync(newTodo);

                if (!validationResult.IsValid)
                    return Ok(validationResult.Errors);

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
            var validatiponResult = await updateValidator.ValidateAsync(newTodo);
            if (!validatiponResult.IsValid)
                return Ok(validatiponResult.Errors);

            var response = await service.UpdateTodoAsync(id, newTodo);
            return Ok(response);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteTodoAsync([FromRoute] Guid id)
            => Ok(await service?.DeleteTodoAsync(id));
    }
}
