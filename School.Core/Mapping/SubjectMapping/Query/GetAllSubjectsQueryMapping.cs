using School.Core.Features.SubjectFeatures.Query.Responses;
using School.Data.Models;

namespace School.Core.Mapping.SubjectMapping
{
    public partial class SubjectProfile
    {
        public void GetAllSubjectsQueryMapping()
        {
            CreateMap<Subject, GetAllSubjectsResponses>().ForMember(dest => dest.SubjectId, opt => opt.MapFrom(src => src.SubID));

        }
    }
}
