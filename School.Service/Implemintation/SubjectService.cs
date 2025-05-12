using Microsoft.EntityFrameworkCore;
using School.Data.Models;
using School.Infrastracture.AbstractRepository;
using School.Service.Abstract;

namespace School.Service.Implemintation
{
    public class SubjectService : ISubjectService


    {
        private readonly ISubjectRepository _subjectRepository;


        public SubjectService(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;


        }
        public async Task<string> AddSubjectAsync(Subject subject)
        {
            try
            {
                await _subjectRepository.AddAsync(subject);
                return "Success";
            }
            catch
            {
                return "Failed";
            }
        }

        public async Task<string> DeleteSubjectAsync(int id)
        {
            var Subject = await _subjectRepository.GetByIdAsync(id);
            if (Subject == null) return ("NotFound");
            try
            {
                await _subjectRepository.DeleteAsync(Subject);
                return "Success";
            }
            catch
            {
                return "Failed";
            }
        }

        public async Task<string> EditSubjectAsync(Subject subject)
        {
            try
            {
                await _subjectRepository.UpdateAsync(subject);
                return "Success";
            }
            catch
            {
                return "Failed";
            }
        }

        public IQueryable<Subject> GetAllSubjects()
        {
            var Quareble = _subjectRepository.GetTableNoTracking().AsQueryable();
            return Quareble;
        }



        public Task<Subject> GetByIdIncludeAsync(int id)
        {
            return _subjectRepository.GetByIdAsync(id);
        }

        public async Task<bool> IsNameExcludeExists(string name, int id)
        {
            var Student = await _subjectRepository.GetTableNoTracking().Where(x => x.SubjectName == name && x.SubID != id).FirstOrDefaultAsync();
            if (Student == null) return false;
            return true;
        }

        public async Task<bool> IsNameExists(string name)
        {
            var Student = await _subjectRepository.GetTableNoTracking().Where(x => x.SubjectName == name).FirstOrDefaultAsync();
            if (Student == null) return false;
            return true;
        }
    }
}
