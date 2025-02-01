using FluentValidation;
using School.Core.Features.Command.Models;
using School.Service.Abstract;

namespace School.Core.Features.Command.Valedations
{
    public class EditStudentValidator : AbstractValidator<EditStudentCommand>
    {
        private readonly IStudentService _studentService;

        public EditStudentValidator(IStudentService studentService)
        {
            ApplayValidationrules();
            ApplayCustomValidationrules();
            this._studentService = studentService;
        }
        public void ApplayValidationrules()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("name isrequierd")
                                .MaximumLength(100).WithMessage("max leanth is 100 char");
            RuleFor(x => x.Phone).MaximumLength(11).WithMessage("num has only 11 num ");
        }
        public void ApplayCustomValidationrules()
        {
            RuleFor(x => x.Name)
                    .MustAsync(async (model, key, CancellationToken) => !await _studentService.IsNameExcludeExists(key, model.ID)).WithMessage("name is exist");
        }
    }

}

