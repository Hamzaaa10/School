using AutoMapper;
using MediatR;
using School.Core.Bases;
using School.Core.Features.Queries.Models;
using School.Core.Features.Queries.Responses;
using School.Core.Wrappers;
using School.Core.Wrappers.SchoolProject.Core.Wrappers;
using School.Data.Models;
using School.Service.Abstract;
using System.Linq.Expressions;


namespace School.Core.Features.Queries.Handelers
{
    public class StudentHundeller : ResponseHandler, IRequestHandler<GetStudentListQuery, Response<List<GetStudentListResponse>>>,
                                                     IRequestHandler<GetStudentByIdQuery, Response<GetStudentResponse>>,
                                                     IRequestHandler<GetStudentListPaginationQuery, PaginatedResult<GetStudentListPagintionResponse>>


    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        //private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        public StudentHundeller(IStudentService studentService, IMapper mapper)//, IStringLocalizer<SharedResources> stringLocalizer)
        {
            this._studentService = studentService;
            // this._stringLocalizer = stringLocalizer;
            this._mapper = mapper;
        }
        public async Task<Response<List<GetStudentListResponse>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var students = await _studentService.GetStudentsAsync();
            var StudentSMapper = _mapper.Map<List<GetStudentListResponse>>(students);
            var result = Success(StudentSMapper);
            result.Meta = StudentSMapper.Count;
            return result;
        }

        public async Task<Response<GetStudentResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var Student = await _studentService.GetByIdIncludeAsync(request.id);
            if (Student == null) return NotFound<GetStudentResponse>("Student not found"/*_stringLocalizer[SharedResourcesKeys.NotFound]*/);
            var result = _mapper.Map<GetStudentResponse>(Student);
            return Success(result);


        }

        public async Task<PaginatedResult<GetStudentListPagintionResponse>> Handle(GetStudentListPaginationQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Student, GetStudentListPagintionResponse>> expression = e => new GetStudentListPagintionResponse(e.StudID, e.Name, e.Address, e.Department.DName);
            var Quareble = _studentService.GetStudentsQuarable(request.SearchBy, request.OrderBy);
            var filteredQuarble = await Quareble.Select(expression).ToPaginatedListAsync(request.PageSize, request.PageNumber);
            filteredQuarble.Meta = filteredQuarble.Data.Count;
            return filteredQuarble;

        }
    }
}
