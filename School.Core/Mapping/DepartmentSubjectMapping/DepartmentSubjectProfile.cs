using AutoMapper;

namespace School.Core.Mapping.DepartmentSubjectMapping
{
    public partial class DepartmentSubjectProfile : Profile
    {
        public DepartmentSubjectProfile()
        {
            AddSubjectToDepartmentMapping();
            GetSubjectsInDepartmentMapping();

        }
    }
}
