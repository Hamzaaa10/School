using School.Data.Models;

namespace School.Service.Abstract
{
    public interface IDepartmentService
    {
        public Task<Department> GetDepartmentByIdAsync(int id);
        public Task<bool> IsDepartmentIdExists(int id);

    }
}
