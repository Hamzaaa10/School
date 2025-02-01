using School.Core.Features.Queries.Responses;
using School.Data.Models;

namespace School.Core.Mapping.StudentMapping
{
    public partial class StudentProfile
    {
        public void GetStudentMapping()
        {

            CreateMap<Student, GetStudentResponse>().ForMember(dest => dest.DepartementName, opt => opt.MapFrom(src => src.Department.DName));
        }
    }
}
