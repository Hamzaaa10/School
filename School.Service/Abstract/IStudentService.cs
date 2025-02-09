using School.Data.Helpers;
using School.Data.Models;

namespace School.Service.Abstract
{
    public interface IStudentService
    {
        public Task<List<Student>> GetStudentsAsync();
        public Task<Student> GetByIdIncludeAsync(int id);
        public Task<Student> GetByIdAsync(int id);
        public Task<string> AddStudentAsync(Student student);
        public Task<bool> IsNameExists(string name);
        public Task<string> EditStudentAsync(Student student);
        public Task<bool> IsNameExcludeExists(string name, int id);
        public Task<string> DeleteStudentAsync(Student student);
        public IQueryable<Student> GetStudentsQuarable(string SearchBy, StudentOrderingEnum OrderBy);
        public IQueryable<Student> GetStudentsByDepartmentQuarable(int DID);


    }
}
