using MediatR;
using School.Core.Features.SubjectFeatures.Query.Responses;
using School.Core.Wrappers;

namespace School.Core.Features.SubjectFeatures.Query.Models
{
    public class GetAllSubjectsQuery : IRequest<PaginatedResult<GetAllSubjectsResponses>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
