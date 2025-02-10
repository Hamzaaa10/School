using MediatR;
using School.Core.Bases;
using School.Core.Features.UserFeatures.Quieries.Responses;

namespace School.Core.Features.UserFeatures.Quieries.Models
{
    public class GetUserByIdQuery : IRequest<Response<GetUserByIdResponse>>
    {
        public int Id { get; set; }
        public GetUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}
