using Microsoft.EntityFrameworkCore;
using School.Data.Models;
using School.Infrastracture.AbstractRepository;
using School.Infrastracture.Bases;
using School.Infrastracture.Data;

namespace School.Infrastracture.ImplemintationRepository
{
    public class InstractorRepository : GenericRepositoryAsync<Instructor>, IInstractorRepository
    {
        private readonly DbSet<Instructor> _instructor;

        public InstractorRepository(AppDbContext dbContext) : base(dbContext)
        {

            _instructor = dbContext.Set<Instructor>();
        }

    }
}
