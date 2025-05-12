using FluentValidation;
using School.Core.Features.Authentication.Command.Models;

namespace School.Core.Features.Authentication.Command.Validations
{
    public class ResetPasswordValidations : AbstractValidator<ResetPasswordCommand>
    {
        public ResetPasswordValidations()
        {
            ApplayValidationrules();
            ApplayCustomValidationrules();
        }

        public void ApplayValidationrules()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Username is requierd")
                                .NotNull().WithMessage("FullName can't be nulll");

        }
        public void ApplayCustomValidationrules()
        {

        }

    }
}
