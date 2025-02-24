namespace School.Data.Responses
{
    public class ManageUserClaimsResponse
    {
        public int UserId { get; set; }
        public List<claim> Claims { get; set; }

    }
    public class claim
    {
        public string Type { get; set; }
        public bool Value { get; set; }
    }
}

