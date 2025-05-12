namespace School.Core.Features.InstructorFeature.Query.Responses
{
    public class GetInstractorByIdResponse
    {
        public string IName { get; set; }
        public string Address { get; set; }
        public string Position { get; set; }
        public int SupervisorId { get; set; }
        public double Salary { get; set; }
        public string Image { get; set; }
        public int DID { get; set; }
    }
}
