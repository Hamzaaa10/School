using FluentValidation;
using School.Core.Features.Authorization.Command.Modeles;
using School.Service.Abstract;

namespace School.Core.Features.Authorization.Command.Validations
{
    public class DeleteRoleValidations : AbstractValidator<DeleteRoleCommand>
    {
        private readonly IAuthorizationService _authorizationService;

        public DeleteRoleValidations(IAuthorizationService authorizationService)
        {
            ApplayValidationrules();
            _authorizationService = authorizationService;
        }
        public void ApplayValidationrules()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("RoleName isrequierd")
                                .NotNull().WithMessage("RoleName Can't be null");

        }


    }
}
