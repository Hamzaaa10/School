using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using School.Data.Models.Identity;

namespace School.Infrastracture.Seeder
{
    public static class RoleSeeder
    {
        public static async Task SeedAsync(RoleManager<ApplicationRole> _roleManager)
        {
            var rolesCount = await _roleManager.Roles.CountAsync();
            if (rolesCount <= 0)
            {

                await _roleManager.CreateAsync(new ApplicationRole()
                {
                    Name = "Admin"
                });
                await _roleManager.CreateAsync(new ApplicationRole()
                {
                    Name = "User"
                });
            }
        }

    }
}
