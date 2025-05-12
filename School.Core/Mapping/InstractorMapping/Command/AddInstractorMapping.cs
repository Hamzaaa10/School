using School.Core.Features.InstructorFeature.Command.Models;
using School.Data.Models;

namespace School.Core.Mapping.InstractorMapping
{
    public partial class InstractorProfile
    {
        public void AddInstractorMapping()
        {
            CreateMap<CreateInstractorCommand, Instructor>();

        }
    }
}
