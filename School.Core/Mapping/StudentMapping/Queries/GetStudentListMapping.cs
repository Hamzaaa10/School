using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School.Infrastracture.Data;
using School.Data.Models;
using School.Core.Features.Queries.Responses;

namespace School.Core.Mapping.StudentMapping
{
    public partial class StudentProfile
    {
        public void GetStudentListMapping()
        {
            CreateMap<Student, GetStudentListResponse>().ForMember(dest => dest.DepartementName, opt => opt.MapFrom(src => src.Department.DName));
        }

    }
}
