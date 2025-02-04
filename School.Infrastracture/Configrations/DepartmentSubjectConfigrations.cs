using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Data.Models;

namespace School.Infrastracture.Configrations
{
    public class DepartmentSubjectConfigrations : IEntityTypeConfiguration<DepartmentSubject>
    {
        public void Configure(EntityTypeBuilder<DepartmentSubject> builder)
        {
            builder.HasKey(ds => new { ds.DID, ds.SubID });

            builder.HasOne(ds => ds.Department)
                   .WithMany(d => d.DepartmentSubjects)
                   .HasForeignKey(ds => ds.DID)
                   .OnDelete(DeleteBehavior.Cascade); // If a department is deleted, remove related subjects

            builder.HasOne(ds => ds.Subject)
                  .WithMany(s => s.DepartmetsSubjects)
                  .HasForeignKey(ds => ds.SubID)
                  .OnDelete(DeleteBehavior.Cascade); // If a subject is deleted, remove related department-subject records
        }
    }
}
