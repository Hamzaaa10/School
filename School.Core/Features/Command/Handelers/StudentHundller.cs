using AutoMapper;
using MediatR;
using School.Core.Bases;
using School.Core.Features.Command.Models;
using School.Data.Models;
using School.Service.Abstract;

namespace School.Core.Features.Command.Handelers
{
    public class StudentHundller : ResponseHandler, IRequestHandler<AddStudentCommand, Response<string>>
                                                  , IRequestHandler<EditStudentCommand, Response<string>>
                                                  , IRequestHandler<DeleteStudentCommand, Response<string>>
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentHundller(IStudentService studentService, IMapper mapper)
        {
            this._studentService = studentService;
            this._mapper = mapper;
        }

        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var studentmapper = _mapper.Map<Student>(request);
            string result = await _studentService.AddStudentAsync(studentmapper);
            if (result == "Exists") return UnprocessableEntity<string>("the name is exist");
            else if (result == "Succses") return Success("Created");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            var Student = await _studentService.GetByIdIncludeAsync(request.ID);
            if (Student == null) return NotFound<string>("Student is not found");
            var StudentMapper = _mapper.Map<Student>(request);
            var result = await _studentService.EditStudentAsync(StudentMapper);
            if (result == "Succsess") return Success("Student Edited");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var Student = await _studentService.GetByIdAsync(request.id);
            if (Student == null) return NotFound<string>("Student is not found");
            var result = await _studentService.DeleteStudentAsync(Student);
            if (result == "Succsess") return Deleted<string>("Student Deleted");
            return BadRequest<string>();
        }
    }
}
