using MediatR;
using School.Core.Bases;
using School.Core.Features.Ins_SubjectFeature.Query.Responses;

namespace School.Core.Features.Ins_SubjectFeature.Query.Models
{
    public class GetSubjectsAttatchedWithInstractorQuery : IRequest<Response<List<GetSubjectsAttatchedWithInstractorResponse>>>
    {
        public int InstractorID { get; set; }

        public GetSubjectsAttatchedWithInstractorQuery(int id)
        {
            InstractorID = id;
        }
    }

}

