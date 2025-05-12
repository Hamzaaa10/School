using FluentValidation;
using School.Core.Features.InstructorFeature.Command.Models;
using School.Service.Abstract;

namespace School.Core.Features.InstructorFeature.Command.Validations
{
    internal class EditInstractorValidator : AbstractValidator<EditInstractorCommand>
    {
        private readonly IInstructorService _instractorService;
        private readonly IDepartmentService _departmentService;

        public EditInstractorValidator(IInstructorService instructorService, IDepartmentService departmentService)
        {
            ApplayValidationrules();
            ApplayCustomValidationrules();
            _instractorService = instructorService;
            _departmentService = departmentService;
        }
        public void ApplayValidationrules()
        {
            RuleFor(x => x.InsId).NotEmpty().WithMessage("Instractor Id isrequierd")
                                .NotNull().WithMessage("Instractor Id  Can't be null");
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
                    .MustAsync(async (model, key, CancellationToken) => !await _instractorService.IsNameExcludeExists(key, model.InsId)).WithMessage("name is exist");
            RuleFor(x => x.DID)
                    .MustAsync(async (key, CancellationToken) => await _departmentService.IsDepartmentIdExists(key)).WithMessage("Department is not exist");

        }
    }

}
