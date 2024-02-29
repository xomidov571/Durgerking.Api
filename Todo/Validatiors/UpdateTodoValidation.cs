using FluentValidation;
using Todo.API.Data;
using Todo.Dtos;

namespace Todo.Validatiors
{
    public class UpdateTodoValidation : AbstractValidator<UpdateTodoDto>
    {
        public UpdateTodoValidation(AppDbContext dbContext)
        {
            RuleFor(dto => dto.Title)
                .NotEmpty()
                .MinimumLength(3)
                .MaximumLength(50);

            RuleFor(dto => dto.Description)
                .MaximumLength(250);
        }
    }
}
