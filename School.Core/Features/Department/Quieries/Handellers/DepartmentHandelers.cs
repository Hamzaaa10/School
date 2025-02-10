using AutoMapper;
using MediatR;
using School.Core.Bases;
using School.Core.Features.Department.Quieries.Models;
using School.Core.Features.Department.Quieries.Resposes;
using School.Core.Wrappers.SchoolProject.Core.Wrappers;
using School.Data.Models;
using School.Service.Abstract;
using System.Linq.Expressions;

namespace School.Core.Features.Department.Quieries.Handellers
{
    public class DepartmentHandelers :

        ResponseHandler, IRequestHandler<GetDepartmentByIdQuery, Response<GetDepartmentResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IDepartmentService _departmentService;
        private readonly IStudentService _studentService;

        public DepartmentHandelers(IMapper mapper, IDepartmentService departmentService, IStudentService studentService)
        {
            _mapper = mapper;
            _departmentService = departmentService;
            _studentService = studentService;
        }
        public async Task<Response<GetDepartmentResponse>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
        {
            var Department = await _departmentService.GetDepartmentByIdAsync(request.id);
            if (Department == null) return NotFound<GetDepartmentResponse>("Department Not Found");
            var DepartmentMapper = _mapper.Map<GetDepartmentResponse>(Department);
            //pagination student
            Expression<Func<Student, StudentResponse>> expression = e => new StudentResponse(e.StudID, e.Name);
            var Quareble = _studentService.GetStudentsByDepartmentQuarable(request.id);
            var filteredQuarble = await Quareble.Select(expression).ToPaginatedListAsync(request.StudentPageSize, request.StudentPageNumber);
            DepartmentMapper.Students = filteredQuarble;
            return Success(DepartmentMapper);
        }
    }
}


