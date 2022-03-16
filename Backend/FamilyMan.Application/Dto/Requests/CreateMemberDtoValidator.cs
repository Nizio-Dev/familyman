using FluentValidation;

namespace FamilyMan.Application.Dto.Requests;

public class CreateFamilyDtoValidator : AbstractValidator<CreateFamilyDto>
{
    public CreateFamilyDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Email address can not be empty.");
    }  
}