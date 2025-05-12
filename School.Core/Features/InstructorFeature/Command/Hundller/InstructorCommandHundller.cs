using AutoMapper;
using MediatR;
using School.Core.Bases;
using School.Core.Features.InstructorFeature.Command.Models;
using School.Data.Models;
using School.Service.Abstract;

namespace School.Core.Features.InstructorFeature.Command.Hundller
{
    public class InstructorCommandHundller :

        ResponseHandler, IRequestHandler<CreateInstractorCommand, Response<string>>
                        , IRequestHandler<EditInstractorCommand, Response<string>>
                        , IRequestHandler<DeleteInstractorCommand, Response<string>>

    {
        private readonly IMapper _mapper;
        private readonly IInstructorService _instructorService;

        public InstructorCommandHundller(IMapper mapper, IInstructorService instructorService)
        {
            _mapper = mapper;
            _instructorService = instructorService;

        }

        public async Task<Response<string>> Handle(CreateInstractorCommand request, CancellationToken cancellationToken)
        {
            var MappedInstractor = _mapper.Map<Instructor>(request);
            string result = await _instructorService.AddInstructorAsync(MappedInstractor, request.Image);
            if (result == "Success") return Success("Instractor Created Successfully");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditInstractorCommand request, CancellationToken cancellationToken)
        {
            var instractor = await _instructorService.GetByIdAsync(request.InsId);
            if (instractor == null) return NotFound<string>("Instractor is not found");
            _mapper.Map(request, instractor);
            var result = await _instructorService.EditInstructorAsync(instractor);
            if (result == "Success") return Success("Instractor Edited");
            else return BadRequest<string>(result);
        }

        public async Task<Response<string>> Handle(DeleteInstractorCommand request, CancellationToken cancellationToken)
        {

            var result = await _instructorService.DeleteInstructorAsync(request.InsId);
            if (result == "NotFound") return Deleted<string>("Instractor NotFound");
            else if (result == "Success") return Success("Instractor Deleted");
            return BadRequest<string>();
        }
    }
}
