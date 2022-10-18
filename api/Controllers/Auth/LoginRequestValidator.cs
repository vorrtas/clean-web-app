using FluentValidation;

namespace api.Controllers.Auth;

public class LoginRequestValidator : Validator<LoginRequest>
{
    public LoginRequestValidator()
    {
        RuleFor(x => x.username)
        .NotNull()
        .MinimumLength(3)
        .MaximumLength(250);

        RuleFor(x => x.password)
        .NotNull().WithMessage("Musisz podać hasło")
        .MinimumLength(3).WithMessage("Hasło musi mieć minimum 3 znaki")
        .MaximumLength(250).WithMessage("Hasło musi mieć maksimum 250 znaki")
        .Matches(@"^[\S]{ 3,250}$").WithMessage("Hasło nie może zawierać znaków niedozwolonych");


    }
}