namespace School.Core.Features.DepartmentFeature.Query.Responses
{
    public class GetAllDepartmentsResponse
    {
        public int Id { get; set; }
        public string DName { get; set; }
        public int InsManager { get; set; }

        public string MangerName { get; set; }
    }
}
