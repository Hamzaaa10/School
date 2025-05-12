using School.Data.Models.Identity;

namespace School.Service.Abstract
{
    public interface IApplicationUserService
    {
        public Task<string> AddUserAsync(User user, string password);
    }
}