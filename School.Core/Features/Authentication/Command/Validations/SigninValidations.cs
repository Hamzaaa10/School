using FluentValidation;
using School.Core.Features.Authentication.Command.Models;

namespace School.Core.Features.Authentication.Command.Validations
{
    public class SigninValidations : AbstractValidator<SignInCommand>
    {
        public SigninValidations()
        {
            ApplayValidationrules();
            ApplayCustomValidationrules();
        }

        public void ApplayValidationrules()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username is requierd")
                                .NotNull().WithMessage("FullName can't be nulll");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is requierd")
                                    .NotNull().WithMessage("Password can't be nulll");



        }
        public void ApplayCustomValidationrules()
        {

        }

    }
}
