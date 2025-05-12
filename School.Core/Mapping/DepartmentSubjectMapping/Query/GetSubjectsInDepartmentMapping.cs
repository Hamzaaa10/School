using School.Core.Features.DepartmentSubjectFeatures.Query.Responses;
using School.Data.Models;

namespace School.Core.Mapping.DepartmentSubjectMapping
{
    public partial class DepartmentSubjectProfile
    {
        public void GetSubjectsInDepartmentMapping()
        {
            CreateMap<DepartmentSubject, GetSubjectsInDepartmentResponse>().ForMember(dest => dest.SubjectId, opt => opt.MapFrom(src => src.SubID));


        }
    }
}
