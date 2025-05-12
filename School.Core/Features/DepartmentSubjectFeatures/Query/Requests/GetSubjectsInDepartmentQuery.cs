using MediatR;
using School.Core.Bases;
using School.Core.Features.DepartmentSubjectFeatures.Query.Responses;

namespace School.Core.Features.DepartmentSubjectFeatures.Query.Requests
{
    public class GetSubjectsInDepartmentQuery : IRequest<Response<List<GetSubjectsInDepartmentResponse>>>
    {
        public int DepartmentID { get; set; }
        public GetSubjectsInDepartmentQuery(int id)
        {
            DepartmentID = id;
        }

    }
}
