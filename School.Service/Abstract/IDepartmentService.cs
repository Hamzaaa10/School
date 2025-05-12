using School.Data.Models;

namespace School.Service.Abstract
{
    public interface IDepartmentService
    {
        public Task<Department> GetDepartmentByIdAsync(int id);
        public Task<bool> IsDepartmentIdExists(int id);
        public Task<bool> IsNameExists(string name);
        public Task<bool> IsNameExcludeExists(string name, int id);

        public Task<List<Department>> GetAllDepartmentsAsync();
        /* public Task<List<Instructor>> GetInstractorsInDepartmentAsync(int Did);
         public Task<List<Subject>> GetSubjectsInDepartmentAsync(int Did);
         public Task<List<Student>> GetAllStudentsAsync(int Did);*/

        public Task<string> AddDepartmentAsync(Department department);
        public Task<string> EditDepartmentAsync(Department department);
        public Task<string> DeleteDepartmentAsync(int id);

    }
}
