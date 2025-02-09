using MediatR;
using School.Core.Bases;
using School.Core.Features.StudentFeatures.Queries.Responses;

namespace School.Core.Features.StudentFeatures.Queries.Models
{
    public class GetStudentByIdQuery : IRequest<Response<GetStudentResponse>>
    {
        public int id { get; set; }
        public GetStudentByIdQuery(int id)
        {
            this.id = id;
        }
    }
}
