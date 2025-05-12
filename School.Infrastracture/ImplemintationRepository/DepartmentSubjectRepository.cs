using Microsoft.EntityFrameworkCore;
using School.Data.Models;
using School.Infrastracture.AbstractRepository;
using School.Infrastracture.Bases;
using School.Infrastracture.Data;

namespace School.Infrastracture.ImplemintationRepository
{
    public class DepartmentSubjectRepository : GenericRepositoryAsync<DepartmentSubject>, IDepartmentSubjectRepository
    {
        private readonly DbSet<DepartmentSubject> _departmentSubjects;

        public DepartmentSubjectRepository(AppDbContext dbContext) : base(dbContext)
        {
            _departmentSubjects = dbContext.Set<DepartmentSubject>();
        }

    }
}
