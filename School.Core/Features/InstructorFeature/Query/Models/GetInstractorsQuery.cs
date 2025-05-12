using MediatR;
using School.Core.Bases;
using School.Core.Features.InstructorFeature.Query.Responses;

namespace School.Core.Features.InstructorFeature.Query.Models
{
    public class GetInstractorsQuery : IRequest<Response<List<GetInstractorsResponse>>>
    {
    }
}
