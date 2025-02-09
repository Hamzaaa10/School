using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Data.Models;

namespace School.Infrastracture.Configrations
{
    public class StudentConfigrations : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(k => k.StudID);

            // Configure StudID as an Identity (Auto-Increment)
            builder.Property(k => k.StudID)
                   .ValueGeneratedOnAdd();



            builder.HasOne(x => x.Department)
                   .WithMany(x => x.Students)
                   .HasForeignKey(x => x.DID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.StudentSubject)
                   .WithOne(x => x.Student)
                   .HasForeignKey(x => x.StudID)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
