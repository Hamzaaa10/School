using MediatR;
using School.Core.Bases;

namespace School.Core.Features.DepartmentFeature.Command.Models
{
    public class DeleteDepartmentCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteDepartmentCommand(int id)
        {
            this.Id = id;
        }
    }
}
