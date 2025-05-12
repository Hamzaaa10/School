
using School.Core.Features.DepartmentFeature.Query.Responses;
using School.Data.Models;

namespace School.Core.Mapping.DepartmentMapping
{
    public partial class DepartmentProfile
    {
        public void GetAllDepartmentsMapping()
        {
            CreateMap<Department, GetAllDepartmentsResponse>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DID))
                                                              .ForMember(dest => dest.MangerName, opt => opt.MapFrom(src => src.Instructor.IName))
;

        }
    }
}








