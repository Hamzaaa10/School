using School.Core.Wrappers;

namespace School.Core.Features.Department.Resposes
{

    public class GetDepartmentResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MangerName { get; set; }
        public PaginatedResult<StudentResponse> Students { get; set; }
        public List<InstractorResponse> Instractors { get; set; }
        public List<SubjectResponse> Subjects { get; set; }


    }

    public class StudentResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public StudentResponse(int id, string Name)
        {
            Id = id;
            this.Name = Name;
        }
    }

    public class InstractorResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class SubjectResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}


