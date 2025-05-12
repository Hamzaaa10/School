using MediatR;
using School.Core.Bases;

namespace School.Core.Features.Ins_SubjectFeature.Command.Models
{
    public class AddSubjectToInstractorCommand : IRequest<Response<string>>
    {
        public int InstractorId { get; set; }
        public int SubjectId { get; set; }
    }
}
