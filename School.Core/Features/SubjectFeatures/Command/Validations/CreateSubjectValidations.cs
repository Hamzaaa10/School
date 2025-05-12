using FluentValidation;
using School.Core.Features.SubjectFeatures.Command.Models;
using School.Service.Abstract;

namespace School.Core.Features.SubjectFeatures.Command.Validations
{
    public class CreateSubjectValidations : AbstractValidator<CreateSubjectCommand>
    {
        private readonly ISubjectService _subjectService;

        public CreateSubjectValidations(ISubjectService subjectService)
        {
            ApplayValidationrules();
            ApplayCustomValidationrules();
            _subjectService = subjectService;
        }
        public void ApplayValidationrules()
        {

            RuleFor(x => x.SubjectName).NotEmpty().NotNull().WithMessage("Subject Name is Requierd");


        }
        public void ApplayCustomValidationrules()
        {
            RuleFor(x => x.SubjectName)
                    .MustAsync(async (key, CancellationToken) => !await _subjectService.IsNameExists(key)).WithMessage("Subject Name is exist");
        }
    }
}
