using MediatR;
using School.Core.Bases;

namespace School.Core.Features.Authorization.Command.Modeles
{
    public class DeleteRoleCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteRoleCommand(int id)
        {
            Id = id;
        }
    }
}
