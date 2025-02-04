using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Data.Models;

namespace School.Infrastracture.Configrations
{
    public class InstructorConfigurations : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {

            builder
                  .HasOne(x => x.Supervisor)
                  .WithMany(x => x.Instructors)
                  .HasForeignKey(x => x.SupervisorId)
                  .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(i => i.department)
                   .WithMany(d => d.Instructors)
                   .HasForeignKey(i => i.DID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(i => i.departmentManager)
         .WithOne(d => d.Instructor)
         .HasForeignKey<Department>(d => d.InsManager)
         .OnDelete(DeleteBehavior.Restrict);


            builder.HasMany(i => i.Ins_Subjects)
                   .WithOne(insSub => insSub.instructor)
                   .HasForeignKey(insSub => insSub.InsId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
