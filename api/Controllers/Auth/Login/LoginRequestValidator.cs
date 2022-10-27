using FluentValidation;

namespace api.Controllers.Auth;

public class LoginRequestValidator : Validator<LoginRequest>
{
    public LoginRequestValidator()
    {
        RuleFor(x => x.username)
        .NotNull().WithMessage("Musisz podać login")
        .MinimumLength(3).WithMessage("Hasło musi mieć minimum 3 znaki")
        .MaximumLength(250).WithMessage("Hasło może mieć maksimum 250 znaków");

        RuleFor(x => x.password)
        .NotNull().WithMessage("Musisz podać hasło")
        .MinimumLength(3).WithMessage("Hasło musi mieć minimum 3 znaki")
        .MaximumLength(250).WithMessage("Hasło może mieć maksimum 250 znaków");
    }
}