using School.Core.Features.SubjectFeatures.Query.Responses;
using School.Data.Models;

namespace School.Core.Mapping.SubjectMapping
{
    public partial class SubjectProfile
    {
        public void GetSubjectByIdQueryMapping()
        {
            CreateMap<Subject, GetSubjectByIdResponse>();
        }
    }
}
