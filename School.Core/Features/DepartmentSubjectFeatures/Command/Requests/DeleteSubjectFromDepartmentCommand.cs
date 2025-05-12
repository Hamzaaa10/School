using MediatR;
using School.Core.Bases;

namespace School.Core.Features.DepartmentSubjectFeatures.Command.Requests
{
    public class DeleteSubjectFromDepartmentCommand : IRequest<Response<string>>
    {
        public int DepartmentID { get; set; }
        public int SubjectID { get; set; }
    }
}
