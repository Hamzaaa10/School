using AutoMapper;
using MediatR;
using School.Core.Bases;
using School.Core.Features.Ins_SubjectFeature.Query.Models;
using School.Core.Features.Ins_SubjectFeature.Query.Responses;
using School.Service.Abstract;

namespace School.Core.Features.Ins_SubjectFeature.Query.Hundller
{
    public class Ins_SubjectQueryHundller : ResponseHandler, IRequestHandler<GetSubjectsAttatchedWithInstractorQuery, Response<List<GetSubjectsAttatchedWithInstractorResponse>>>





    {
        private readonly IMapper _mapper;
        private readonly IIns_SubjectService _ins_SubjectService;

        public Ins_SubjectQueryHundller(IMapper mapper, IIns_SubjectService ins_SubjectService)
        {
            _mapper = mapper;
            _ins_SubjectService = ins_SubjectService;
        }

        public async Task<Response<List<GetSubjectsAttatchedWithInstractorResponse>>> Handle(GetSubjectsAttatchedWithInstractorQuery request, CancellationToken cancellationToken)
        {
            var subjects = await _ins_SubjectService.GetSubjectsAttatchedInstractor(request.InstractorID);
            var result = _mapper.Map<List<GetSubjectsAttatchedWithInstractorResponse>>(subjects);
            return Success(result);
        }
    }
}
