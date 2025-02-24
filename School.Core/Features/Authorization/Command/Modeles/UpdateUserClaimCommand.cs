using MediatR;
using School.Core.Bases;
using School.Data.Requests;

namespace School.Core.Features.Authorization.Command.Modeles
{
    public class UpdateUserClaimCommand : EditUserClaimsRequest, IRequest<Response<string>>
    {
    }
}
