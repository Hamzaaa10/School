using AutoMapper;

namespace School.Core.Mapping.StudentSubjectMapping
{
    public partial class StudentSubjectProfile : Profile
    {
        public StudentSubjectProfile()
        {
            AddSubjectToStudentMapping();
            GetStudentSubjectsMapping();
            EditStudentSubjectMapping();
        }
    }
}
