﻿namespace School.Core.Features.Queries.Responses
{
    public class GetStudentResponse
    {
        public int StudID { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? DepartementName { get; set; }
    }
}
