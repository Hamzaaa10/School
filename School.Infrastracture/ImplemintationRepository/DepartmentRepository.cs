using Microsoft.EntityFrameworkCore;
using School.Data.Models;
using School.Infrastracture.AbstractRepository;
using School.Infrastracture.Bases;
using School.Infrastracture.Data;

namespace School.Infrastracture.ImplemintationRepository
{
    public class DepartmentRepository : GenericRepositoryAsync<Department>, IDepartmentRepository
    {
        private readonly DbSet<Department> _department;

        public DepartmentRepository(AppDbContext dbContext) : base(dbContext)
        {

            _department = dbContext.Set<Department>();
        }

    }
}
