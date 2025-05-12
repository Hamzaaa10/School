namespace School.Core.Features.StudentSubjectFeature.Query.Responses
{
    public class GetStudentSubjectsResponse
    {
        public int SubID { get; set; }
        public string SubjectName { get; set; }
        public int Period { get; set; }
        public double grade { get; set; }

    }
}
