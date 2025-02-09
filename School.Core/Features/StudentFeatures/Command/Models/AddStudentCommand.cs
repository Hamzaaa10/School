using MediatR;
using School.Core.Bases;

namespace School.Core.Features.StudentFeatures.Command.Models
{
    public class AddStudentCommand : IRequest<Response<string>>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int DepartmentId { get; set; }
    }
}
