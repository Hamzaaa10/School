using MediatR;
using School.Core.Bases;

namespace School.Core.Features.InstructorFeature.Command.Models
{
    public class DeleteInstractorCommand : IRequest<Response<string>>
    {
        public int InsId { get; set; }
        public DeleteInstractorCommand(int id)
        {
            InsId = id;
        }
    }
}
