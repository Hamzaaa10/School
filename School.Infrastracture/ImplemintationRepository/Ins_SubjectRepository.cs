using Microsoft.EntityFrameworkCore;
using School.Data.Models;
using School.Infrastracture.AbstractRepository;
using School.Infrastracture.Bases;
using School.Infrastracture.Data;

namespace School.Infrastracture.ImplemintationRepository
{
    public class Ins_SubjectRepository : GenericRepositoryAsync<Ins_Subject>, IIns_SubjectRepository
    {
        private readonly DbSet<Ins_Subject> _ins_Subjects;

        public Ins_SubjectRepository(AppDbContext dbContext) : base(dbContext)
        {
            _ins_Subjects = dbContext.Set<Ins_Subject>();
        }

    }
}
