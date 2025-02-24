using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using School.Data.Models.Identity;

namespace School.Infrastracture.Seeder
{
    public static class UserSeeder
    {
        public static async Task SeedAsync(UserManager<User> _userManager)
        {
            var usersCount = await _userManager.Users.CountAsync();
            if (usersCount <= 0)
            {
                var defaultuser = new User()
                {
                    UserName = "admin",
                    Email = "admin@gmail.com",
                    FullName = "Hamza",
                    Country = "Egypt",
                    PhoneNumber = "01234564567",
                    Address = "Egypt",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true
                };
                await _userManager.CreateAsync(defaultuser, "QwE123!@#");
                await _userManager.AddToRoleAsync(defaultuser, "Admin");
            }
        }
    }
}
