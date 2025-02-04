using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Data.Models;

namespace School.Infrastracture.Configrations
{
    public class SubjectConfigrations : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.HasKey(x => x.SubID);
            builder.HasMany(s => s.StudentsSubjects)
                   .WithOne(ss => ss.Subject)
                   .HasForeignKey(ss => ss.SubID)
                   .OnDelete(DeleteBehavior.Cascade); // If a subject is deleted, remove student-subject relations

            builder.HasMany(s => s.DepartmetsSubjects)
                  .WithOne(ds => ds.Subject)
                  .HasForeignKey(ds => ds.SubID)
                  .OnDelete(DeleteBehavior.Cascade); // If a subject is deleted, remove department-subject relations

            builder.HasMany(s => s.Ins_Subjects)
                  .WithOne(insSub => insSub.Subject)
                  .HasForeignKey(insSub => insSub.SubId)
                  .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
