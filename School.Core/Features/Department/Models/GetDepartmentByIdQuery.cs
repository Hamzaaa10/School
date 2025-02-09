using MediatR;
using School.Core.Bases;
using School.Core.Features.Department.Resposes;

namespace School.Core.Features.Department.Models
{
    public class GetDepartmentByIdQuery : IRequest<Response<GetDepartmentResponse>>
    {
        public int id { get; set; }
        public int StudentPageNumber { get; set; }
        public int StudentPageSize { get; set; }

        public GetDepartmentByIdQuery(int id)
        {
            this.id = id;
        }
    }
}
