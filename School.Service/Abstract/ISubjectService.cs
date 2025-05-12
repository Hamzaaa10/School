using School.Data.Models;

namespace School.Service.Abstract
{
    public interface ISubjectService
    {
        public Task<string> AddSubjectAsync(Subject subject);
        public Task<bool> IsNameExists(string name);
        public Task<string> EditSubjectAsync(Subject subject);
        public Task<bool> IsNameExcludeExists(string name, int id);
        public Task<string> DeleteSubjectAsync(int id);
        public Task<Subject> GetByIdIncludeAsync(int id);
        public IQueryable<Subject> GetAllSubjects();
        //  public IQueryable<Subject> GetAllSubjectsByDepartment(int id);


    }
}
