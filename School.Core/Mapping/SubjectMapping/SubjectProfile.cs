using AutoMapper;

namespace School.Core.Mapping.SubjectMapping
{
    public partial class SubjectProfile : Profile
    {
        public SubjectProfile()
        {
            CreateSubjectCommandMapping();
            EditSubjectCommandMapping();
            GetAllSubjectsQueryMapping();
            GetSubjectByIdQueryMapping();
        }
    }
}
