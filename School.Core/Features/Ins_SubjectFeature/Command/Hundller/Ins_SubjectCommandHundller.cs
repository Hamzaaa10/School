using AutoMapper;
using MediatR;
using School.Core.Bases;
using School.Core.Features.Ins_SubjectFeature.Command.Models;
using School.Data.Models;
using School.Service.Abstract;

namespace School.Core.Features.Ins_SubjectFeature.Command.Hundller
{
    public class Ins_SubjectCommandHundller : ResponseHandler,
                                                    IRequestHandler<AddSubjectToInstractorCommand, Response<string>>,
                                                    IRequestHandler<DeleteIns_SubjectCommand, Response<string>>



    {
        private readonly IMapper _mapper;
        private readonly IIns_SubjectService _ins_SubjectService;

        public Ins_SubjectCommandHundller(IMapper mapper, IIns_SubjectService ins_SubjectService)
        {
            _mapper = mapper;
            _ins_SubjectService = ins_SubjectService;
        }

        public async Task<Response<string>> Handle(AddSubjectToInstractorCommand request, CancellationToken cancellationToken)
        {
            var Mapped = _mapper.Map<Ins_Subject>(request);
            string result = await _ins_SubjectService.AddSubjectToInstractorAsync(Mapped);
            if (result == "Success") return Success("Subject Attatched to instractor Successfully");
            else return BadRequest<string>();
        }



        public async Task<Response<string>> Handle(DeleteIns_SubjectCommand request, CancellationToken cancellationToken)
        {
            var result = await _ins_SubjectService.DeleteIns_SubjectAsync(request.InstractorId, request.SubjectId);
            if (result == "NotFound") return Deleted<string>("Subject not Attatched with Instractor ");
            else if (result == "Success") return Success(" Deleted attatched Subject with Instractor ");
            return BadRequest<string>();
        }
    }
}
