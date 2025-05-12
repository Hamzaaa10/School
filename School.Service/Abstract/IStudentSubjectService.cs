using School.Data.Models;
using School.Data.Responses;

namespace School.Service.Abstract
{
    public interface IStudentSubjectService
    {
        public Task<string> AddSubjectToStudentAsync(StudentSubject studentSubject);
        public Task<string> EditStudentSubjectAsync(StudentSubject studentSubject);
        public Task<string> DeleteStudentSubjectSubjectAsync(int StudID, int SubID);
        public Task<StudentSubject> GetByIdIncludeAsync(int StudentId, int SubjectID);

        public Task<List<GetstudentSubjectsResponse>> GetStudentSubjects(int StudID);

    }
}
