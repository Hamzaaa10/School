using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Data.Models;

namespace School.Infrastracture.Configrations
{
    public class DepartmentConfigurations : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {

            builder.HasKey(x => x.DID);

            builder.HasMany(x => x.Students).
                WithOne(x => x.Department).
                HasForeignKey(x => x.DID).
                OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.DepartmentSubjects).
                WithOne(x => x.Department).
                HasForeignKey(x => x.DID).
                OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(d => d.Instructor)
          .WithOne(i => i.departmentManager)
          .HasForeignKey<Department>(d => d.InsManager)
          .OnDelete(DeleteBehavior.Restrict);


            builder.HasMany(x => x.Instructors)
            .WithOne(i => i.department)
            .HasForeignKey(d => d.DID)
            .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
