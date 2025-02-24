using MediatR;
using School.Core.Bases;
using School.Core.Features.Authorization.Quiery.Responses;

namespace School.Core.Features.Authorization.Quiery.Models
{
    public class GetRoleByIdQuery : IRequest<Response<GetRoleByIdResponse>>
    {
        public int id { get; set; }
        public GetRoleByIdQuery(int id)
        {
            this.id = id;
        }
    }
}
