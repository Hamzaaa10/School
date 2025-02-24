using FluentValidation;
using School.Core.Features.Authorization.Command.Modeles;
using School.Service.Abstract;

namespace School.Core.Features.Authorization.Command.Validations
{
    public class AddRoleValidations : AbstractValidator<AddRoleCommand>
    {
        private readonly IAuthorizationService _authorizationService;

        public AddRoleValidations(IAuthorizationService authorizationService)
        {
            ApplayValidationrules();
            ApplayCustomValidationrules();
            _authorizationService = authorizationService;
        }
        public void ApplayValidationrules()
        {
            RuleFor(x => x.RoleName).NotEmpty().WithMessage("RoleName isrequierd")
                                .NotNull().WithMessage("RoleName Can't be null")
                                .MaximumLength(100).WithMessage("max leanth is 100 char");

        }
        public void ApplayCustomValidationrules()
        {
            RuleFor(x => x.RoleName)
                    .MustAsync(async (key, CancellationToken) => !await _authorizationService.IsRoleExistsByName(key)).WithMessage("Role is exist");


        }
    }
}
