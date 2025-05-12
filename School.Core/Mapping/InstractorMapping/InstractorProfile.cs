using AutoMapper;

namespace School.Core.Mapping.InstractorMapping
{
    public partial class InstractorProfile : Profile
    {
        public InstractorProfile()
        {
            AddInstractorMapping();
            EditInstractorMapping();
            GetInstractorsMapping();
            GetInstractorByIdMapping();
        }
    }
}
