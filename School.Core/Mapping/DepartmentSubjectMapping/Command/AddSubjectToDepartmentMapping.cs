using School.Core.Features.DepartmentSubjectFeatures.Command.Requests;
using School.Data.Models;

namespace School.Core.Mapping.DepartmentSubjectMapping
{
    public partial class DepartmentSubjectProfile
    {
        public void AddSubjectToDepartmentMapping()
        {
            CreateMap<AddSubjectToDepartmentCommand, DepartmentSubject>().ForMember(dest => dest.DID, opt => opt.MapFrom(src => src.DepartmentID))
                                                                         .ForMember(dest => dest.SubID, opt => opt.MapFrom(src => src.SubjectID));

        }
    }
}
