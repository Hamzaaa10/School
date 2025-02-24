using MediatR;
using School.Core.Bases;

namespace School.Core.Features.Authorization.Command.Modeles
{
    public class EditRoleCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
    }
}
