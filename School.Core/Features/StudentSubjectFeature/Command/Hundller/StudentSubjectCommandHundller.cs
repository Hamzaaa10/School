using AutoMapper;
using MediatR;
using School.Core.Bases;
using School.Core.Features.StudentSubjectFeature.Command.Models;
using School.Data.Models;
using School.Service.Abstract;

namespace School.Core.Features.StudentSubjectFeature.Command.Hundller
{
    public class StudentSubjectCommandHundller : ResponseHandler,
                                                 IRequestHandler<AddSubjectToStudentCommand, Response<string>>,
                                                 IRequestHandler<EditStudentSubjectCommand, Response<string>>,
                                                 IRequestHandler<DeleteSubjectFromStudentCommand, Response<string>>


    {
        private readonly IMapper _mapper;
        private readonly IStudentSubjectService _studentSubjectService;

        public StudentSubjectCommandHundller(IMapper mapper, IStudentSubjectService studentSubjectService)
        {
            _mapper = mapper;
            _studentSubjectService = studentSubjectService;
        }

        public async Task<Response<string>> Handle(AddSubjectToStudentCommand request, CancellationToken cancellationToken)
        {
            var Mapped = _mapper.Map<StudentSubject>(request);
            string result = await _studentSubjectService.AddSubjectToStudentAsync(Mapped);
            if (result == "Success") return Success("Subject attached to student Successfully");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditStudentSubjectCommand request, CancellationToken cancellationToken)
        {
            var studentSubject = await _studentSubjectService.GetByIdIncludeAsync(request.StudentID, request.SubjectID);
            if (studentSubject == null) return NotFound<string>("Subject not attached For this student");
            _mapper.Map(request, studentSubject);
            var result = await _studentSubjectService.EditStudentSubjectAsync(studentSubject);
            if (result == "Success") return Success("Student Subject Edited Successfuly");
            else return BadRequest<string>(result);
        }

        public async Task<Response<string>> Handle(DeleteSubjectFromStudentCommand request, CancellationToken cancellationToken)
        {
            var result = await _studentSubjectService.DeleteStudentSubjectSubjectAsync(request.StudentID, request.SubjectID);
            if (result == "NotFound") return Deleted<string>("Subject not attached For this student");
            else if (result == "Success") return Success("Subject Deleted from this studend ");
            return BadRequest<string>();
        }
    }
}
