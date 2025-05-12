using AutoMapper;

namespace School.Core.Mapping.DepartmentMapping
{
    public partial class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            GetDepartmentMapping();
            AddDepartmentMapping();
            EditDepartmentMapping();
            GetAllDepartmentsMapping();
        }
    }
}
