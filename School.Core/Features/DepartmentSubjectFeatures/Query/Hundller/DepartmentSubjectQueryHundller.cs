using AutoMapper;
using MediatR;
using School.Core.Bases;
using School.Core.Features.DepartmentSubjectFeatures.Query.Requests;
using School.Core.Features.DepartmentSubjectFeatures.Query.Responses;
using School.Service.Abstract;

namespace School.Core.Features.DepartmentSubjectFeatures.Query.Hundller
{
    public class DepartmentSubjectQueryHundller : ResponseHandler,
                                                    IRequestHandler<GetSubjectsInDepartmentQuery, Response<List<GetSubjectsInDepartmentResponse>>>




    {
        private readonly IMapper _mapper;
        private readonly IDepartmentSubjectService _departmentSubjectService;

        public DepartmentSubjectQueryHundller(IMapper mapper, IDepartmentSubjectService departmentSubjectService)
        {
            _mapper = mapper;
            _departmentSubjectService = departmentSubjectService;
        }

        public async Task<Response<List<GetSubjectsInDepartmentResponse>>> Handle(GetSubjectsInDepartmentQuery request, CancellationToken cancellationToken)
        {
            var subjects = await _departmentSubjectService.GetSubjectsBydepartment(request.DepartmentID);
            var result = _mapper.Map<List<GetSubjectsInDepartmentResponse>>(subjects);
            return Success(result);
        }
    }
}
