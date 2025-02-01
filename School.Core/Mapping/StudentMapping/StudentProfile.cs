﻿using AutoMapper;

namespace School.Core.Mapping.StudentMapping
{
    public partial class StudentProfile : Profile
    {
        public StudentProfile()
        {
            GetStudentListMapping();
            GetStudentMapping();
            AddStudentMapping();
            EditStudentMapping();
        }
    }
}
