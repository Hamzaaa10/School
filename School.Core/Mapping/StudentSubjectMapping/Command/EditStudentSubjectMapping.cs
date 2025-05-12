using School.Core.Features.StudentSubjectFeature.Command.Models;
using School.Data.Models;

namespace School.Core.Mapping.StudentSubjectMapping
{
    public partial class StudentSubjectProfile
    {
        public void EditStudentSubjectMapping()
        {
            CreateMap<EditStudentSubjectCommand, StudentSubject>().ForMember(dest => dest.StudID, opt => opt.MapFrom(src => src.StudentID))
                                                            .ForMember(dest => dest.SubID, opt => opt.MapFrom(src => src.SubjectID));
        }
    }
}
