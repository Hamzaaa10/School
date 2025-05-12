using AutoMapper;
using MediatR;
using School.Core.Bases;
using School.Core.Features.SubjectFeatures.Command.Models;
using School.Data.Models;
using School.Service.Abstract;

namespace School.Core.Features.SubjectFeatures.Command.Hundllers
{
    public class SubjectCommandHundller : ResponseHandler, IRequestHandler<CreateSubjectCommand, Response<string>>
                                                  , IRequestHandler<EditSubjectCommand, Response<string>>
                                                  , IRequestHandler<DeleteSubjectCommand, Response<string>>
    {
        private readonly ISubjectService _subjectService;
        private readonly IMapper _mapper;

        public SubjectCommandHundller(ISubjectService subjectService, IMapper mapper)
        {
            _subjectService = subjectService;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(CreateSubjectCommand request, CancellationToken cancellationToken)
        {
            var subjectmapper = _mapper.Map<Subject>(request);
            string result = await _subjectService.AddSubjectAsync(subjectmapper);
            if (result == "Success") return Success("Subject Created Successfully");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditSubjectCommand request, CancellationToken cancellationToken)
        {
            var Subject = await _subjectService.GetByIdIncludeAsync(request.SubID);
            if (Subject == null) return NotFound<string>("Subject is not found");
            _mapper.Map(request, Subject);
            var result = await _subjectService.EditSubjectAsync(Subject);
            if (result == "Success") return Success("Subject Edited");
            else return BadRequest<string>();

        }

        public async Task<Response<string>> Handle(DeleteSubjectCommand request, CancellationToken cancellationToken)
        {
            var result = await _subjectService.DeleteSubjectAsync(request.SubId);
            if (result == "NotFound") return Deleted<string>("Subject NotFound");
            else if (result == "Success") return Success("Subject Deleted");
            return BadRequest<string>();
        }
    }
}
