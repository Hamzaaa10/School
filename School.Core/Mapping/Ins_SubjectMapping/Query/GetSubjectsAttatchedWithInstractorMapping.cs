using School.Core.Features.Ins_SubjectFeature.Query.Responses;
using School.Data.Models;

namespace School.Core.Mapping.Ins_SubjectMapping
{
    public partial class Ins_SubjectProfile
    {
        public void GetSubjectsAttatchedWithInstractorMapping()
        {
            CreateMap<Subject, GetSubjectsAttatchedWithInstractorResponse>().ForMember(dest => dest.SubjectID, opt => opt.MapFrom(src => src.SubID));
        }
    }
}