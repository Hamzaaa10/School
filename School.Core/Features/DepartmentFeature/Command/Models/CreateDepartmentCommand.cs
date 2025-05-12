using MediatR;
using School.Core.Bases;

namespace School.Core.Features.DepartmentFeature.Command.Models
{
    public class CreateDepartmentCommand : IRequest<Response<string>>
    {
        public string DName { get; set; }
        public int? InsManager { get; set; }
    }
}
