using School.Core.Features.StudentSubjectFeature.Query.Responses;
using School.Data.Responses;

namespace School.Core.Mapping.StudentSubjectMapping
{
    public partial class StudentSubjectProfile
    {
        public void GetStudentSubjectsMapping()
        {
            CreateMap<GetstudentSubjectsResponse, GetStudentSubjectsResponse>();

        }
    }
}
