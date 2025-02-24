using MediatR;
using School.Core.Bases;
using School.Data.Responses;

namespace School.Core.Features.Authorization.Quiery.Models
{
    public class ManageUserClaimsQuery : IRequest<Response<ManageUserClaimsResponse>>
    {
        public int Id { get; set; }
        public ManageUserClaimsQuery(int id)
        {
            this.Id = id;
        }
    }
}
