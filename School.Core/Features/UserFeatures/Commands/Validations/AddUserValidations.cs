using FluentValidation;
using School.Core.Features.UserFeatures.Commands.Modeles;

namespace School.Core.Features.UserFeatures.Commands.Validations
{
    public class AddUserValidations : AbstractValidator<AddUserCommand>
    {
        public AddUserValidations()
        {
            ApplayValidationrules();
            ApplayCustomValidationrules();
        }

        public void ApplayValidationrules()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username is requierd")
                                .MaximumLength(100).WithMessage("max leanth is 100 char").NotNull().WithMessage("FullName can't be nulll");

            RuleFor(x => x.FullName).NotEmpty().WithMessage("Fullname is requierd")
                                    .MaximumLength(100).WithMessage("max leanth is 200 char")
                                    .NotNull().WithMessage("FullName can't be nulll");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is requierd")
                                .NotNull().WithMessage("FullName can't be nulll").EmailAddress();

            RuleFor(x => x.PhoneNumber).Length(11).WithMessage("phone numper must be 11 digts");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is requierd")
                                    .NotNull().WithMessage("Password can't be nulll");



            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).WithMessage("confirmpassword must matches Password ");


        }
        public void ApplayCustomValidationrules()
        {

        }
    }
}

