using FluentValidation;
using School.Core.Features.Email.Commands.Models;

namespace School.Core.Features.Email.Commands.Validations
{
    public class SendEmailValidations : AbstractValidator<SendEmailCommand>
    {
        public SendEmailValidations()
        {
            ApplayValidationrules();
            ApplayCustomValidationrules();
        }

        public void ApplayValidationrules()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Username is requierd")
                                .NotNull().WithMessage("FullName can't be nulll");

            RuleFor(x => x.Message).NotEmpty().WithMessage("Password is requierd")
                                    .NotNull().WithMessage("Password can't be nulll");



        }
        public void ApplayCustomValidationrules()
        {

        }

    }
}

