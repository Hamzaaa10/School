
using School.Core.Features.DepartmentFeature.Query.Responses;
using School.Data.Models;

namespace School.Core.Mapping.DepartmentMapping
{
    public partial class DepartmentProfile
    {
        public void GetDepartmentMapping()
        {
            CreateMap<Department, GetDepartmentResponse>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DID))
                                                          .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.DName))
                                                          .ForMember(dest => dest.MangerName, opt => opt.MapFrom(src => src.Instructor.IName))
                                                          .ForMember(dest => dest.Subjects, opt => opt.MapFrom(src => src.DepartmentSubjects))
                                                          .ForMember(dest => dest.Students, opt => opt.Ignore())
                                                         ;




            //   CreateMap<Student, StudentResponse>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.StudID));

            CreateMap<Instructor, InstractorResponse>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.InsId))
                                                       .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.IName));

            CreateMap<Subject, SubjectResponse>().ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.SubID))
                                                 .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.SubjectName));

        }
    }
}








