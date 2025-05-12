using FluentValidation;
using School.Core.Features.StudentSubjectFeature.Command.Models;
using School.Service.Abstract;

namespace School.Core.Features.StudentSubjectFeature.Command.Validations
{
    public class AddSubjectToStudentValidations : AbstractValidator<AddSubjectToStudentCommand>
    {
        private readonly IStudentService _studentService;
        private readonly ISubjectService _subjectService;


        public AddSubjectToStudentValidations(IStudentService studentService, ISubjectService subjectService)
        {
            ApplayValidationrules();
            ApplayCustomValidationrules();
            _studentService = studentService;
            _subjectService = subjectService;
        }
        public void ApplayValidationrules()
        {
            RuleFor(x => x.StudentID).NotEmpty().WithMessage("Student ID  is requierd")
                                .NotNull().WithMessage("Student ID Can't be null ");

            RuleFor(x => x.SubjectID).NotEmpty().WithMessage("Subject Id is requierd")
                                .NotNull().WithMessage("Subject Id Can't be null ");


        }
        public void ApplayCustomValidationrules()
        {
            RuleFor(x => x.StudentID)
            .MustAsync(async (key, cancellation) =>
                key == null || await _studentService.GetByIdAsync(key) != null)
            .WithMessage("Department does not exist");

            RuleFor(x => x.SubjectID)
                        .MustAsync(async (key, cancellation) =>
                            key == null || await _subjectService.GetByIdIncludeAsync(key) != null)
                        .WithMessage("Subject does not exist");
        }
    }
}