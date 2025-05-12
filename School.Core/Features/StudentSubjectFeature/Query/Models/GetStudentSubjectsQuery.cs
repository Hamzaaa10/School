using MediatR;
using School.Core.Bases;
using School.Core.Features.StudentSubjectFeature.Query.Responses;

namespace School.Core.Features.StudentSubjectFeature.Query.Models
{
    public class GetStudentSubjectsQuery : IRequest<Response<List<GetStudentSubjectsResponse>>>
    {
        public int StudID { get; set; }
        public GetStudentSubjectsQuery(int id)
        {
            StudID = id;
        }
    }
}
