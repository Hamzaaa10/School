using MediatR;
using School.Core.Bases;
using School.Core.Features.StudentFeatures.Queries.Responses;

namespace School.Core.Features.StudentFeatures.Queries.Models
{
    public class GetStudentListQuery : IRequest<Response<List<GetStudentListResponse>>>
    {

    }
}
