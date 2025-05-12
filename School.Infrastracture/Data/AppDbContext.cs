using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using School.Data.Models;
using School.Data.Models.Identity;
using System.Reflection;

namespace School.Infrastracture.Data
{
    public class AppDbContext : IdentityDbContext<User, ApplicationRole, int, IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {

        //private readonly IEncryptionProvider _encryptionProvider;
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            //  _encryptionProvider = new GenerateEncryptionProvider("746a02fd421b4b92b4c63f25cb9842acc00a04b3-a4af-4b48-8bfe-6c91e75f5b6f");

        }
        public DbSet<User> User { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<DepartmentSubject> DepartmetSubjects { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }
        public DbSet<UserRefreshToken> UserRefreshToken { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //  modelBuilder.UseEncryption(_encryptionProvider);

        }
    }
}
