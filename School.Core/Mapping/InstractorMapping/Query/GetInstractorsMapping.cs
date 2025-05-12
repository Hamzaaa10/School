using School.Core.Features.InstructorFeature.Query.Responses;
using School.Data.Models;

namespace School.Core.Mapping.InstractorMapping
{
    public partial class InstractorProfile
    {
        public void GetInstractorsMapping()
        {
            CreateMap<Instructor, GetInstractorsResponse>();
        }
    }
}
