using MediatR;
using School.Core.Bases;
using School.Core.Features.Queries.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Core.Features.Queries.Models
{
    public class GetStudentByIdQuery : IRequest<Response<GetStudentResponse>>
    {
        public int id { get; set; }
        public GetStudentByIdQuery(int id)
        {
            this.id = id;
        }
    }
}
