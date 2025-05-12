using MediatR;
using School.Core.Bases;

namespace School.Core.Features.SubjectFeatures.Command.Models
{
    public class DeleteSubjectCommand : IRequest<Response<string>>
    {
        public int SubId { get; set; }
        public DeleteSubjectCommand(int id)
        {
            SubId = id;
        }
    }
}
