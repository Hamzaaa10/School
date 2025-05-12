using FluentValidation;
using School.Core.Features.DepartmentFeature.Command.Models;
using School.Service.Abstract;

namespace School.Core.Features.DepartmentFeature.Command.Validations
{
    public class EditDepartmentValidations : AbstractValidator<EditDepartmentCommand>
    {
        private readonly IDepartmentService _departmentService;
        private readonly IInstructorService _instructorService;


        public EditDepartmentValidations(IStudentService studentService, IDepartmentService departmentService, IInstructorService instructorService)
        {
            ApplayValidationrules();
            ApplayCustomValidationrules();
            _departmentService = departmentService;
            _instructorService = instructorService;
        }
        public void ApplayValidationrules()
        {
            RuleFor(x => x.DName).NotEmpty().WithMessage("Department name isrequierd")
                                .NotNull().WithMessage("Department Can't be null ");


        }
        public void ApplayCustomValidationrules()
        {
            RuleFor(x => x.DName)
                    .MustAsync(async (model, key, CancellationToken) => !await _departmentService.IsNameExcludeExists(key, model.DID)).WithMessage("department name is exist");
            RuleFor(x => x.InsManager)
            .MustAsync(async (key, cancellation) =>
                key == null || await _instructorService.GetByIdAsync(key.Value) != null)
            .WithMessage("Instructor Manager does not exist");

        }
    }
}
