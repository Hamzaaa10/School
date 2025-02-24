using MediatR;
using School.Core.Bases;

namespace School.Core.Features.Authorization.Command.Modeles
{
    public class AddRoleCommand : IRequest<Response<string>>
    {
        public string RoleName { get; set; }
    }
}
