using MediatR;
using School.Core.Bases;
using School.Data.Requests;


namespace School.Core.Features.Authorization.Command.Modeles
{
    public class UpdateUserRoleCommand : EditUserRolesRequest, IRequest<Response<string>>
    {
    }
}
