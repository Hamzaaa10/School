using School.Data.Models.Identity;
using School.Data.Response;
using School.Data.Responses;

namespace School.Service.Abstract
{
    public interface IAuthorizationService
    {
        public Task<bool> IsRoleExistsByName(string roleName);
        // public Task<bool> IsRoleExistsById(int roleId);
        public Task<string> AddroleAsync(string roleName);
        public Task<string> UpdateRoleAsync(int id, string roleName);
        public Task<string> DeleteRoleAsync(int id);
        public Task<List<ApplicationRole>> GetAllRolesAsync();
        public Task<ApplicationRole> GetRoleByIdAsync(int id);
        public Task<ManageUserRoleResponse> ManageUserRoleAsync(User user);
        public Task<string> UpdateUserRoles(ManageUserRoleResponse request);
        public Task<ManageUserClaimsResponse> ManageUserClaimsAsync(User user);
        public Task<string> UpdateUserClaims(ManageUserClaimsResponse request);






    }
}
