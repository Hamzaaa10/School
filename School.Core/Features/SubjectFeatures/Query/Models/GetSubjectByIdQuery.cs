using MediatR;
using School.Core.Bases;
using School.Core.Features.SubjectFeatures.Query.Responses;

namespace School.Core.Features.SubjectFeatures.Query.Models
{
    public class GetSubjectByIdQuery : IRequest<Response<GetSubjectByIdResponse>>
    {
        public int SubID { get; set; }

        public GetSubjectByIdQuery(int id)
        {
            SubID = id;
        }
    }
}
