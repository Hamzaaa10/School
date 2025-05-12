using AutoMapper;

namespace School.Core.Mapping.Ins_SubjectMapping
{
    public partial class Ins_SubjectProfile : Profile
    {
        public Ins_SubjectProfile()
        {
            AddSubjectToInstractorMapping();
            GetSubjectsAttatchedWithInstractorMapping();
        }
    }
}
