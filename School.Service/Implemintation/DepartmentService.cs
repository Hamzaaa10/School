using Microsoft.EntityFrameworkCore;
using School.Data.Models;
using School.Infrastracture.AbstractRepository;
using School.Service.Abstract;

namespace School.Service.Implemintation
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            this._departmentRepository = departmentRepository;
        }

        public async Task<string> AddDepartmentAsync(Department department)
        {
            try
            {
                await _departmentRepository.AddAsync(department);
                return "Success";
            }
            catch
            {
                return "Failed";
            }
        }

        public async Task<string> DeleteDepartmentAsync(int id)
        {
            var Department = await _departmentRepository.GetByIdAsync(id);
            if (Department == null) return "NotFound";

            try
            {
                await _departmentRepository.DeleteAsync(Department);
                return "Success";
            }
            catch
            {
                return "failed";
            }
        }

        public async Task<string> EditDepartmentAsync(Department department)
        {
            try
            {
                await _departmentRepository.UpdateAsync(department);
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<List<Department>> GetAllDepartmentsAsync()
        {
            return await _departmentRepository.GetTableNoTracking().Include(x => x.Instructor).ToListAsync();
        }

        public async Task<Department> GetDepartmentByIdAsync(int id)
        {
            return await _departmentRepository.GetTableNoTracking().Where(x => x.DID.Equals(id)).
                  Include(x => x.Instructors).
                  Include(x => x.Students).
                  Include(x => x.DepartmentSubjects).
                  Include(x => x.Instructor).FirstOrDefaultAsync();
        }

        public async Task<bool> IsDepartmentIdExists(int id)
        {
            return await _departmentRepository.GetTableNoTracking().AnyAsync(x => x.DID == id);
        }

        public async Task<bool> IsNameExcludeExists(string name, int id)
        {
            var department = await _departmentRepository.GetTableNoTracking().Where(x => x.DName == name && x.DID != id).FirstOrDefaultAsync();
            if (department == null) return false;
            return true;
        }

        public async Task<bool> IsNameExists(string name)
        {
            var department = await _departmentRepository.GetTableNoTracking().Where(x => x.DName == name).FirstOrDefaultAsync();
            if (department == null) return false;
            return true;
        }
    }
}
