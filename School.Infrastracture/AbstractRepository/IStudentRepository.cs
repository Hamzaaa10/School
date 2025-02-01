using School.Data.Models;
using School.Infrastracture.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Infrastracture.AbstractRepository
{
    public interface IStudentRepository : IGenericRepositoryAsync<Student>
    {
        public  Task<List<Student>> GetStudentsListAsync();
    }
}
