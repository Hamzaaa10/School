using MediatR;
using School.Core.Bases;

namespace School.Core.Features.DepartmentFeature.Command.Models
{
    public class EditDepartmentCommand : IRequest<Response<string>>
    {
        public int DID { get; set; }
        public string DName { get; set; }
        public int? InsManager { get; set; }
    }
}
