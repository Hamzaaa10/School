using MediatR;
using School.Core.Bases;
using School.Data.Response;

namespace School.Core.Features.Authorization.Quiery.Models
{
    public class ManageUserRoleQuery : IRequest<Response<ManageUserRoleResponse>>
    {
        public int Id { get; set; }
        public ManageUserRoleQuery(int id)
        {
            this.Id = id;
        }
    }
}
