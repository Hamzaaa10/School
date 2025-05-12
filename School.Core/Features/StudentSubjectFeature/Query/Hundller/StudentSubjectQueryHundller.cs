using AutoMapper;
using MediatR;
using School.Core.Bases;
using School.Core.Features.StudentSubjectFeature.Query.Models;
using School.Core.Features.StudentSubjectFeature.Query.Responses;
using School.Service.Abstract;

namespace School.Core.Features.StudentSubjectFeature.Query.Hundller
{
    public class StudentSubjectQueryHundller : ResponseHandler,
                                               IRequestHandler<GetStudentSubjectsQuery, Response<List<GetStudentSubjectsResponse>>>



    {
        private readonly IMapper _mapper;
        private readonly IStudentSubjectService _studentSubjectService;

        public StudentSubjectQueryHundller(IMapper mapper, IStudentSubjectService studentSubjectService)
        {
            _mapper = mapper;
            _studentSubjectService = studentSubjectService;
        }

        public async Task<Response<List<GetStudentSubjectsResponse>>> Handle(GetStudentSubjectsQuery request, CancellationToken cancellationToken)
        {
            var subjects = await _studentSubjectService.GetStudentSubjects(request.StudID);
            var result = _mapper.Map<List<GetStudentSubjectsResponse>>(subjects);
            return Success(result);
        }
    }
}
