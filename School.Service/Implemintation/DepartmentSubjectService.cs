using Microsoft.EntityFrameworkCore;
using School.Data.Models;
using School.Infrastracture.AbstractRepository;
using School.Service.Abstract;

namespace School.Service.Implemintation
{
    public class DepartmentSubjectService : IDepartmentSubjectService
    {
        private readonly IDepartmentSubjectRepository _departmentSubjectRepository;

        public DepartmentSubjectService(IDepartmentSubjectRepository departmentSubjectRepository)
        {
            _departmentSubjectRepository = departmentSubjectRepository;
        }
        public async Task<string> AddSubjectToDepartmentAsync(DepartmentSubject departmentSubject)
        {
            try
            {
                await _departmentSubjectRepository.AddAsync(departmentSubject);
                return "Success";
            }
            catch
            {
                return "Failed";
            }
        }

        public async Task<string> DeleteDepartmentFromSubjectAsync(int DepartmentID, int SubjectID)
        {
            var DepartmentSubject = await _departmentSubjectRepository.GetTableAsTracking().Where(x => x.DID == DepartmentID && x.SubID == SubjectID).FirstOrDefaultAsync();
            if (DepartmentSubject == null) return ("NotFound");
            try
            {
                await _departmentSubjectRepository.DeleteAsync(DepartmentSubject);
                return "Success";
            }
            catch
            {
                return "Failed";
            }
        }



        public async Task<string> EditSubjectToDepartmentAsync(DepartmentSubject departmentSubject)
        {
            try
            {
                await _departmentSubjectRepository.UpdateAsync(departmentSubject);
                return "Success";
            }
            catch
            {
                return "Failed";
            }
        }

        public async Task<DepartmentSubject> GetByIdAsync(int DepartmentID, int SubjectID)
        {
            var DepartmentSubject = await _departmentSubjectRepository.GetTableNoTracking().Where(x => x.DID == DepartmentID && x.SubID == SubjectID).FirstOrDefaultAsync();
            return DepartmentSubject;

        }

        public async Task<DepartmentSubject> GetByIdIncludeAsync(int DepartmentID, int SubjectID)
        {
            var DepartmentSubject = await _departmentSubjectRepository.GetTableAsTracking().Where(x => x.DID == DepartmentID && x.SubID == SubjectID).FirstOrDefaultAsync();
            return DepartmentSubject;


        }

        public async Task<List<Subject>> GetSubjectsBydepartment(int DepartmentID)
        {
            var subjects = await _departmentSubjectRepository.GetTableNoTracking()
             .Where(ds => ds.DID == DepartmentID)
             .Include(ds => ds.Subject)
             .Select(ds => ds.Subject)
             .ToListAsync();

            return subjects;
        }
    }
}
