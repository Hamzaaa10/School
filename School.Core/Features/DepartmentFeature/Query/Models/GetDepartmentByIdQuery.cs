using MediatR;
using School.Core.Bases;
using School.Core.Features.DepartmentFeature.Query.Responses;

namespace School.Core.Features.DepartmentFeature.Query.Models
{
    public class GetDepartmentByIdQuery : IRequest<Response<GetDepartmentResponse>>
    {
        public int Id { get; set; }
        public GetDepartmentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
