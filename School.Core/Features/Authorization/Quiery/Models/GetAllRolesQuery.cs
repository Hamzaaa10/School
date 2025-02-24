using MediatR;
using School.Core.Bases;
using School.Core.Features.Authorization.Quiery.Responses;

namespace School.Core.Features.Authorization.Quiery.Models
{
    public class GetAllRolesQuery : IRequest<Response<List<GetAllRolesResponse>>>
    {

    }
}











