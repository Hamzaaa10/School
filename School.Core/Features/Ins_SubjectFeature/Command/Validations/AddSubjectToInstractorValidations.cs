using FluentValidation;
using School.Core.Features.Ins_SubjectFeature.Command.Models;
using School.Service.Abstract;

namespace School.Core.Features.Ins_SubjectFeature.Command.Validations
{
    internal class AddSubjectToInstractorValidations : AbstractValidator<AddSubjectToInstractorCommand>
    {
        private readonly IInstructorService _instructorService;
        private readonly ISubjectService _subjectService;


        public AddSubjectToInstractorValidations(IInstructorService instructorService, ISubjectService subjectService)
        {
            ApplayValidationrules();
            ApplayCustomValidationrules();
            _subjectService = subjectService;
            _instructorService = instructorService;
        }
        public void ApplayValidationrules()
        {
            RuleFor(x => x.InstractorId).NotEmpty().WithMessage("InstractorId is requierd")
                                .NotNull().WithMessage("InstractorIdCan't be null ");

            RuleFor(x => x.SubjectId).NotEmpty().WithMessage("Subject Id is requierd")
                                .NotNull().WithMessage("Subject Id Can't be null ");


        }
        public void ApplayCustomValidationrules()
        {
            RuleFor(x => x.InstractorId)
            .MustAsync(async (key, cancellation) =>
                key == null || await _instructorService.GetByIdIncludeAsync(key) != null)
            .WithMessage("Instractor With this Id does not exist");

            RuleFor(x => x.SubjectId)
                        .MustAsync(async (key, cancellation) =>
                            key == null || await _subjectService.GetByIdIncludeAsync(key) != null)
                        .WithMessage("Subject with this id does not exist");
        }
    }
}