
using FluentValidation;
using School.Core.Features.SubjectFeatures.Command.Models;
using School.Service.Abstract;

namespace School.Core.Features.SubjectFeatures.Command.Validations
{
    public class EditSubjectValidations : AbstractValidator<EditSubjectCommand>
    {
        private readonly ISubjectService _subjectService;

        public EditSubjectValidations(ISubjectService subjectService)
        {
            ApplayValidationrules();
            ApplayCustomValidationrules();
            _subjectService = subjectService;
        }
        public void ApplayValidationrules()
        {

            RuleFor(x => x.SubID).NotEmpty().NotNull().WithMessage("Subject Id is Requierd");
            RuleFor(x => x.SubjectName).NotEmpty().NotNull().WithMessage("Subject Name is Requierd");


        }
        public void ApplayCustomValidationrules()
        {
            RuleFor(x => x.SubjectName)
                    .MustAsync(async (model, key, CancellationToken) => !await _subjectService.IsNameExcludeExists(key, model.SubID)).WithMessage("Subject Name is exist");
        }
    }
}
