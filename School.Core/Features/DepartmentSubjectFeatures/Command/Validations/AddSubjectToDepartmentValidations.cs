using FluentValidation;
using School.Core.Features.DepartmentSubjectFeatures.Command.Requests;
using School.Service.Abstract;

namespace School.Core.Features.DepartmentSubjectFeatures.Command.Validations
{
    public class AddSubjectToDepartmentValidations : AbstractValidator<AddSubjectToDepartmentCommand>
    {
        private readonly IDepartmentService _departmentService;
        private readonly ISubjectService _subjectService;


        public AddSubjectToDepartmentValidations(IDepartmentService departmentService, ISubjectService subjectService)
        {
            ApplayValidationrules();
            ApplayCustomValidationrules();
            _departmentService = departmentService;
            _subjectService = subjectService;
        }
        public void ApplayValidationrules()
        {
            RuleFor(x => x.DepartmentID).NotEmpty().WithMessage("Department Id is requierd")
                                .NotNull().WithMessage("Department Id Can't be null ");

            RuleFor(x => x.SubjectID).NotEmpty().WithMessage("Subject Id is requierd")
                                .NotNull().WithMessage("Subject Id Can't be null ");


        }
        public void ApplayCustomValidationrules()
        {
            RuleFor(x => x.DepartmentID)
            .MustAsync(async (key, cancellation) =>
                key == null || await _departmentService.GetDepartmentByIdAsync(key) != null)
            .WithMessage("Department does not exist");

            RuleFor(x => x.SubjectID)
                        .MustAsync(async (key, cancellation) =>
                            key == null || await _subjectService.GetByIdIncludeAsync(key) != null)
                        .WithMessage("Subject does not exist");
        }
    }
}