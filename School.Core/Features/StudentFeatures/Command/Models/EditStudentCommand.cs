using MediatR;
using School.Core.Bases;

namespace School.Core.Features.StudentFeatures.Command.Models
{
    public class EditStudentCommand : IRequest<Response<string>>
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }
        public string Phone { get; set; }
        public int DepartmentId { get; set; }
    }
}
