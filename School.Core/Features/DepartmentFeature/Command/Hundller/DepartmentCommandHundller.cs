using AutoMapper;
using MediatR;
using School.Core.Bases;
using School.Core.Features.DepartmentFeature.Command.Models;
using School.Data.Models;
using School.Service.Abstract;

namespace School.Core.Features.DepartmentFeature.Command.Hundller
{
    public class DepartmentCommandHundller :

    ResponseHandler, IRequestHandler<CreateDepartmentCommand, Response<string>>
                    , IRequestHandler<EditDepartmentCommand, Response<string>>
                    , IRequestHandler<DeleteDepartmentCommand, Response<string>>

    {
        private readonly IMapper _mapper;
        private readonly IDepartmentService _departmentService;
        private readonly IStudentService _studentService;

        public DepartmentCommandHundller(IMapper mapper, IDepartmentService departmentService, IStudentService studentService)
        {
            _mapper = mapper;
            _departmentService = departmentService;
            _studentService = studentService;
        }

        public async Task<Response<string>> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var MappedDepartment = _mapper.Map<Department>(request);
            string result = await _departmentService.AddDepartmentAsync(MappedDepartment);
            if (result == "Success") return Success("Department Created Successfully");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditDepartmentCommand request, CancellationToken cancellationToken)
        {

            var department = await _departmentService.GetDepartmentByIdAsync(request.DID);
            if (department == null) return NotFound<string>("Department is not found");
            _mapper.Map(request, department);
            var result = await _departmentService.EditDepartmentAsync(department);
            if (result == "Success") return Success("Department Edited");
            else return BadRequest<string>(result);
        }

        public async Task<Response<string>> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            var result = await _departmentService.DeleteDepartmentAsync(request.Id);
            if (result == "NotFound") return Deleted<string>("Department NotFound");
            else if (result == "Success") return Success("Department Deleted");
            return BadRequest<string>();
        }
    }
}
