using MediatR;
using School.Core.Features.StudentFeatures.Queries.Responses;
using School.Core.Wrappers;
using School.Data.Helpers;

namespace School.Core.Features.StudentFeatures.Queries.Models
{
    public class GetStudentListPaginationQuery : IRequest<PaginatedResult<GetStudentListPagintionResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? SearchBy { get; set; }
        public StudentOrderingEnum OrderBy { get; set; }

    }
}
