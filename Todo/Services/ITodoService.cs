using Todo.Dtos;
using Todo.entity;

namespace Todo.Services
{
    public interface ITodoService
    {
        Task<List<TodoModel>> GetTodosAsync();
        Task<TodoModel> GetTodoAsync(Guid id);
        Task<TodoModel> CreateTodoAsync(CreateTodoDto newTodo);
        Task<TodoModel> UpdateTodoAsync(Guid id, UpdateTodoDto update);
        Task<bool> DeleteTodoAsync(Guid id);
    }
}
