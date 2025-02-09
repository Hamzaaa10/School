using FluentValidation;
using School.Core.Features.StudentFeatures.Command.Models;
using School.Service.Abstract;

namespace School.Core.Features.StudentFeatures.Command.Valedations
{
    public class AddStudentValidator : AbstractValidator<AddStudentCommand>
    {
        private readonly IStudentService _studentService;
        private readonly IDepartmentService _departmentService;

        public AddStudentValidator(IStudentService studentService, IDepartmentService departmentService)
        {
            ApplayValidationrules();
            ApplayCustomValidationrules();
            _studentService = studentService;
            _departmentService = departmentService;
        }
        public void ApplayValidationrules()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("name isrequierd")
                                .MaximumLength(100).WithMessage("max leanth is 100 char");
            RuleFor(x => x.Phone).MaximumLength(11).WithMessage("num has only 11 num ");
            RuleFor(x => x.DepartmentId).NotEmpty().NotNull().WithMessage("Department Id is Requierd");

        }
        public void ApplayCustomValidationrules()
        {
            RuleFor(x => x.Name)
                    .MustAsync(async (key, CancellationToken) => !await _studentService.IsNameExists(key)).WithMessage("name is exist");
            RuleFor(x => x.DepartmentId)
                    .MustAsync(async (key, CancellationToken) => await _departmentService.IsDepartmentIdExists(key)).WithMessage("Department is not exist");

        }
    }
}
