using AutoMapper;
using MediatR;
using School.Core.Bases;
using School.Core.Features.SubjectFeatures.Query.Models;
using School.Core.Features.SubjectFeatures.Query.Responses;
using School.Core.Wrappers;
using School.Core.Wrappers.SchoolProject.Core.Wrappers;
using School.Service.Abstract;

namespace School.Core.Features.SubjectFeatures.Query.Hundller
{
    public class SubjectQueryHundller : ResponseHandler, IRequestHandler<GetAllSubjectsQuery, PaginatedResult<GetAllSubjectsResponses>>
                                                        , IRequestHandler<GetSubjectByIdQuery, Response<GetSubjectByIdResponse>>

    {
        private readonly ISubjectService _subjectService;
        private readonly IMapper _mapper;

        public SubjectQueryHundller(ISubjectService subjectService, IMapper mapper)
        {
            _subjectService = subjectService;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<GetAllSubjectsResponses>> Handle(GetAllSubjectsQuery request, CancellationToken cancellationToken)
        {
            var Subjects = _subjectService.GetAllSubjects();
            var paginatedSubjects = await _mapper.ProjectTo<GetAllSubjectsResponses>(Subjects)
                .ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return paginatedSubjects;
        }

        public async Task<Response<GetSubjectByIdResponse>> Handle(GetSubjectByIdQuery request, CancellationToken cancellationToken)
        {
            var Subject = await _subjectService.GetByIdIncludeAsync(request.SubID);
            if (Subject == null) return NotFound<GetSubjectByIdResponse>("Subject not found");
            var result = _mapper.Map<GetSubjectByIdResponse>(Subject);
            return Success(result);
        }


    }
}
