using Microsoft.EntityFrameworkCore;
using School.Data.Models;
using School.Data.Responses;
using School.Infrastracture.AbstractRepository;
using School.Service.Abstract;

namespace School.Service.Implemintation
{
    public class StudentSubjectService : IStudentSubjectService
    {
        private readonly IStudentSubjectRepository _studentSubjectRepository;

        public StudentSubjectService(IStudentSubjectRepository studentSubjectRepository)
        {
            _studentSubjectRepository = studentSubjectRepository;
        }

        public async Task<string> AddSubjectToStudentAsync(StudentSubject studentSubject)
        {
            try
            {
                await _studentSubjectRepository.AddAsync(studentSubject);
                return "Success";
            }
            catch
            {
                return "Failed";
            }
        }

        public async Task<string> DeleteStudentSubjectSubjectAsync(int StudID, int SubID)
        {
            var studentSubject = await _studentSubjectRepository.GetTableAsTracking().Where(x => x.StudID == StudID && x.SubID == SubID).FirstOrDefaultAsync();
            if (studentSubject == null) return ("NotFound");
            try
            {
                await _studentSubjectRepository.DeleteAsync(studentSubject);
                return "Success";
            }
            catch
            {
                return "Failed";
            }
        }

        public async Task<string> EditStudentSubjectAsync(StudentSubject studentSubject)
        {
            try
            {
                await _studentSubjectRepository.UpdateAsync(studentSubject);
                return "Success";
            }
            catch
            {
                return "Failed";
            }
        }

        public async Task<StudentSubject> GetByIdIncludeAsync(int StudentId, int SubjectID)
        {
            var StudentSubject = await _studentSubjectRepository.GetTableAsTracking().Where(x => x.StudID == StudentId && x.SubID == SubjectID).FirstOrDefaultAsync();
            return StudentSubject;
        }

        public async Task<List<GetstudentSubjectsResponse>> GetStudentSubjects(int StudID)
        {
            var subjects = await _studentSubjectRepository.GetTableNoTracking()
     .Where(ss => ss.StudID == StudID)
     .Include(ss => ss.Subject)
     .Select(ss => new GetstudentSubjectsResponse
     {
         SubID = ss.SubID,
         SubjectName = ss.Subject!.SubjectName ?? string.Empty,
         Period = ss.Subject.Period ?? 0,
         grade = ss.grade ?? 0
     })
     .ToListAsync();

            return subjects;
        }
    }
}
