using Microsoft.EntityFrameworkCore;
using School.Data.Models;
using School.Infrastracture.AbstractRepository;
using School.Infrastracture.Bases;
using School.Infrastracture.Data;

namespace School.Infrastracture.ImplemintationRepository
{
    public class SubjectRepository : GenericRepositoryAsync<Subject>, ISubjectRepository
    {
        private readonly DbSet<Subject> _subjects;

        public SubjectRepository(AppDbContext dbContext) : base(dbContext)
        {

            _subjects = dbContext.Set<Subject>();
        }

    }
}
