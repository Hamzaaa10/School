using AutoMapper;
using MediatR;
using School.Core.Bases;
using School.Core.Features.DepartmentFeature.Query.Models;
using School.Core.Features.DepartmentFeature.Query.Responses;
using School.Service.Abstract;

namespace School.Core.Features.DepartmentFeature.Query.Hundller
{
    internal class DepartmentHandelers : ResponseHandler
                                 , IRequestHandler<GetDepartmentByIdQuery, Response<GetDepartmentResponse>>
                                 , IRequestHandler<GetAllDepartmentsQuery, Response<List<GetAllDepartmentsResponse>>>


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
            var Department = await _departmentService.GetDepartmentByIdAsync(request.Id);
            if (Department == null) return NotFound<GetDepartmentResponse>("Department not found");
            var result = _mapper.Map<GetDepartmentResponse>(Department);
            return Success(result);
        }

        public async Task<Response<List<GetAllDepartmentsResponse>>> Handle(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
        {
            var Departments = await _departmentService.GetAllDepartmentsAsync();
            var MappedDepartments = _mapper.Map<List<GetAllDepartmentsResponse>>(Departments);
            return Success(MappedDepartments);

        }
    }

}
