using MediatR;
using School.Core.Bases;

namespace School.Core.Features.Ins_SubjectFeature.Command.Models
{
    public class DeleteIns_SubjectCommand : IRequest<Response<string>>
    {
        public int InstractorId { get; set; }
        public int SubjectId { get; set; }
    }
}
