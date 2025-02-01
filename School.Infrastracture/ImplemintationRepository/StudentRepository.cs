using Microsoft.EntityFrameworkCore;
using School.Data.Models;
using School.Infrastracture.AbstractRepository;
using School.Infrastracture.Bases;
using School.Infrastracture.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Infrastracture.ImplemintationRepository
{
    public class StudentRepository : GenericRepositoryAsync<Student> , IStudentRepository
    {
        private readonly DbSet<Student> _students;

        public StudentRepository(AppDbContext dbContext) :base(dbContext) { 
        
            _students=dbContext.Set<Student>();
        }
        public async Task<List<Student>> GetStudentsListAsync()
        {
           return await _students.Include(x => x.Department).ToListAsync();  
        }
    }
}
  