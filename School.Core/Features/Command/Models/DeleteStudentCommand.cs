using MediatR;
using School.Core.Bases;

namespace School.Core.Features.Command.Models
{
    public class DeleteStudentCommand : IRequest<Response<string>>
    {
        public int id { get; set; }
        public DeleteStudentCommand(int id)
        {
            this.id = id;
        }
    }
}
