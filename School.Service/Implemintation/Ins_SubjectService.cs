using Microsoft.EntityFrameworkCore;
using School.Data.Models;
using School.Infrastracture.AbstractRepository;
using School.Service.Abstract;

namespace School.Service.Implemintation
{
    public class Ins_SubjectService : IIns_SubjectService
    {
        private readonly IIns_SubjectRepository _ins_SubjectRepository;

        public Ins_SubjectService(IIns_SubjectRepository ins_SubjectRepository)
        {
            _ins_SubjectRepository = ins_SubjectRepository;
        }
        public async Task<string> AddSubjectToInstractorAsync(Ins_Subject ins_Subject)
        {
            try
            {
                await _ins_SubjectRepository.AddAsync(ins_Subject);
                return "Success";
            }
            catch
            {
                return "Failed";
            }
        }

        public async Task<string> DeleteIns_SubjectAsync(int InsId, int SubId)
        {
            var ins_Subject = await _ins_SubjectRepository.GetTableAsTracking().Where(x => x.InsId == InsId && x.SubId == SubId).FirstOrDefaultAsync();
            if (ins_Subject == null) return ("NotFound");
            try
            {
                await _ins_SubjectRepository.DeleteAsync(ins_Subject);
                return "Success";
            }
            catch
            {
                return "Failed";
            }
        }

        public async Task<string> EditIns_SubjectAsync(Ins_Subject ins_Subject)
        {
            try
            {
                await _ins_SubjectRepository.UpdateAsync(ins_Subject);
                return "Success";
            }
            catch
            {
                return "Failed";
            }
        }

        public async Task<Ins_Subject> GetByIdIncludeAsync(int InsId, int SubId)
        {
            var ins_Subject = await _ins_SubjectRepository.GetTableAsTracking().Where(x => x.InsId == InsId && x.SubId == SubId).FirstOrDefaultAsync();
            return ins_Subject;
        }

        public Task<List<Subject>> GetSubjectsAttatchedInstractor(int InstractorID)
        {
            var Subjects = _ins_SubjectRepository.GetTableNoTracking()
                .Where(ss => ss.InsId == InstractorID)
                .Include(ss => ss.Subject)
                .Select(ss => ss.Subject)
                .ToListAsync();
            return Subjects;
        }
    }
}
