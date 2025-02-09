using School.Core.Features.StudentFeatures.Queries.Responses;
using School.Data.Models;

namespace School.Core.Mapping.StudentMapping
{
    public partial class StudentProfile
    {
        public void GetStudentListMapping()
        {
            CreateMap<Student, GetStudentListResponse>().ForMember(dest => dest.DepartementName, opt => opt.MapFrom(src => src.Department.DName));
        }

    }
}
