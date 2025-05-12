using Microsoft.AspNetCore.Http;
using School.Data.Models;

namespace School.Service.Abstract
{
    public interface IInstructorService
    {
        public Task<List<Instructor>> GetInstactorsAsync();
        public Task<Instructor> GetByIdIncludeAsync(int id);

        public Task<Instructor> GetByIdAsync(int id);
        public Task<string> AddInstructorAsync(Instructor instructor, IFormFile file);
        public Task<bool> IsNameExists(string name);
        public Task<string> EditInstructorAsync(Instructor instructor);
        public Task<bool> IsNameExcludeExists(string name, int id);
        public Task<string> DeleteInstructorAsync(int id);
        public Task<List<Instructor>> GetInstructorByDepartment(int DID);
    }
}
