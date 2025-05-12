using MediatR;
using School.Core.Bases;

namespace School.Core.Features.SubjectFeatures.Command.Models
{
    public class CreateSubjectCommand : IRequest<Response<string>>
    {
        public string SubjectName { get; set; }
        public int? Period { get; set; }
    }
}
