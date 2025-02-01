using FluentValidation;
using School.Core.Features.Command.Models;
using School.Service.Abstract;

namespace School.Core.Features.Command.Valedations
{
    public class AddStudentValidator : AbstractValidator<AddStudentCommand>
    {
        private readonly IStudentService _studentService;

        public AddStudentValidator(IStudentService studentService)
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
                    .MustAsync(async (key, CancellationToken) => !await _studentService.IsNameExists(key)).WithMessage("name is exist");
        }
    }
}
