using School.Data.Models;

namespace School.Service.Abstract
{
    public interface IIns_SubjectService
    {
        public Task<string> AddSubjectToInstractorAsync(Ins_Subject ins_Subject);
        public Task<string> EditIns_SubjectAsync(Ins_Subject ins_Subject);
        public Task<string> DeleteIns_SubjectAsync(int InsId, int SubId);
        public Task<Ins_Subject> GetByIdIncludeAsync(int InsId, int SubId);
        public Task<List<Subject>> GetSubjectsAttatchedInstractor(int InstractorID);

    }
}
