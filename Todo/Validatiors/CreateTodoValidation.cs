using FluentValidation;
using Todo.Dtos;

namespace Todo.Validatiors
{
    public class CreateTodoValidation : AbstractValidator<CreateTodoDto>
    {
        public CreateTodoValidation()
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
