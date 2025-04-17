using FluentValidation;
using ToDolist.Bll.Dtos;

namespace ToDolist.Bll.Validators;

public class ToDoItemCreateDtoValidator : AbstractValidator<ToDoItemCreateDto>
{
    public ToDoItemCreateDtoValidator()
    {
        RuleFor(x => x.Title)
         .NotEmpty().WithMessage("Title bo'sh bo'lishi mumkin emas.")
         .MaximumLength(50).WithMessage("Title 50 ta belgidan oshmasligi kerak.");

        RuleFor(x => x.Description)
            .MaximumLength(150).WithMessage("Description 150 ta belgidan oshmasligi kerak.");

        RuleFor(x => x.CreatedAt)
            .LessThanOrEqualTo(DateTime.UtcNow)
            .WithMessage("CreatedAt hozirgi vaqtdan keyin bo'lishi mumkin emas.");

        RuleFor(x => x.DueDate)
            .GreaterThan(x => x.CreatedAt)
            .WithMessage("DueDate CreatedAt dan keyin bo'lishi kerak.");

        RuleFor(x => x.IsCompleted)
            .NotNull().WithMessage("IsComplited qiymati bo'lishi kerak.");
    }
}
