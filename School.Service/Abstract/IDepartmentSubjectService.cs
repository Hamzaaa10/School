using School.Data.Models;

namespace School.Service.Abstract
{
    public interface IDepartmentSubjectService
    {
        public Task<string> AddSubjectToDepartmentAsync(DepartmentSubject departmentSubject);
        public Task<string> EditSubjectToDepartmentAsync(DepartmentSubject departmentSubject);
        public Task<string> DeleteDepartmentFromSubjectAsync(int DepartmentID, int SubjectID);
        public Task<DepartmentSubject> GetByIdIncludeAsync(int DepartmentID, int SubjectID);
        public Task<DepartmentSubject> GetByIdAsync(int DepartmentID, int SubjectID);
        public Task<List<Subject>> GetSubjectsBydepartment(int DepartmentID);



    }
}
