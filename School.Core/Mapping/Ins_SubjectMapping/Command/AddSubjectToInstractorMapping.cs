using School.Core.Features.Ins_SubjectFeature.Command.Models;
using School.Data.Models;

namespace School.Core.Mapping.Ins_SubjectMapping
{
    public partial class Ins_SubjectProfile
    {
        public void AddSubjectToInstractorMapping()
        {
            CreateMap<AddSubjectToInstractorCommand, Ins_Subject>().ForMember(dest => dest.InsId, opt => opt.MapFrom(src => src.InstractorId))
                                                                         .ForMember(dest => dest.SubId, opt => opt.MapFrom(src => src.SubjectId));
        }
    }
}