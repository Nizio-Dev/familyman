using FamilyMan.Core.Enums;
using FluentValidation;

namespace FamilyMan.Application.Dto.Requests;

public class CreateTodoDtoValidator : AbstractValidator<CreateTodoDto>
{
    public CreateTodoDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Todo's name can not be empty.");

        RuleFor(x => x.Priority)
            .IsInEnum()
            .WithMessage("Incorrect todo priority.");
    }    
}