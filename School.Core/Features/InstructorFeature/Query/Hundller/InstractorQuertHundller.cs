using AutoMapper;
using MediatR;
using School.Core.Bases;
using School.Core.Features.InstructorFeature.Query.Models;
using School.Core.Features.InstructorFeature.Query.Responses;
using School.Service.Abstract;

namespace School.Core.Features.InstructorFeature.Query.Hundller
{
    public class InstractorQuertHundller : ResponseHandler
                        , IRequestHandler<GetInstractorByIdQuery, Response<GetInstractorByIdResponse>>
                        , IRequestHandler<GetInstractorsQuery, Response<List<GetInstractorsResponse>>>

    {
        private readonly IMapper _mapper;
        private readonly IInstructorService _instructorService;

        public InstractorQuertHundller(IMapper mapper, IInstructorService instructorService)
        {
            _mapper = mapper;
            _instructorService = instructorService;

        }

        public async Task<Response<GetInstractorByIdResponse>> Handle(GetInstractorByIdQuery request, CancellationToken cancellationToken)
        {
            var Instractor = await _instructorService.GetByIdIncludeAsync(request.Id);
            if (Instractor == null) return NotFound<GetInstractorByIdResponse>("Instractor not found");
            var result = _mapper.Map<GetInstractorByIdResponse>(Instractor);
            return Success(result);
        }

        public async Task<Response<List<GetInstractorsResponse>>> Handle(GetInstractorsQuery request, CancellationToken cancellationToken)
        {
            var instractors = await _instructorService.GetInstactorsAsync();
            var MappedInstractors = _mapper.Map<List<GetInstractorsResponse>>(instractors);
            var result = Success(MappedInstractors);
            result.Meta = MappedInstractors.Count;
            return result;
        }
    }
}
