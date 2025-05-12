using MediatR;
using School.Core.Bases;
using School.Core.Features.InstructorFeature.Query.Responses;

namespace School.Core.Features.InstructorFeature.Query.Models
{
    public class GetInstractorByIdQuery : IRequest<Response<GetInstractorByIdResponse>>
    {
        public int Id { get; set; }
        public GetInstractorByIdQuery(int id)
        {
            Id = id;
        }
    }
}
