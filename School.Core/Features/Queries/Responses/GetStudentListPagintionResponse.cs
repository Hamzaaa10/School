namespace School.Core.Features.Queries.Responses
{
    public class GetStudentListPagintionResponse
    {
        public int StudID { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? DepartementName { get; set; }

        public GetStudentListPagintionResponse(int studId, string name, string address, string deptname)
        {
            this.StudID = studId;
            this.Name = name;
            this.Address = address;
            this.DepartementName = deptname;
        }

    }
}
