using MediatR;
using School.Core.Bases;

namespace School.Core.Features.SubjectFeatures.Command.Models
{
    public class EditSubjectCommand : IRequest<Response<string>>
    {
        public int SubID { get; set; }
        public string? SubjectName { get; set; }
        public int? Period { get; set; }
    }
}
