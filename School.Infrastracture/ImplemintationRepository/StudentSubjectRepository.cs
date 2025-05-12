using Microsoft.EntityFrameworkCore;
using School.Data.Models;
using School.Infrastracture.AbstractRepository;
using School.Infrastracture.Bases;
using School.Infrastracture.Data;

namespace School.Infrastracture.ImplemintationRepository
{
    public class StudentSubjectRepository : GenericRepositoryAsync<StudentSubject>, IStudentSubjectRepository
    {
        private readonly DbSet<StudentSubject> _studentSubjects;

        public StudentSubjectRepository(AppDbContext dbContext) : base(dbContext)
        {

            _studentSubjects = dbContext.Set<StudentSubject>();
        }

    }
}
