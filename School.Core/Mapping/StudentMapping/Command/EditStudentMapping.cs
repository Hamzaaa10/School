using School.Core.Features.StudentFeatures.Command.Models;
using School.Data.Models;

namespace School.Core.Mapping.StudentMapping
{
    public partial class StudentProfile
    {

        public void EditStudentMapping()
        {
            CreateMap<EditStudentCommand, Student>().ForMember(dest => dest.DID, opt => opt.MapFrom(src => src.DepartmentId))
                                                    .ForMember(dest => dest.StudID, opt => opt.MapFrom(src => src.ID));

        }
    }
}
