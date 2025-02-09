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
    }
}
