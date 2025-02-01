using MediatR;
using School.Core.Bases;
using School.Core.Features.Queries.Responses;

namespace School.Core.Features.Queries.Models
{
    public class GetStudentListQuery : IRequest<Response<List<GetStudentListResponse>>>
    {

    }
}
