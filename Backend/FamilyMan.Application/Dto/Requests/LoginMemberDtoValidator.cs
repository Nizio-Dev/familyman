using FluentValidation;

namespace FamilyMan.Application.Dto.Requests;

public class LoginMemberDtoValidator : AbstractValidator<LoginMemberDto>
{
    public LoginMemberDtoValidator()
    {
        RuleFor(x => x.Email)
            .EmailAddress()
            .WithMessage("Incorrect email address format.")
            .NotEmpty()
            .WithMessage("Email address can not be empty.");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password can not be empty.");
    }
}