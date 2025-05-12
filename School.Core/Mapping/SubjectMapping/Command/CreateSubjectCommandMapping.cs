using School.Core.Features.SubjectFeatures.Command.Models;
using School.Data.Models;

namespace School.Core.Mapping.SubjectMapping
{
    public partial class SubjectProfile
    {
        public void CreateSubjectCommandMapping()
        {
            CreateMap<CreateSubjectCommand, Subject>();

        }
    }
}
