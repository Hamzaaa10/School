using MediatR;
using School.Core.Bases;
using School.Core.Features.DepartmentFeature.Query.Responses;

namespace School.Core.Features.DepartmentFeature.Query.Models
{
    public class GetAllDepartmentsQuery : IRequest<Response<List<GetAllDepartmentsResponse>>>
    {
    }
}
