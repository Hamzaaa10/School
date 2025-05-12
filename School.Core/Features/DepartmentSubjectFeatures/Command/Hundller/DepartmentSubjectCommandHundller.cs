using AutoMapper;
using MediatR;
using School.Core.Bases;
using School.Core.Features.DepartmentSubjectFeatures.Command.Requests;
using School.Data.Models;
using School.Service.Abstract;

namespace School.Core.Features.DepartmentSubjectFeatures.Command.Hundller
{
    public class DepartmentSubjectCommandHundller : ResponseHandler,
                                                    IRequestHandler<AddSubjectToDepartmentCommand, Response<string>>,
                                                    IRequestHandler<DeleteSubjectFromDepartmentCommand, Response<string>>



    {
        private readonly IMapper _mapper;
        private readonly IDepartmentSubjectService _departmentSubjectService;

        public DepartmentSubjectCommandHundller(IMapper mapper, IDepartmentSubjectService departmentSubjectService)
        {
            _mapper = mapper;
            _departmentSubjectService = departmentSubjectService;
        }

        public async Task<Response<string>> Handle(AddSubjectToDepartmentCommand request, CancellationToken cancellationToken)
        {
            var Mapped = _mapper.Map<DepartmentSubject>(request);
            string result = await _departmentSubjectService.AddSubjectToDepartmentAsync(Mapped);
            if (result == "Success") return Success("Subject Add to Department Successfully");
            else return BadRequest<string>();
        }



        public async Task<Response<string>> Handle(DeleteSubjectFromDepartmentCommand request, CancellationToken cancellationToken)
        {
            var result = await _departmentSubjectService.DeleteDepartmentFromSubjectAsync(request.DepartmentID, request.SubjectID);
            if (result == "NotFound") return Deleted<string>("Subject not found in this department");
            else if (result == "Success") return Success("Subject Deleted from Department ");
            return BadRequest<string>();
        }
    }
}