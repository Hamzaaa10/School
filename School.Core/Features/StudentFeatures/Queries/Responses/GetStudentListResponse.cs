namespace School.Core.Features.StudentFeatures.Queries.Responses
{
    public class GetStudentListResponse
    {
        public int StudID { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? DepartementName { get; set; }
    }
}
