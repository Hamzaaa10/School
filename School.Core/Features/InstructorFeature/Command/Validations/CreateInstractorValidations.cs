using FluentValidation;
using School.Core.Features.InstructorFeature.Command.Models;
using School.Service.Abstract;

namespace School.Core.Features.InstructorFeature.Command.Validations
{
    public class CreateInstractorValidations : AbstractValidator<CreateInstractorCommand>
    {
        private readonly IInstructorService _instractorService;
        private readonly IDepartmentService _departmentService;

        public CreateInstractorValidations(IInstructorService instructorService, IDepartmentService departmentService)
        {
            ApplayValidationrules();
            ApplayCustomValidationrules();
            _instractorService = instructorService;
            _departmentService = departmentService;
        }
        public void ApplayValidationrules()
        {
            RuleFor(x => x.IName).NotEmpty().WithMessage("Instractor name isrequierd")
                                .NotNull().WithMessage("Instractor  Can't be null");
            RuleFor(x => x.DID).NotEmpty().WithMessage("Instractor Department isrequierd")
                                .NotNull().WithMessage("Instractor Department  Can't be null");
            RuleFor(x => x.Salary).NotEmpty().WithMessage("Instractor salary isrequierd")
                                .NotNull().WithMessage("Instractor salary  Can't be null");

        }
        public void ApplayCustomValidationrules()
        {
            RuleFor(x => x.IName)
                    .MustAsync(async (key, CancellationToken) => !await _instractorService.IsNameExists(key)).WithMessage("Instractor name is exist");
            RuleFor(x => x.DID)
                    .MustAsync(async (key, CancellationToken) => await _departmentService.IsDepartmentIdExists(key)).WithMessage("Department is not exist");

        }
    }
}