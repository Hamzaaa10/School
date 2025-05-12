using School.Core.Features.DepartmentFeature.Command.Models;
using School.Data.Models;

namespace School.Core.Mapping.DepartmentMapping
{
    public partial class DepartmentProfile
    {
        public void EditDepartmentMapping()
        {
            CreateMap<EditDepartmentCommand, Department>();
        }
    }
}
