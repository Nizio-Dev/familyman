using FluentValidation;

namespace FamilyMan.Application.Dto.Requests;

public class CreateMemberDtoValidator : AbstractValidator<CreateMemberDto>
{
    public CreateMemberDtoValidator()
    {
        RuleFor(x => x.Email)
            .EmailAddress()
            .WithMessage("Incorrect email address format.")
            .NotEmpty()
            .WithMessage("Email address can not be empty.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password can not be empty.");

        RuleFor(x => x.ConfirmPassword)
            .Equal(e => e.Password)
            .WithMessage("Passwords do not match.");
    }    
}