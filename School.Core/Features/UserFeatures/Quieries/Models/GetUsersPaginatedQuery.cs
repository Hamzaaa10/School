using MediatR;
using School.Core.Features.UserFeatures.Quieries.Responses;
using School.Core.Wrappers;

namespace School.Core.Features.UserFeatures.Quieries.Models
{
    public class GetUsersPaginatedQuery : IRequest<PaginatedResult<GetUsersPaginatedResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
