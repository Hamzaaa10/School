using Microsoft.EntityFrameworkCore;
using School.Data.Helpers;
using School.Data.Models;
using School.Infrastracture.AbstractRepository;
using School.Service.Abstract;

namespace School.Service.Implemintation
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            this._studentRepository = studentRepository;
        }

        public async Task<string> AddStudentAsync(Student student)
        {

            await _studentRepository.AddAsync(student);
            return "Succses";
        }

        public async Task<string> EditStudentAsync(Student student)
        {
            await _studentRepository.UpdateAsync(student);
            return "Succsess";
        }

        public async Task<List<Student>> GetStudentsAsync()
        {
            return await _studentRepository.GetStudentsListAsync();
        }

        public async Task<Student> GetByIdIncludeAsync(int id)
        {
            return await _studentRepository.GetTableNoTracking().Include(x => x.Department).Where(x => x.StudID == id).FirstOrDefaultAsync();
        }

        public async Task<bool> IsNameExcludeExists(string name, int id)
        {
            var Student = await _studentRepository.GetTableNoTracking().Where(x => x.Name == name && x.StudID != id).FirstOrDefaultAsync();
            if (Student == null) return false;
            return true;
        }

        public async Task<bool> IsNameExists(string name)
        {
            var Student = await _studentRepository.GetTableNoTracking().Where(x => x.Name == name).FirstOrDefaultAsync();
            if (Student == null) return false;
            return true;
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            return await _studentRepository.GetByIdAsync(id);
        }

        public async Task<string> DeleteStudentAsync(Student student)
        {
            var trans = _studentRepository.BeginTransaction();
            try
            {
                await _studentRepository.DeleteAsync(student);
                await trans.CommitAsync();
                return "Succsess";
            }
            catch
            {
                await trans.RollbackAsync();
                return "failed";
            }
        }

        public IQueryable<Student> GetStudentsQuarable(string Search, StudentOrderingEnum OrderBy)
        {
            var Quareble = _studentRepository.GetTableNoTracking().Include(x => x.Department).AsQueryable();
            if (Search != null)
            {
                Quareble = Quareble.Where(x => x.Name.Contains(Search) || x.Address.Contains(Search));
            }
            switch (OrderBy)
            {
                case StudentOrderingEnum.StudID:
                    Quareble.OrderBy(x => x.StudID);
                    break;
                case StudentOrderingEnum.Name:
                    Quareble.OrderBy(x => x.Name);
                    break;
                case StudentOrderingEnum.DepartementName:
                    Quareble.OrderBy(x => x.Department.DName);
                    break;
                case StudentOrderingEnum.Address:
                    Quareble.OrderBy(x => x.Address);
                    break;

            }
            return Quareble;
        }

        public IQueryable<Student> GetStudentsByDepartmentQuarable(int DID)
        {
            var Quareble = _studentRepository.GetTableNoTracking().Where(x => x.DID == DID).AsQueryable();
            return Quareble;
        }
    }
}
